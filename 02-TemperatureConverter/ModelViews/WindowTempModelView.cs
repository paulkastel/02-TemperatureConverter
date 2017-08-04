using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TemperatureConverter.Commands;
using TemperatureConverter.Models;

namespace TemperatureConverter.ModelViews
{
   public class WindowTempModelView : INotifyPropertyChanged
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

      //TODO: Napisać że powyżej pewnej temperatury występuje zjawisko: topnienie tytanu, slonca, etc.
      //TODO: Napisać w msgStatus info o zlych wartosciach
      //TODO: Kolor graidentu w zależnosci od wpisanej tempertury?
      private Temperature _temp;

      public Temperature Temperature
      {
         get { return _temp; }
         set
         {
            _temp = value;
         }
      }

      private string _messageStatus;
      public string MessageStatus
      {
         get
         {
            return _messageStatus;
         }
         private set
         {
            _messageStatus = value;
            OnPropertyChanged();
         }
      }

      public Command CountTempFromKelvin { get; }

      public Command showMsg { get; }

      public WindowTempModelView()
      {
         _temp = new Temperature();
         CountTempFromKelvin = new Command(ChangeTemperature, isItPossibleToChangeTemp);
         showMsg = new Command(ChangeTemperatureWithMessage);

      }

      public void ChangeTemperature(object temp)
      {
         _temp.ChangeTemperatureFromKelvin(double.Parse(temp.ToString()));
      }
      
      public void ChangeTemperatureWithMessage(object temp)
      {
         MessageStatus = "Przeliczyles Kelvina";
         System.Windows.MessageBox.Show(MessageStatus);
         _temp.ChangeTemperatureFromKelvin(double.Parse(temp.ToString()));
      }

      public bool isItPossibleToChangeTemp(object parameter)
      {
         double parsed;
         if (double.TryParse(parameter.ToString(), out parsed))
         {
            MessageStatus = string.Empty;
            return true;
         }
         else
         {
            MessageStatus = "Nie możesz przeliczyć podanej wartości!";
            return false;
         }
      }
   }
}
