using System;
using Avalonia;
using Avalonia.Controls;

namespace lukewireBlog.Domain.Home.Components;

public class TopMenu : ListBox
{
    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new TopMenuItem();
    }
    public static readonly AvaloniaProperty IsMenuVisibleProperty =
        AvaloniaProperty.Register<TopMenu, bool>(nameof(IsMenuVisible));

    public bool IsMenuVisible
    {
        get => (bool)GetValue(IsMenuVisibleProperty);
        set => SetValue(IsMenuVisibleProperty, value);
    }
    public TopMenu()
    {
        this.SizeChanged += (s, e) =>
        {
            var width = e.NewSize.Width;
            IsMenuVisible = width > 400;
        };
    }
}