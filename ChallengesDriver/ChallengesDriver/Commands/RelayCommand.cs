using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Utilities.Commands
{
    //class RelayCommand : ICommand
    //{

    //    private Action CommandTask;
    //    public RelayCommand(Action workToDo) { CommandTask = workToDo; }
    //    public bool CanExecute(object parameter) { return true; }
    //    public event EventHandler CanExecuteChanged;
    //    public void Execute(object parameter) { CommandTask(); }
    //}

    class RelayCommand : ICommand
    {

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;


        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (null == execute)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter) { _execute(parameter); }
    }

}
