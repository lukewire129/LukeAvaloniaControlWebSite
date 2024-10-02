using System;
using System.Collections.Generic;
using System.Windows.Input;
using lukewireBlog.Models;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private ViewModelBase[] Pages =
    {
        new HomeViewModel(),
        new BlogsViewModel(),
        new AboutViewModel(),
    };
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
        _CurrentPage = Pages[0];

        NavigateCommand = ReactiveCommand.Create<TapMenuModel>((model)=>
        {
            CurrentPage = Pages[model.Idx];
        });
    }
}