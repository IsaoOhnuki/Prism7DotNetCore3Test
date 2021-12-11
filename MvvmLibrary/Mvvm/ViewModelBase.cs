using ModelLibrary.Service;
using Prism.Mvvm;
using Prism.Navigation;

namespace MvvmLibrary.Mvvm
{
    public abstract class ViewModelBase : BindableBase, IDestructible
    {
        protected ILogService LogService { get; private set; }
        protected ViewModelBase(ILogService logService)
        {
            LogService = logService;
        }

        public virtual void Destroy()
        {

        }
    }
}
