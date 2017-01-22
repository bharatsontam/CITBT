using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class PreBookingEventMapping : EntityTypeConfiguration<PreBookingEvent>
    {
        public PreBookingEventMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Event).WithMany(x => x.PreBookingEvents).HasForeignKey(x => x.EventId);

            ToTable("PreBookingEvents");
        }
    }
}