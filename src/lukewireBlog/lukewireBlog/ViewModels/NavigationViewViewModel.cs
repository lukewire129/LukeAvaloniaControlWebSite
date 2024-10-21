using System.Collections.Generic;
using AvaloniaNavigationBar;
using AvaloniaNavigationView.ViewModels;
using lukewireBlog.Domain.NavigationView.Components;
using lukewireBlog.Domain.NavigationView.Components.ViewModels;

namespace lukewireBlog.ViewModels;

public class NavigationViewViewModel: ViewModelBase
{
    public _BrandNaviViewModel BrandViewModel { get; } = new _BrandNaviViewModel();
    public _BottomNavigationBarStyle2ViewModel BottomNavigationBarStyle2ViewModel { get; } = new _BottomNavigationBarStyle2ViewModel();
    public NavigationViewViewModel()
    {
    }
}