using Microsoft.AspNetCore.Mvc.RazorPages;
using MicroBlog.Models;
using System.Text.Json;

namespace MicroBlog.Pages;

public class IndexModel : PageModel
{
    public List<Post> Posts { get; set; } = new();

    public void OnGet()
    {
        var filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "data",
            "posts.json"
        );

        if (System.IO.File.Exists(filePath))
        {
            var json = System.IO.File.ReadAllText(filePath);
            Posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
        }
    }
}