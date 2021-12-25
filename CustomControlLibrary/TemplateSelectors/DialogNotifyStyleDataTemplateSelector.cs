using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.TemplateSelectors
{
    public class DialogNotifyStyleDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate InformationStyleTemplate { get; set; }
        public DataTemplate WarningStyleTemplate { get; set; }
        public DataTemplate ErrorStyleTemplate { get; set; }
        public DataTemplate ConfirmStyleTemplate { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return item is DialogNotifyStyle dialogNotifyStyle
                ? dialogNotifyStyle switch
                {
                    DialogNotifyStyle.Confirm => ConfirmStyleTemplate,
                    DialogNotifyStyle.Error => ErrorStyleTemplate,
                    DialogNotifyStyle.Warning => WarningStyleTemplate,
                    DialogNotifyStyle.Information => InformationStyleTemplate,
                    _ => base.SelectTemplate(item, container),
                }
                : null;
        }
    }
}
