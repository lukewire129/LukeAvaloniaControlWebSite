using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using lukewireBlog.Models;
using lukewireBlog.Services;
using lukewireBlog.ViewModels.MessengerModel;
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
    private ICommand ReamdBlogCommand { get; }
    private ICommand SelectedBlogCommand { get; }
    public HomeViewModel(IContentService contentService) : base(contentService)
    {
        ReamdBlogCommand = ReactiveCommand.Create<PanelItemModel>(async (model) =>
        {
            WeakReferenceMessenger.Default.Send(new ReadmBlogChange(model));
        });
    }
    
    public override async void Load()
    {
        try
        {
            Items = new();
            await _contentService.GetAllPosts().ContinueWith((r) =>
            {
                r.Wait();
                var data = _contentService.GetRecenPosts();
                foreach (var post in data)
                {
                    if (post.Metadata.Date == null)
                        continue;
                    Items.Add(new PanelItemModel(post));
                }
            });
        }
        catch (Exception e)
        {
            throw;
        }
    }
}