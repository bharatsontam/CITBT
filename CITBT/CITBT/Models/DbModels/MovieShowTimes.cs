using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class MovieShowTimes : Entity
    {
        [Key]
        public override Guid Id { get; set; }
        
        [Display(Name="Movie Id")]
        [Required]
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        
        [Display(Name="Theatre Id")]
        [Required]
        [ForeignKey("Theatre")]
        public Guid TheatreId { get; set; }
        
        [Display(Name="Show Time")]
        [Required]
        public string ShowTime { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Theater Theatre { get; set; }

        public virtual ICollection<UserPurchasedMovies> UserPurchasedMovies { get; set; }
    }
}