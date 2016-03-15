using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace dannyallegrezzaBlog.Models
{
    public class Post
    {
        // Properties of the Post Model 
        public long Id { get; set; }    // Primary key for EF

        // Strip out all characters that could cause a problem on the URL and leave us with a String that we can show to users.
        [NotMapped]
        public string Key
        {
            get
            {
                if (Title == null)
                    return null;

                var key = Regex.Replace(Title, @"[^a-zA-Z0-9\- ]", string.Empty);
                return key.Replace(" ", "-").ToLower();
            }
        }


        [Required]
        [StringLength (100, MinimumLength = 5, ErrorMessage = "Title must be at least 5 Characters!")]
        [Display(Name = "Blog Post Title")]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        public DateTime PostedDate { get; set; }
        private string _description;

        // Methods
        public string GetDescription()
        {
            return _description;
        }

        public void SetDescription(string description)
        {
            _description = description;
        }
    }
}
