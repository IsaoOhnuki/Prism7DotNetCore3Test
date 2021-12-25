using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomControlLibrary.TemplateSelectors
{
    public class CommandStatusButtonDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ExecuteStyleTemplate { get; set; }
        public DataTemplate OkStyleTemplate { get; set; }
        public DataTemplate CancelStyleTemplate { get; set; }
        public DataTemplate NextStyleTemplate { get; set; }
        public DataTemplate PreviousStyleTemplate { get; set; }
        public DataTemplate ApllyStyleTemplate { get; set; }
        public DataTemplate StopStyleTemplate { get; set; }
        public DataTemplate InfomationStyleTemplate { get; set; }
        public DataTemplate HelpStyleTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return item is CommandStatus commandStatus
                ? commandStatus switch
                {
                    CommandStatus.Execute => ExecuteStyleTemplate,
                    CommandStatus.Ok => OkStyleTemplate,
                    CommandStatus.Cancel => CancelStyleTemplate,
                    CommandStatus.Next => NextStyleTemplate,
                    CommandStatus.Previous => PreviousStyleTemplate,
                    CommandStatus.Aplly => ApllyStyleTemplate,
                    CommandStatus.Stop => StopStyleTemplate,
                    CommandStatus.Infomation => InfomationStyleTemplate,
                    CommandStatus.Help => HelpStyleTemplate,
                    _ => throw new NotImplementedException(),
                }
                : null;
        }
    }
}
