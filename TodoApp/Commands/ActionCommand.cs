using System;
using System.Windows.Input;

namespace TodoApp.Commands
{
    class ActionCommand : ICommand
    {
        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;
        

        public ActionCommand(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object _)
        {
            return _canExecute.Invoke();
        }

        public void Execute(object _)
        {
            _action.Invoke();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
