using AutoMapper;
using Base;
using Base.Domain;
using PropertyLogic.Data;
using PropertyLogic.Events;
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace PropertyLogic
{
    public class Property : Entity
    {
        private readonly IPropertiesRepository _propertiesRepository;
        private readonly IEventBus _eventBus;

        public PropertyStatus Status { get; set; }
        public string Description { get; set; }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(Description.IsNotNullOrEmpty());
        }

        public Property(IPropertiesRepository propertiesRepository, IEventBus eventBus)
        {
            Guard.AgainstNullOrEmpty(propertiesRepository);
            Guard.AgainstNullOrEmpty(eventBus);

            _propertiesRepository = propertiesRepository;
            _eventBus = eventBus;
        }

        public Guid Create(Guid userId, Location location, string description)
        {
            Guard.AgainstNullOrEmpty(description);
            Guard.AgainstNullOrEmpty(userId);


            // todo: syntactic validation of the description
            // is it positive
            // does it contain enough meaning

            // todo: ValidateLocation

            var propertyId = Guid.NewGuid();
            _propertiesRepository.Add(new PropertyDao
            {
                Location = Mapper.Map<LocationDao>(location),

                Description = description,
                Id = propertyId,
                Status = (byte)PropertyStatus.Available,
                UserId = userId
            });

            _propertiesRepository.Save();

            _eventBus.Publish(new PropertyCreated(userId, propertyId));

            return propertyId;
        }

        public TProjection GetOwnedProperty<TProjection>(Guid propertyId, Guid userId, bool full = false)
            where TProjection : class, new()
        {
            var propertyDao = _propertiesRepository
                        .FindBy(p => p.Id == propertyId && p.UserId == userId, new[] { "Location" })
                        .FirstOrDefault();

            TProjection result = default(TProjection);

            propertyDao
                .Match<PropertyDao, PropertyException>(
                    _ => _.IsNull(),

                    string.Format("There is no property {0} owned by user {1}", propertyId, userId),

                    _ =>
                    {
                        result = Mapper.Map<TProjection>(_);
                    });

            return result;
        }

        //public void Rent(Guid propertyId, Guid userId)
        //{
        //    _propertiesRepository.RentProperty(propertyId, userId);

        //    _eventBus.Publish();
        //}

        public bool ChangePropertyRentStatus(Guid propertyId, Guid userId, PropertyStatus status)
        {
            var result = _propertiesRepository.ChangePropertyRentStatus(propertyId, userId, status);

            _eventBus.Publish(CreateEvent(userId, propertyId, status));

            return result == 1;
        }

        private static PropertyEvent CreateEvent(Guid userId, Guid propertyId, PropertyStatus status)
        {
            var statusCode = (int)status;

            if (statusCode == 2)
            {
                return new PropertyRented(userId, propertyId);
            }

            if (statusCode == 1)
            {
                return new PropertyOfferedForRent(userId, propertyId);
            }

            throw new ApplicationException(string.Format(@"Status '{0}' is not mapped to any event.", status));
        }
    }
}