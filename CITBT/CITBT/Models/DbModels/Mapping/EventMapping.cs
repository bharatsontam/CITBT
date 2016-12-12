using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels.Mapping
{
    public class EventMapping : EntityTypeConfiguration<Event>
    {
        public EventMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Address1);
            Property(x => x.Address2);
            Property(x => x.City);
            Property(x => x.Country);
            Property(x => x.CreatedBy);
            Property(x => x.CreatedTimeStamp);
            Property(x => x.EntryFee);
            Property(x => x.EventDateTime);
            Property(x => x.ModifiedBy);
            Property(x => x.Name);
            Property(x => x.OrganizerName);
            Property(x => x.State);
            Property(x => x.UpdatedTimeStamp);
            Property(x => x.ZipCode);
            Property(x => x.Image);
            Property(x => x.ContentType);
            Property(x => x.FileName);

            HasRequired(x => x.User).WithMany(x => x.Events).HasForeignKey(x => x.UserId).WillCascadeOnDelete(false);

            ToTable("Events");
        }
    }
}