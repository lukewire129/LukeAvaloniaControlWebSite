using ReactiveUI;

namespace lukewireBlog;

public abstract class ViewModelBase : ReactiveObject
{
    
    public ViewModelBase()
    {
    }
    public virtual  async void Load()
    {
    }
}