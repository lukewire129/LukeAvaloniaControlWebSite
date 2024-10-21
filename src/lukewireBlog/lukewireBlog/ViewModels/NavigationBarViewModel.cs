using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public class NavigationBarViewModel : ViewModelBase
{
    private string _Markdown;

    public string Markdown
    {
        get { return _Markdown; }
        set { this.RaiseAndSetIfChanged(ref _Markdown, value); }
    }
    
    private string _GithubText = "Github 저장소";

    public string GithubText
    {
        get { return _GithubText; }
        set { this.RaiseAndSetIfChanged(ref _GithubText, value); }
    }

    private string _GithubLink = "https://lukewire129.github.io/navigationbar-avaloniaui/README_kor.md";
    public ICommand ReadmdCommand { get; }
    public NavigationBarViewModel()
    {
        ReadmdCommand = ReactiveCommand.Create<string>(async (idx) =>
        {
            if (Convert.ToInt32(idx)==0)
            {
                
            GithubText = "Github 저장소";
            }
            else
            {
                GithubText = "Github Repository";     
            }
        }, outputScheduler: RxApp.TaskpoolScheduler);
    }
}