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
    public SideMenu()
    {
    }
}