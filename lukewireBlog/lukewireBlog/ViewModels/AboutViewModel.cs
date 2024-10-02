using System;
using System.Diagnostics;
using System.IO;
using Avalonia.Platform;
using Avalonia.Utilities;
using Markdig;
using Markdown.ColorCode;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public class AboutViewModel : ViewModelBase
{
    private string _MdHTMl;
    public string MdHTMl
    {
        get { return _MdHTMl; }
        private set { this.RaiseAndSetIfChanged(ref _MdHTMl, value); }
    }

    private string _pathString;
    public string PathString
    {
        get { return _pathString; }
        private set { this.RaiseAndSetIfChanged(ref _pathString, value); }
    }
    public AboutViewModel()
    {
        string basePath = AppContext.BaseDirectory;

        // string fullPath = Path.Combine(basePath, "_posts/about/about.md");
        string fullPath = Path.Combine(basePath, "_posts/about/about.md");
        PathString = fullPath;
        Debug.WriteLine(fullPath);
        if (File.Exists(fullPath))
        {
            var markdown = File.ReadAllText(fullPath);
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseColorCode()
                .Build();
            
            MdHTMl = Markdig.Markdown.ToHtml(markdown, pipeline);
        }
        else
        {
            var PathString = "File not found";
        }
    }
}