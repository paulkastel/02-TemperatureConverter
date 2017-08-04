using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter.Models
{
   public class Temperature : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;
      /// <summary>
      /// Responsible for refreshing UI when property changed its value
      /// </summary>
      /// <param name="propertyName"></param>
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      public Temperature()
      {
         Celsius = 0;
         Fahrenheit = 32;
         Kelvin = 273;
      }
      
      private double _celsius;

      private double _fahrenheit;

      private double _kelvin;

      public enum TemperatureScale { Celsius, Fahrenheit, Kelvin };

      public double Celsius
      {
         get { return _celsius; }
         set
         {
            _celsius = value;
            OnPropertyChanged();
         }
      }

      public double Fahrenheit
      {
         get { return _fahrenheit; }
         set
         {
            _fahrenheit = value;
            OnPropertyChanged();
         }
      }

      public double Kelvin
      {
         get { return _kelvin; }
         set
         {
            _kelvin = value;
            OnPropertyChanged();
         }
      }

      public bool ChangeTempe(double temp, TemperatureScale which)
      {
         switch (which)
         {
            case TemperatureScale.Celsius:
               _celsius = temp;
               _kelvin = temp + 273;
               _fahrenheit = temp - 32;
               AllTemperaturesUpdated();

               return true;
            case TemperatureScale.Fahrenheit:
               _kelvin = temp;
               _celsius = temp - 273;
               _fahrenheit = temp + 73;
               AllTemperaturesUpdated();

               return true;
            case TemperatureScale.Kelvin:
               _fahrenheit = temp;
               _celsius = temp - 322;
               _kelvin = temp + 2;
               AllTemperaturesUpdated();
               return true;
            default:
               return false;
         }
      }

      private void AllTemperaturesUpdated()
      {
         OnPropertyChanged("Farenheit");
         OnPropertyChanged("Celsius");
         OnPropertyChanged("Kelvin");
      }

      public void ChangeTemperatureFromKelvin(double temp)
      {
         _kelvin = temp;
         _celsius = temp - 270;
         _fahrenheit = temp + 470;
         OnPropertyChanged("Farenheit");
         OnPropertyChanged("Celsius");
         OnPropertyChanged("Kelvin");
      }
   }
}
