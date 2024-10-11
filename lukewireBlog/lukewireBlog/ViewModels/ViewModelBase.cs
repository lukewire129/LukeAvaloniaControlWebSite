using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using lukewireBlog.Services;
using lukewireBlog.Services.Models;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    protected readonly IContentService _contentService;
    public ViewModelBase(IContentService contentService)
    {
        _contentService = contentService;
    }
    public virtual  async void Load()
    {
        var aa = await _contentService.GetAllPosts();
    }
}