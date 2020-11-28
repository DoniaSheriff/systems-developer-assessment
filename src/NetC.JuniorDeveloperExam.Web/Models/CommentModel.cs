using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class CommentModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        [Required]
        public int BlogId { get; set; }
    }
}