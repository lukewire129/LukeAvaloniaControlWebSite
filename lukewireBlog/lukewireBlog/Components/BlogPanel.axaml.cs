using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace lukewireBlog.Components;

public class BlogPanel : ListBox
{
    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new BlogPanelItem();
    }
}