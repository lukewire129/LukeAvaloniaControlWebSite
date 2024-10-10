using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Threading;
using lukewireBlog.Models;
using lukewireBlog.Services;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public class HomeViewModel : ViewModelBase
{ 
    private ObservableCollection<PanelItemModel> items;
    public ObservableCollection<PanelItemModel> Items
    {
        get { return items; }
        set { this.RaiseAndSetIfChanged(ref items, value); }
    }
    public HomeViewModel(IContentService contentService) : base(contentService)
    {
        Items = new();
    }
    
    public override async Task Load()
    {
        var data = await _contentService.GetAllPosts();
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            Items.Clear(); // 기존 데이터 클리어
            foreach (var post in data)
            {
                if (post.Metadata.Date == null)
                    continue;
                Items.Add(new PanelItemModel(post.Metadata));
            }
        });
        // Observable.Start(async () =>
        //     {
        //         return  await _contentService.GetAllPosts();
        //     })
        //     .Subscribe(result =>
        //     {
        //         var recent = result.Result;
        //         foreach (var post in  recent)
        //         {
        //             if(post.Metadata.Date == null)
        //                 continue;
        //             Items.Add(new PanelItemModel(post.Metadata));
        //         }
        //     },  error =>
        //     {
        //         // 작업 실패 시 에러 처리
        //         Console.WriteLine($"에러 발생: {error.Message}");
        //     });
    }
}