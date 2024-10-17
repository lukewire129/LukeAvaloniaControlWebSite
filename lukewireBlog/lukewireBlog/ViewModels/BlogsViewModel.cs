using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using lukewireBlog.Models;
using lukewireBlog.Services;
using Markdig;
using Markdig.SyntaxHighlighting;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public partial class BlogViewModel : ViewModelBase
{
    private string _MdHTMl;
    public string MdHTMl
    {
        get { return _MdHTMl; }
        set { this.RaiseAndSetIfChanged(ref _MdHTMl, value); }
    }

    public BlogViewModel(IContentService contentService,
                         PanelItemModel panelItemModel
                        ) : base(contentService)
    {
        Task.Run(async () =>
        {

            // 메타데이터 부분 제거
            string content = await contentService.ReadmeLoad(new BlogReadme(panelItemModel._post.Path));
           
            
            if (String.IsNullOrEmpty(content) == false)
            {
                #region 정규식
                string pattern = @"^---[\s\S]*?---\s*"; // ---로 시작하고 ---로 끝나는 부분을 찾음
                string result = Regex.Replace(content, pattern, string.Empty).Trim();
            
                // 정규 표현식 패턴: 이미지 링크가 https://로 시작하지 않을 경우
                string pattern1 = @"(!\[alt text\]\()([^https://].*?)(\))";

                // 링크를 변경할 기본 URL
                string baseUrl = "https://lukewire129.github.io/";

                // 링크가 https://로 시작하지 않으면 강제로 변경
                string resultImage = Regex.Replace(result, pattern1, match =>
                {
                    // 상대 경로를 사용하여 새로운 링크 생성
                    string relativePath = match.Groups[2].Value;
                    string url =$"![alt text]({baseUrl}{panelItemModel._post.Path.Replace("README.md", "")}{relativePath})";

                    return url.Replace(" ", "%20");
                });
                #endregion 
                var pipeline = new MarkdownPipelineBuilder()
                    .UseAdvancedExtensions()
                    .UseSyntaxHighlighting()
                    .Build();

                MdHTMl = resultImage;
                 // MdHTMl = Markdown.TokHtml(resultImage, pipeline);
                // HTML 헤드에 WebFont 및 CSS 추가
                // string fullHtml = $@"
                //     <!DOCTYPE html>
                //     <html>
                //     <head>
                //        {cssLink}
                //     </head>
                //     <body>
                //         {Markdown.ToHtml(resultImage, pipeline)}
                //     </body>
                //     </html>";
                //
                //
                // MdHTMl = fullHtml.Replace("\r\n","");
            }
        });
    }

    public override async void Load()
    {
        
    }

    [RelayCommand]
    private void myLink()
    {
        
    }
}
    
public class MyLinkCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => true;

    // parameter is only string.
    // The url described in markdown is passed to parameter as it is.
    // relative path remains relative path, absolute path remain absolute path.
    public void Execute(object parameter)
    {
        var urlTxt = (string)parameter;

        Markdown.Avalonia.Utils.DefaultHyperlinkCommand.GoTo(urlTxt);
    }
}