using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using lukewireBlog.Models;
using lukewireBlog.Services;
using lukewireBlog.Services.Models;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public class HomeViewModel : ViewModelBase
{ 
    private List<PanelItemModel> items;
    public List<PanelItemModel> Items
    {
        get { return items; }
        set { this.RaiseAndSetIfChanged(ref items, value); }
    }
    public HomeViewModel(IContentService contentService) : base(contentService)
    {
        Task.Run(async () =>
        {
            Items = new();
            var data = await _contentService.GetAllPosts();
            foreach (var post in data)
            {
                if (post.Metadata.Date == null)
                    continue;
                Items.Add(new PanelItemModel(post.Metadata));
            }
        });
    }
    
    public override async void Load()
    {
    }
}