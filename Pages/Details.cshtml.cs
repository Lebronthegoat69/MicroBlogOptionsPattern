using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MicroBlog.Models;
using System.Text.Json;

namespace MicroBlog.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IOptions<SiteOptions> _siteOptions;

    public DetailsModel(
        IWebHostEnvironment environment,
        IOptions<SiteOptions> siteOptions)
        {
            _environment = environment;
            _siteOptions = siteOptions;
        }

        public Post? BlogPost { get; set; }

        public bool EnableComments => _siteOptions.Value.EnableComments;

        public IActionResult OnGet(int id)
        {
            string filePath = Path.Combine(
                _environment.ContentRootPath,
                "data",
                "posts.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string json = System.IO.File.ReadAllText(filePath);

            List<Post>? posts = JsonSerializer.Deserialize<List<Post>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            BlogPost = posts?.FirstOrDefault(post => post.Id == id);

            if (BlogPost == null)
            {
                return NotFound();
            }

            return Page();
        }
    }

}
