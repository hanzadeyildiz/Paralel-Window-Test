﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParalelWindowTest
{
    public class RelayCommand : ICommand
    {
        private Action action;

        private Func<bool> condition;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action action)
        {
            this.action = action;
            this.condition = () => true;
        }

        public RelayCommand(Action action, bool condition)
        {
            this.action = action;
            this.condition = () => condition;
        }

        public RelayCommand(Action action, Func<bool> condition)
        {
            this.action = action;
            this.condition = condition;
        }

        public bool CanExecute(object parameter)
        {
            return condition.Invoke();
        }

        public void Execute(object parameter)
        {
            action.Invoke();
        }
    }
}
