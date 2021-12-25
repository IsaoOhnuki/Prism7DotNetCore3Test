using System;
using System.Windows.Input;

namespace CustomControlLibrary.Models
{
    public class DefaultCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action Command { get; }

        private Action<object> CommandV { get; }

        private Func<bool> IsCanExecute { get; }

        private Func<object, bool> IsCanExecuteV { get; }

        public DefaultCommand(Action command)
        {
            Command = command;
        }

        public DefaultCommand(Action<object> command)
        {
            CommandV = command;
        }

        public DefaultCommand(Action command, Func<bool> isCanExecute)
        {
            Command = command;
            IsCanExecute = isCanExecute;
        }

        public DefaultCommand(Action<object> command, Func<object, bool> isCanExecute)
        {
            CommandV = command;
            IsCanExecuteV = isCanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return IsCanExecute != null ? IsCanExecute() : IsCanExecuteV == null || IsCanExecuteV(parameter);
        }

        public void Execute(object parameter)
        {
            Command?.Invoke();
            CommandV?.Invoke(parameter);
        }

        public void FireCanExecuteChanged(object sender, EventArgs e)
        {
            CanExecuteChanged?.Invoke(sender, e);
        }
    }
}
