using System.Collections.Generic;
using AvaloniaNavigationView;
using AvaloniaNavigationView.ViewModel;

namespace lukewireBlog.Domain.NavigationView.Components.ViewModels;

public class _BottomNavigationBarStyle2ViewModel: ViewModelBase, INavigationViewModel
{
    public _BottomNavigationBarStyle2ViewModel()
    {
        NaviTapVM = new List<NavigationViewModel>()
        {
            new NaviViewMOdel("Home"),
            new NaviViewMOdel("Shop"),
            new NaviViewMOdel("Wishlist"),
            new NaviViewMOdel("Cart"),
            new NaviViewMOdel("Me"),
        };
    }
    public List<NavigationViewModel> NaviTapVM { get; set; }
}