using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using lukewireBlog.Models.Messenger;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public class MainViewModel : ReactiveObject
{
    private ViewModelBase[] Pages;
    private ViewModelBase _CurrentPage;

    public ViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }

    public MainViewModel()
    {
        Pages = new ViewModelBase[]
        {
            new DashBoardViewModel(),
            new DetailViewModel(),
        };
        CurrentPage = Pages[0];
        
        WeakReferenceMessenger.Default.Register<RouteChangeMessage>(this, (r, m)=>
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (m.Value.Sender.GetType() == typeof(DashBoardViewModel))
                {
                    CurrentPage = Pages[1];
                    ((DetailViewModel)CurrentPage).ControlLoad((Control)m.Value.Data);
                }
                else if (m.Value.Sender.GetType() == typeof(DetailViewModel))
                {
                    CurrentPage = Pages[0];
                    ((DashBoardViewModel)CurrentPage).Load();
                }
            });
        });
    }
}