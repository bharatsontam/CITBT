using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT.Models.DbModels
{
    public class Payment : Entity
    {
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
        public string BAddress1 { get; set; }
        public string BAddress2 { get; set; }
        public string BCity { get; set; }
        public string BState { get; set; }
        public string BzipCode { get; set; }
    }
}