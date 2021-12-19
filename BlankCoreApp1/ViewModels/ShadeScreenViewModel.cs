using ModelLibrary.Services;
using MvvmLibrary.Mvvm;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlankCoreApp1.ViewModels
{
    public class ShadeScreenViewModel : ViewModelBase
    {
        public ShadeScreenViewModel(ILogService logService, IRegionManager regionManager, IMessageService messageService)
            : base(logService, regionManager, messageService)
        {

        }

        public override void InisiarizeView(NavigationParameters navigationParameters)
        {
        }

        public override void PreviousInisiarizeView(NavigationParameters navigationParameters)
        {
        }
    }
}
