using System;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using lukewireBlog.Models.Messenger;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public partial class DetailViewModel : ViewModelBase
{
    private Control? currentControl;

    public Control? CurrentControl
    {
        get { return currentControl; }
        set { this.RaiseAndSetIfChanged(ref currentControl, value); }
    }


    public DetailViewModel()
    {
    }

    [RelayCommand]
    private void Back()
    {
        this.CurrentControl = null;
        WeakReferenceMessenger.Default.Send(new RouteChangeMessage(new RouteModel(this, null)));
    }
    
    public void ControlLoad(Control control)
    {
        var controlType = control.GetType();
        this.CurrentControl = Activator.CreateInstance(controlType) as Control;
    }
}