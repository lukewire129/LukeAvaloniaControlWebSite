using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Windows.Input;
using lukewireBlog.Domain.Main.Models;
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

    public List<TapMenuModel> SideMenus { get; set; } = new()
    {
        new TapMenuModel(0, "NavigationBar"),
        new TapMenuModel(1, "NavigationView"),
    };

    public ICommand NavigateCommand { get; }

    public MainViewModel()
    {
        Pages = new ViewModelBase[]
        {
            new NavigationBarViewModel(),
            new NavigationViewViewModel(),
        };

        Pages[0].Load();
        CurrentPage = Pages[0];

        NavigateCommand = ReactiveCommand.Create<TapMenuModel>(async (model) =>
        {
            var page = Pages[model.Idx];
            RxApp.MainThreadScheduler.Schedule(() =>
            {
                CurrentPage = page;
            });
        }, outputScheduler: RxApp.TaskpoolScheduler);
    }
}