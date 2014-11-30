﻿using Base;
using Base.Domain;
using PropertyLogic.Data;
using System;
using System.Diagnostics.Contracts;

namespace PropertyLogic
{
    public class Property : Entity
    {
        private readonly IPropertiesRepository _propertiesRepository;

        public PropertyStatus Status { get; set; }

        public Property(IPropertiesRepository propertiesRepository)
        {
            Contract.Requires<ArgumentNullException>(propertiesRepository.IsNotNull());

            _propertiesRepository = propertiesRepository;
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
                // todo: add location
                
                Description = description,
                Id = propertyId,
                Status = (sbyte)PropertyStatus.Available,
                UserId = userId
            });

            return propertyId;
        }
    }
}