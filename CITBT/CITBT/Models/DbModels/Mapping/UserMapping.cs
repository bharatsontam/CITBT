using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            HasKey(x => x.UserId);

            Property(x => x.UserId);

            ToTable("Users");
        }
    }

    public class AdminMapping : EntityTypeConfiguration<Admin>
    {
        public AdminMapping()
        {
            HasKey(x => x.AdminId);

            Property(x => x.AdminId);

            ToTable("Admins");
        }
    }

    public class EventOrganizerMapping : EntityTypeConfiguration<EventOrganizer>
    {
        public EventOrganizerMapping()
        {
            HasKey(x => x.OrganizerId);

            Property(x => x.OrganizerId);

            ToTable("EventOrganizers");
        }
    }
}