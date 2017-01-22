using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class TheatreShowTimings : Entity
    {
        [Key]
        public override Guid Id { get; set; }
        [ForeignKey("Theatre")]
        [Display(Name="Theatre Id")]
        [Required]
        public Guid TheatreId { get; set; }
        [Display(Name = "Available Show Time")]
        [Required]
        public string AvailableShowTime { get; set; }

        public virtual Theater Theatre { get; set; }
    }
}