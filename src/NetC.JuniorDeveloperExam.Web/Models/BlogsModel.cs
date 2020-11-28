using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class Blog
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("htmlContent")]
        public string HtmlContent { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
    }
   public class Comment
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class BlogPostsClass
    {
        [JsonProperty("blogPosts")]
        public List<Blog> BlogPosts { get; set; }
    }
}