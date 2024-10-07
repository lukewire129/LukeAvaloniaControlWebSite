using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using lukewireBlog.Services.Models;

namespace lukewireBlog.Services;

public interface IContentService
{
    Task GetAllPosts();
    Task<string> ReadmeLoad(_Readme readme);

    List<BlogPost> GetAllBlog();
    List<BlogPost> GetRecenPosts();
}

public class ContentService : IContentService
{
    private List<BlogPost> Blogs { get; set; }

    public async Task GetAllPosts()
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://lukewire129.github.io/recentblogs.json");
        response.EnsureSuccessStatusCode(); // Throws if the response status is not 200-299
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var aa = JsonSerializer.Deserialize<BlogPostCollection>(jsonResponse,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        
        Blogs = aa.Files.OrderByDescending(x => x.Metadata.Date).ToList();
    }

    public async Task<string> ReadmeLoad(_Readme readme)
    {
        var client = new HttpClient();
        var markdownContent = await client.GetStringAsync($"https://lukewire129.github.io/{readme.GetPath()}");

        return markdownContent;
    }

    public List<BlogPost> GetAllBlog() => this.Blogs;

    public List<BlogPost> GetRecenPosts() => this.Blogs.Take(10).ToList();
}