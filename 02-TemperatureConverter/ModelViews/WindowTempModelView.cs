using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TemperatureConverter.Models;

namespace TemperatureConverter.ModelViews
{
   public class WindowTempModelView : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      private Temperature _temp;

      public Temperature Temperature
      {
         get { return _temp; }
         set
         {
            _temp = value;
            OnPropertyChanged();
         }
      }

      public WindowTempModelView()
      {
         _temp = new Temperature();
      }

      /// <summary>
      /// Responsible for refreshing UI when property changed its value
      /// </summary>
      /// <param name="propertyName"></param>
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
