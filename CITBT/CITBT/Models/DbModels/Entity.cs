using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class Entity
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}