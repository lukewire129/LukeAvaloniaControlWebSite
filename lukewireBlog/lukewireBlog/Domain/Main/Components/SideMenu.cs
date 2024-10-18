using System;
using Avalonia;
using Avalonia.Controls;

namespace lukewireBlog.Domain.Home.Components;

public class SideMenu : ListBox
{
    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new SideMenuItem();
    }
    public static readonly AvaloniaProperty IsMenuVisibleProperty =
        AvaloniaProperty.Register<SideMenu, bool>(nameof(IsMenuVisible));

    public bool IsMenuVisible
    {
        get => (bool)GetValue(IsMenuVisibleProperty);
        set => SetValue(IsMenuVisibleProperty, value);
    }
    public SideMenu()
    {
        this.SizeChanged += (s, e) =>
        {
            var width = e.NewSize.Width;
            IsMenuVisible = width > 400;
        };
    }
}