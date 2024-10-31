using Avalonia.Media;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public class ThemeSwitchViewModel: ViewModelBase
{
    private bool _isChecked;
    private IBrush _background;
    
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            this.RaiseAndSetIfChanged(ref _isChecked, value);
            Background = _isChecked 
                ? new SolidColorBrush(Color.Parse("#3e3c3d")) // HEX 문자열 사용
                : new SolidColorBrush(Color.Parse("#f1f0e9")); // HEX 문자열 사용
        }
    }

    public IBrush Background
    {
        get => _background;
        set => this.RaiseAndSetIfChanged(ref _background, value);
    }
}