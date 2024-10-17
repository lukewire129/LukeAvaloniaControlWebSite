using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using lukewireBlog.Domain.Main.Models;
using lukewireBlog.Models;
using lukewireBlog.Services;
using lukewireBlog.ViewModels.MessengerModel;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public partial class MainViewModel : ReactiveObject
{
    private ViewModelBase[] Pages;
    private ViewModelBase _CurrentPage;

    public ViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }

    public List<TapMenuModel> TopMenus { get; set; } = new()
    {
        new TapMenuModel(0, "Home"),
        new TapMenuModel(1, "About"),
    };

    public ICommand NavigateCommand { get; }

    public MainViewModel()
    {
        var service = new ContentService();
        Pages = new ViewModelBase[]
        {
            new HomeViewModel(service),
            new AboutViewModel(service),
        };

        Pages[0].Load();
        CurrentPage = Pages[0];

        NavigateCommand = ReactiveCommand.Create<TapMenuModel>(async (model) =>
        {
            var page = Pages[model.Idx];
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                page.Load();
                CurrentPage = page;
            });
        }, outputScheduler: RxApp.TaskpoolScheduler);

        WeakReferenceMessenger.Default.Register<ReadmBlogChange>(this,
            (r, m) => { this.CurrentPage = (ViewModelBase)new BlogViewModel(service, (PanelItemModel)m.Value); });
    }
}