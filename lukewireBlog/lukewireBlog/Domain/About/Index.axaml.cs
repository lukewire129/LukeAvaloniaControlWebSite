using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using lukewireBlog.ViewModels;

namespace lukewireBlog.Domain.About;

public partial class Index : UserControl
{
    public Index()
    {
        InitializeComponent();
        this.Loaded += (s, e) =>
        {
            ((ViewModelBase)this.DataContext).Load();
        };
    }
}