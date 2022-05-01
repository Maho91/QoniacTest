using System;
using System.Windows.Input;

namespace WpfUI.MVVMBase
{
    public class RelayCommand<T> : ICommand
    {
        // private fields
        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        // CommandManager.RequerySuggested event is raised whenever the CommandManager thinks that something has changed
        // and that will affect the ability of commands to execute. For example this might be a change of focus.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
