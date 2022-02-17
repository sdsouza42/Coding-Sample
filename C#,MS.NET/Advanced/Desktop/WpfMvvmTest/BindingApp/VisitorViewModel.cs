using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;

namespace BindingApp
{
    public class VisitorViewModel : INotifyPropertyChanged
    {
        private VisitorModel model = new VisitorModel();

        public event PropertyChangedEventHandler PropertyChanged;

        private event EventHandler CommandStateChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            CommandStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<VisitorInfo> Visitors
        {
            get { return model.GetVisitors(); }
        }

        public string NameToRegister
        {
            get
            {
                return nameToRegister;
            }

            set
            {
                nameToRegister = value;
                OnPropertyChanged("NameToRegister");
            }
        }

        private string nameToRegister;

        private bool CanExecuteRegister()
        {
            return nameToRegister?.Length > 3;
        }

        private void ExecuteRegister()
        {
            model.RegisterVisit(nameToRegister);
            OnPropertyChanged(nameof(Visitors));
        }

        public ICommand Register
        {
            get { return new RegisterCommand(this); }
        }

        class RegisterCommand : ICommand
        {
            private VisitorViewModel owner;

            public RegisterCommand(VisitorViewModel outer)
            {
                owner = outer;
            }

            event EventHandler ICommand.CanExecuteChanged
            {
                add
                {
                    owner.CommandStateChanged += value;
                }

                remove
                {
                    owner.CommandStateChanged -= value;
                }
            }

            bool ICommand.CanExecute(object parameter)
            {
                return owner.CanExecuteRegister() ;
            }

            void ICommand.Execute(object parameter)
            {
                owner.ExecuteRegister(); ;
            }
        }
    }
}
