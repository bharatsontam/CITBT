using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class TheatreMapping : EntityTypeConfiguration<Theater>
    {
        public TheatreMapping()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Address1);
            Property(t => t.Address2);
            Property(t => t.City);
            Property(t => t.Country);
            Property(t => t.CreatedBy);
            Property(t => t.CreatedTimeStamp);
            Property(t => t.ModifiedBy);
            Property(t => t.Name);
            Property(t => t.State);
            Property(t => t.UpdatedTimeStamp);
            Property(t => t.ZipCode);

            ToTable("Theatres");
        }
    }
}