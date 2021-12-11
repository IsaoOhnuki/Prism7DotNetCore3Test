using ModelLibrary.Service;
using Prism.Regions;
using System;

namespace MvvmLibrary.Mvvm
{
    public class CommonViewModel : RegionViewModelBase
    {
        public CommonViewModel(ILogService logService, IRegionManager regionManager)
            : base(logService, regionManager)
        {
        }
    }
}
