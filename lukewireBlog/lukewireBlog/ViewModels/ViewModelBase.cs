using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using lukewireBlog.Services;
using lukewireBlog.Services.Models;
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