using Avalonia.Controls;

namespace lukewireBlog.Components.Shared;

public class ContentBox : ListBox
{
    protected override Control CreateContainerForItemOverride(object? item, int index, object? recycleKey)
    {
        return new ContentItem();
    }

    public ContentBox()
    {

        var aa = this.DataContext;
    }
}