using System.Reactive.Linq;
using System.Threading.Tasks;
using lukewireBlog.Services;
using ReactiveUI;

namespace lukewireBlog.ViewModels;

public abstract class ViewModelBase : ReactiveObject
{
    protected readonly IContentService _contentService;
    public ViewModelBase(IContentService contentService)
    {
        _contentService = contentService;
    }
    public virtual async Task Load()
    {
        await _contentService.GetAllPosts();
    }
}