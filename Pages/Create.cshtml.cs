using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MicroBlog.Models;
using System.Text.Json;

namespace MicroBlog.Pages;

public class CreateModel : PageModel
{
    [BindProperty]
    public Post Post { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "data",
            "posts.json"
        );

        var posts = new List<Post>();

        if (System.IO.File.Exists(filePath))
        {
            var json = System.IO.File.ReadAllText(filePath);
            posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
        }

        Post.Id = posts.Count > 0 ? posts.Max(p => p.Id) + 1 : 1;

        posts.Add(Post);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var updatedJson = JsonSerializer.Serialize(posts, options);
        System.IO.File.WriteAllText(filePath, updatedJson);

        return RedirectToPage("/Index");
    }
}