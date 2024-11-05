using System.Timers;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Threading;
using AvaloniaNavigationBar.Style;
using lukewireBlog.Domain.NavigationView.Components.ViewModels;

namespace lukewireBlog.Components.Shared;

public class NavigationPage_Brand : TemplatedControl
{
    public NavigationPage_Brand()
    {
        this.DataContext = new _BrandNaviViewModel();
    }
    private MagicBar _magicBar = null!;
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        
        _magicBar = e.NameScope.Get<MagicBar>("PART_NAVI");
        
        var tm = new Timer();
        
        tm.Interval = 1000;
        int i = 1;
        tm.Elapsed += (s, e) =>
        {
            if (i == 5)
            {
                i = 0;
            }

            Dispatcher.UIThread.InvokeAsync(() =>
            {
                _magicBar.SelectedIndex = i++;
            });
        };
        tm.Start(); 
    }
}