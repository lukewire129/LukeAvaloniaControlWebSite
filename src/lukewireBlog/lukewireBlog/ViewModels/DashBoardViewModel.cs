using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using lukewireBlog.Components.Shared;
using lukewireBlog.Models;
using lukewireBlog.Models.Messenger;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public partial class DashBoardViewModel :ViewModelBase
{
    private List<ContentItemModel> contentItems= new()
    {
        new ContentItemModel(0, new NavigationView_MagicBar()),
        new ContentItemModel(1, new NavigationView_Custom1()),
        new ContentItemModel(2, new NavigationPage_Custom1()),
        new ContentItemModel(3, new NavigationPage_Brand()),
        new ContentItemModel(4, new RiotButtonView()),
        new ContentItemModel(5, new SmartDateView()),
        new ContentItemModel(6, new SocialIcon3dView()),
        new ContentItemModel(7, new ThemeSwitchView())
    };

    public List<ContentItemModel> ContentItems
    {
        get { return contentItems; }
        set { this.RaiseAndSetIfChanged(ref contentItems, value); }
    }
    
    public ICommand DetailCommand { get; }

    public DashBoardViewModel()
    {
        DetailCommand = ReactiveCommand.Create<ContentItemModel>(async (model) =>
        {
            ContentItems = null;
            WeakReferenceMessenger.Default.Send(new RouteChangeMessage(new RouteModel(this, model.Content)));
        }, outputScheduler: RxApp.TaskpoolScheduler);
    }

    public void Load()
    {
        ContentItems = new()
        {
            new ContentItemModel(0, new NavigationView_MagicBar()),
            new ContentItemModel(1, new NavigationView_Custom1()),
            new ContentItemModel(2, new NavigationPage_Custom1()),
            new ContentItemModel(3, new NavigationPage_Brand()),
            new ContentItemModel(4, new RiotButtonView()),
            new ContentItemModel(5, new SmartDateView()),
            new ContentItemModel(6, new SocialIcon3dView()),
            new ContentItemModel(7, new ThemeSwitchView())
        };
    }
}