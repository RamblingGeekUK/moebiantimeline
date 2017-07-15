using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TimeLine.Models
{
    public class annotation
    {

        private DateTime? dateCreated = null;
        public Guid id { get; set; }
        public DateTime entrydatetime {
            get
            {
                return this.dateCreated.HasValue
                    ? this.dateCreated.Value
                    : DateTime.Now;
            }
            set { this.dateCreated = value; }
        }
        
        public DateTime datetime {
            get
            {
                return this.dateCreated.HasValue
                    ? this.dateCreated.Value
                    : DateTime.Now;
            }
            set { this.dateCreated = value; }

        }
        public String subject { get; set; }
        public String description { get; set; }
        public String context { get; set; }

        public string username { get; set; }

    }
}