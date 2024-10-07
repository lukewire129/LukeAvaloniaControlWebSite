using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        private set { this.RaiseAndSetIfChanged(ref items, value); }
    }
    public HomeViewModel(IContentService contentService) : base(contentService)
    {
        Items = new();
    }
    
    public override void Load()
    {
        Task.Run(async () =>
        {
            _contentService.GetAllPosts().ContinueWith((e) =>
            {
                
                var recent = _contentService.GetRecenPosts();
                foreach (var post in  recent)
                {
                    if(post.Metadata.Date == null)
                        continue;
                    Items.Add(new PanelItemModel(post.Metadata));
                }
            });

        });
    }
}