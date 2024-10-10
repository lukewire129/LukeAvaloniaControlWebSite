using System.Collections.Generic;
using System.Windows.Input;
using lukewireBlog.Domain.Main.Models;
using lukewireBlog.Services;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public partial class MainViewModel : ReactiveObject
{
    private ViewModelBase[] Pages;
    private ViewModelBase _CurrentPage;
    public ViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }

    public List<TapMenuModel> TopMenus { get; set; } = new()
    {
        new TapMenuModel(0, "Home"),
        new TapMenuModel(1, "Blogs"),
        new TapMenuModel(2, "About"),
    };

    public ICommand NavigateCommand { get; }

    public MainViewModel()
    {
        var service = new ContentService();
        Pages = new ViewModelBase[]
        {
            new HomeViewModel(service),
            new BlogViewModel(service),
            new AboutViewModel(service),
        };
        _CurrentPage = Pages[0];
        _CurrentPage.Load();
        NavigateCommand = ReactiveCommand.Create<TapMenuModel>((model)=>
        {
            CurrentPage = Pages[model.Idx];
            Pages[model.Idx].Load();
        });
    }
}