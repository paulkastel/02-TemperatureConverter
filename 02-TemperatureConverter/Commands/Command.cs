using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TemperatureConverter.Commands
{
   public class Command : ICommand
   {
      readonly Action<object> _executeMethod;
      readonly Predicate<object> _canExecute;

      public Command(Action<object> execute, Predicate<object> canExecute)
      {
			if(execute == null)
				throw new NullReferenceException("execute");

			_canExecute = canExecute;
         _executeMethod = execute;
      }

      public Command(Action<object> execute) : this(execute, null)
      {

      }

      public event EventHandler CanExecuteChanged
      {
         add
         {
            CommandManager.RequerySuggested += value;
         }
         remove
         {
            CommandManager.RequerySuggested -= value;
         }
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
