using System.Web.Mvc;
using System.Web.Routing;

namespace NetC.JuniorDeveloperExam.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}",
              defaults: new { controller = "BlogPosts", action = "Index" });
            routes.MapRoute(
              name: "BlogPosts",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "BlogPosts", action = "GetBlogPosts", id = UrlParameter.Optional });
            routes.MapRoute(
              name: "Default2",
              url: "{controller}/{action}",
              defaults: new { controller = "BlogPosts", action = "GetBlogPosts", id = UrlParameter.Optional });

        }
    }
}
