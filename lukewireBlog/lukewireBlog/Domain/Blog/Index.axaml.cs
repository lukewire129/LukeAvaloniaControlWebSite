using Avalonia.Controls;
using lukewireBlog.ViewModels;

namespace lukewireBlog.Domain.Blog;

public partial class Index : UserControl
{
    public Index()
    {
        InitializeComponent();
        // this.Loaded += (s, e) =>
        // {
        //     ((ViewModelBase)this.DataContext).Load();
        // };
    }
}