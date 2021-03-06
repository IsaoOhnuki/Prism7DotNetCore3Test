using MessageServiceLibrary.ViewModels;
using MvvmServiceLibrary;
using System.Windows;
using System.Windows.Controls;

namespace MessageServiceLibrary.TemplateSelectors
{
    public class MessageDialogTemplateSelectors : DataTemplateSelector
    {
        public DataTemplate OkOnlyTemplate { get; set; }
        public DataTemplate OkCancelTemplate { get; set; }
        public DataTemplate YesNoTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            MessageDialogStyle messageDialogType = ((MessageDialogViewModel)item).MessageDialogValue;

            switch (messageDialogType)
            {
                case MessageDialogStyle.InformationMessage:
                    return OkOnlyTemplate;
                case MessageDialogStyle.WarningMessage:
                    return OkCancelTemplate;
                case MessageDialogStyle.ErrorMessage:
                    return YesNoTemplate;
            }

            return base.SelectTemplate(item, container);
        }
    }
}
