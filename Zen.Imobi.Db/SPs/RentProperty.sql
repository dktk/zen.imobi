create PROCEDURE [dbo].sp_RentProperty
	@propertyId uniqueidentifier,
	@userId uniqueidentifier 
AS
BEGIN
	update property.Properties
		set Status = 2
	where Id = @propertyId and UserId = @userId
	
	-- the message is already defined
	if @@ROWCOUNT <> 1
	begin
		declare @pId as varchar(32) = cast(@propertyId as varchar(32))
		declare @uId as varchar(32) = cast(@userId as varchar(32))
		raiserror (1000001, 25, 1, @pId, 2, @uId)
	end
END
GO