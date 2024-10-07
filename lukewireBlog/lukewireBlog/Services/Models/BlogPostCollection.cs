using System;
using System.Collections.Generic;

namespace lukewireBlog.Services.Models;

public class BlogPostCollection
{
    public List<BlogPost> Files { get; set; }
}

public class BlogPost
{
    public string Name { get; set; }
    public string Path { get; set; }
    public string CustomTag { get; set; }
    public Metadata Metadata { get; set; }
}

public class Metadata
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Categories { get; set; }
    public string Tags { get; set; }
    public DateTime? Date { get; set; } // Use DateTime? to handle cases where the date might be absent
}