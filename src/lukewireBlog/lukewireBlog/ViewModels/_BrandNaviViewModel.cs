using System.Collections.Generic;
using AvaloniaNavigationView;
using AvaloniaNavigationView.ViewModel;

namespace lukewireBlog.Domain.NavigationView.Components.ViewModels;

public class _BrandNaviViewModel : ViewModelBase, INavigationViewModel
{
    public _BrandNaviViewModel()
    {
        NaviTapVM = new List<NavigationViewModel>()
        {
            new NaviViewMOdel("Microsoft"),
            new NaviViewMOdel("Apple"),
            new NaviViewMOdel("Google"),
            new NaviViewMOdel("Facebook"),
            new NaviViewMOdel("Instagram"),
        };
    }

    public List<NavigationViewModel> NaviTapVM { get; set; }
}