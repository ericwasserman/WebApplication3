using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;

namespace WebApp.Data.SQL
{
    public class DriverQueries
    {
        public const string Create = @"
insert into Drivers(DriverName, DriverRating, DriverPhone, CompletedRides, UberId, IsActive)
values (@DriverName, @DriverRating, @DriverPhone, @CompletedRides, @UberId, 'True');

select * from Drivers where UberId = @UberId";

        public const string GetAll = @"Select * from Drivers";

        public const string Delete = @"
update Drivers
set IsActive= 0
where Id = @Id";

        public const string Edit = @"
update Drivers
set DriverName = @DriverName, DriverRating = @DriverRating, DriverPhone = @DriverPhone, CompletedRides = @CompletedRides, UberId = @UberId, IsActive = 'True'
where Id = @Id;
select * from Drivers where UberId = @UberId";

        public const string GetDriver = @"Select * from Drivers
where Id = @Id";

    }
}
