create PROCEDURE [dbo].sp_ChangePropertyRentStatus
	@propertyId uniqueidentifier,
	@userId uniqueidentifier,
	@status int
AS
BEGIN
	--declare @status as 
	--select
	select top 1 Id from property.Properties 
		where Id = @propertyId and UserId = @userId and [Status] = @status
	
	declare @pId as varchar(32) = cast(@propertyId as varchar(32))
	declare @uId as varchar(32) = cast(@userId as varchar(32))
		
	if @@ROWCOUNT <> 0
	begin
		raiserror (1000002, 25, 1, @pId, 2, @uId)
	end

	update property.Properties
		set [Status] = @status
	where Id = @propertyId and UserId = @userId
	
	-- the message is already defined
	if @@ROWCOUNT <> 1
	begin
		raiserror (1000001, 25, 1, @pId, 2, @uId)
	end
END
GO