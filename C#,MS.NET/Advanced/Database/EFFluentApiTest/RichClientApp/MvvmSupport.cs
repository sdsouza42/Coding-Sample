using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace MvvmSupport
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if(!Equals(storage, value))
            {
                storage = value;
                OnPropertyChanged(propertyName);
            }
        }
    }

    public class DelegateCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public DelegateCommand(Action execute, Func<bool> canExecute = null) : this(o => execute())
        {
            if (canExecute != null)
                this.canExecute = o => canExecute();
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
