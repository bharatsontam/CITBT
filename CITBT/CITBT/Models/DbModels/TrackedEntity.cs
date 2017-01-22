using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class TrackedEntity : Entity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedTimeStamp { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset UpdatedTimeStamp { get; set; }
    }
}