using NetC.JuniorDeveloperExam.Web.Models;
using System.Collections.Generic;

namespace NetC.JuniorDeveloperExam.Web.Services
{
    public interface IBlogPosts
    {
        BlogPostsClass DeserializeObject();
        List<Blog> GetBlogs();
        Blog GetBlog(int? id);
        bool AddComment(CommentModel comment1);
    }
}