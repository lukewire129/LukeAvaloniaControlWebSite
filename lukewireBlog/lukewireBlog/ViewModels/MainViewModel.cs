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
        new AViewModel(),
        new BViewModel(),
    };
    private ViewModelBase _CurrentPage;
    public ViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }

    public List<TapMenuModel> TopMenus = new()
    {
        new TapMenuModel(0, "Home"),
        new TapMenuModel(1, "Archive"),
    };

    public ICommand NavigateNextCommand { get; }
    public MainViewModel()
    { 
        _CurrentPage = Pages[0];

        NavigateNextCommand = ReactiveCommand.Create<string>((idx)=>
        {
            CurrentPage = Pages[Convert.ToInt32(idx)];
        });
    }   
}