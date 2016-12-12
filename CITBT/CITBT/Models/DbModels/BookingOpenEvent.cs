using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class BookingOpenEvent : Entity
    {
        [Key]
        public override Guid Id { get; set; }
        
        [Display(Name="Event Id")]
        [ForeignKey("Event")]
        [Required]
        public Guid EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}