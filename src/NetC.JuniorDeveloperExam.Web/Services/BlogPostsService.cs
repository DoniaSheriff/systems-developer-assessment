using NetC.JuniorDeveloperExam.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace NetC.JuniorDeveloperExam.Web.Services
{
    public class BlogPostsService : IBlogPosts
    {
        public BlogPostsService()
        {

        }
        public BlogPostsClass DeserializeObject() =>
            JsonConvert.DeserializeObject<BlogPostsClass>(System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/Blog-Posts.json")));
        public void SerializeObject(BlogPostsClass model) => System.IO.File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/Blog-Posts.json"), JsonConvert.SerializeObject(model));
        public List<Blog> GetBlogs()
        {
            var json = DeserializeObject();
            if (json.BlogPosts.Count > 0)
            {
                List<Blog> blogsList = new List<Blog>();
                foreach (var item in json.BlogPosts)
                {
                    Blog blog = new Blog()
                    {
                        Id = item.Id,
                        Date = item.Date,
                        Title = item.Title,
                        Image = item.Image,
                        HtmlContent = item.HtmlContent,
                        Comments = item.Comments
                    };
                    blogsList.Add(blog);
                }
                return blogsList;
            }
            return null;
        }

        public Blog GetBlog(int? id)
        {
            var json = DeserializeObject();
            if (json.BlogPosts.Count > 0)
            {
                foreach (var item in json.BlogPosts)
                {
                    if (item.Id == id)
                    {
                        Blog blog = new Blog()
                        {
                            Id = item.Id,
                            Date = item.Date,
                            Title = item.Title,
                            Image = item.Image,
                            HtmlContent = item.HtmlContent,
                            Comments = item.Comments
                        };
                        return blog;
                    }
                }

            }

            return null;
        }

        public bool AddComment(CommentModel commentModel)
        {
            var json = DeserializeObject();
            if (json.BlogPosts.Count > 0)
            {
                foreach (var item in json.BlogPosts)
                {
                    if (item.Id == commentModel.BlogId)
                    {
                        var newComment = new Comment()
                        {
                            Date = DateTime.Now,
                            EmailAddress = commentModel.EmailAddress,
                            Name = commentModel.Name,
                            Message = commentModel.Comment
                        };

                        if (item.Comments == null)
                            item.Comments = new List<Comment> { newComment };
                        else
                            item.Comments.Add(newComment);
                        break;
                    }
                }
                SerializeObject(json);

            }

            return true;
        }
    }
}