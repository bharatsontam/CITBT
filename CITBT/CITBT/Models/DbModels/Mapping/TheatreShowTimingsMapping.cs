using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace CITBT.Models.DbModels.Mapping
{
    public class TheatreShowTimingsMapping : EntityTypeConfiguration<TheatreShowTimings>
    {
        public TheatreShowTimingsMapping()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.AvailableShowTime);

            HasRequired(t => t.Theatre).WithMany(s => s.TheatreShowTimings).HasForeignKey(f => f.TheatreId);

            ToTable("TheatreShowTimings");
        }
    }
}