using Data.Abstract;
using Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository _postRepository; 
        // Entity Framework'ten başka bir ORM'e geçilirseyine bu interface kullanmış olucak bağımlılığı ortadan kaldırmış oluyoruz.

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
    
        public IActionResult Index()
        {
            return View(_postRepository.Posts.ToList());
        }
    }
}
