using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using Blog.Models.Contexts;

namespace Blog.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int id)
        {
            using (var ctx = new BlogContext())
            {
                var category = ctx.Categories
                    .Include(c => c.Articles)
                    .Include(c => c.Articles.Select(a => a.Comments))
                    .FirstOrDefault(c => c.Id == id);

                if (category == null)
                    return HttpNotFound();

                return View(category.Articles);
            }
        }
    }
}