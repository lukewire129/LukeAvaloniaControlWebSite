using ReactiveUI;

namespace lukewireBlog.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    
    public ViewModelBase()
    {
    }
    public virtual  async void Load()
    {
    }
}