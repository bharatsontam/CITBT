using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class Theater : TrackedEntity
    {
        [Key]
        [Display(Name = "Id")]
        public override Guid Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Address1")]
        [Required]
        public string Address1 { get; set; }
        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }
        [Display(Name = "Zipcode")]
        [Required]
        public string ZipCode { get; set; }
        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }

        public virtual ICollection<MovieShowTimes> MovieShowTimes { get; set; }

        public virtual ICollection<TheatreShowTimings> TheatreShowTimings { get; set; } 
    }
}