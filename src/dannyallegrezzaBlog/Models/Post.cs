using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace dannyallegrezzaBlog.Models
{
    public class Post
    {
        // Properties of the Post Model 
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
