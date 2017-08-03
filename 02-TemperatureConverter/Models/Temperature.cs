using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter.Models
{
   public class Temperature
   {
      private double _celsius;

      private double _fahrenheit;

      private double _kelvin;

      public Temperature()
      {
         _celsius = 0;
         _fahrenheit = 32; 
         _kelvin = 273.15;
      }

      public double Celsius
      {
         get { return _celsius; }
         set
         {
            _celsius = value;
         }
      }

      public double Fahrenheit
      {
         get { return _fahrenheit; }
         set
         {
            _fahrenheit = value;
         }
      }

      public double Kelvin
      {
         get { return _kelvin; }
         set
         {
            _kelvin = value;
         }
      }
   }
}
