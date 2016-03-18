using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dannyallegrezzaBlog.Models
{
    public class Comment
    {
        public long Id { get; set; }

        // Post Properties
        public long PostId { get; set; }
        public virtual Post Post { get; set; }

        // Comments specific properties
        public DateTime PostedDate { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
    }
}
