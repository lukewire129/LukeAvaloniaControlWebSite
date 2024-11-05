using System.ComponentModel;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace lukewireBlog.ViewModels;

public partial class ThemeSwitchViewModel: ObservableObject
{
    [ObservableProperty] bool _isChecked;
    [ObservableProperty] IBrush _background;

    public ThemeSwitchViewModel()
    {
        this.Background = new SolidColorBrush(Color.Parse("#f1f0e9"));
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(IsChecked))
        {
            Background = _isChecked 
                ? new SolidColorBrush(Color.Parse("#3e3c3d")) // HEX 문자열 사용
                : new SolidColorBrush(Color.Parse("#f1f0e9")); // HEX 문자열 사용
        }
    }
}