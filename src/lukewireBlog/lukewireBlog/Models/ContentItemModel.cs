using Avalonia.Controls;

namespace lukewireBlog.Models;

public class ContentItemModel
{
    public int Idx { get; set; }
    public Control Content { get; set; }
    public ContentItemModel(int idx, Control content)
    {
        this.Idx = idx;
        this.Content = content;
    }
}