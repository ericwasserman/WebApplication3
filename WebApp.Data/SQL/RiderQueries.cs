using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using Dapper;


namespace WebApp.Data.SQL
{
    public class RiderQueries
    {
        public const string Create = @"
insert into Riders(RiderName, RiderRating, RiderPhone, IsActive)
values (@RiderName, @RiderRating, @RiderPhone,'True');

select * from Riders where RiderUberId = @RiderUberId";

        public const string GetAll = @"Select * from Riders";

        public const string Delete = @"
update Riders
set IsActive= 0
where Id = @Id";

        public const string Edit = @"
update Riders
set RiderName = @RiderName, RiderRating = @RiderRating, RiderPhone = @RiderPhone, RiderUberId = @RiderUberId, IsActive = 'True'
where Id = @Id;
select * from Riders where RiderUberId = @RiderUberId";

        public const string GetRider = @"Select * from Riders
where Id = @Id";

    }
}
