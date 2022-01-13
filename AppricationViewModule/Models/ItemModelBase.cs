using MvvmCommonLibrary.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppricationViewModule.Models
{
    public abstract class ItemModelBase<T> : ModelBase
    {
        public abstract T OldItem { get; protected set; }

        public abstract T Item { get; set; }

        public abstract bool Editing { get; }
    }
}
