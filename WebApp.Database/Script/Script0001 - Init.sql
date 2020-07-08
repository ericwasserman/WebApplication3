if (select top 1 1 from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Task') is null
begin
	create table Task (
		Id uniqueidentifier primary key,
		[Name] varchar(100)
	);
end