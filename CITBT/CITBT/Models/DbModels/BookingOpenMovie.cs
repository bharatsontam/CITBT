using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class BookingOpenMovie : Entity
    {
        [Key]
        public override Guid Id { get; set; }

        [Display(Name="Movie Id")]
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}