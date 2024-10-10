using System;
using System.Threading.Tasks;
using lukewireBlog.Services;
using lukewireBlog.ViewModels;
using Markdig;
using Markdig.SyntaxHighlighting;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public class AboutViewModel : ViewModelBase
{
    private string _MdHTMl;
    public string MdHTMl
    {
        get { return _MdHTMl; }
        set { this.RaiseAndSetIfChanged(ref _MdHTMl, value); }
    }
    
    public AboutViewModel(IContentService contentService) : base(contentService)
    {
        Task.Run(async () =>
        {
            string content = await _contentService.ReadmeLoad(new AboutReadme());

            if (String.IsNullOrEmpty(content) == false)
            {
                var pipeline = new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions()
                    .UseSyntaxHighlighting()
                    .Build();
                var cssLink = "<style>pre { background-color: #f6f8fa; }</style>\n\r";
                MdHTMl = Markdown.ToHtml(cssLink +content, pipeline);
            }
        });
    }
}