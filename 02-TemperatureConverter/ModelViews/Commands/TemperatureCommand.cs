using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TemperatureConverter.ModelViews.Commands
{
   public class TemperatureCommand : ICommand
   {
      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      readonly private Action<object> _executeMethod;
      readonly private Predicate<object> _canExecute;

      public TemperatureCommand(Action<object> executeMethod, Predicate<object> canExecute)
      {
         _executeMethod = executeMethod;
         _canExecute = canExecute;
      }

      public TemperatureCommand(Action<object> executeMethod) : this(executeMethod, null)
      {

      }

      public bool CanExecute(object parameter)
      {
         return _canExecute == null ? true : _canExecute(parameter);
      }

      public void Execute(object parameter)
      {
         _executeMethod.Invoke(parameter);
      }
   }
}
