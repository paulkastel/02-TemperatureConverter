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
		//TODO: Walidacja kodu następuje w modelu
		//TODO: Stringi przenieść do resourców
		//TODO: Testy jednostkowe funkcji

		/// <summary>
		/// Model instance
		/// </summary>
		private Temperature _temp;

		public Temperature Temperature
		{
			get { return _temp; }
			set
			{
				_temp = value;
			}
		}

		/// <summary>
		/// Message displayed in window
		/// </summary>
		private string _messageStatus;

		public string MessageStatus
		{
			get
			{
				return _messageStatus;
			}
			private set
			{
				if(_messageStatus != value)
				{
					_messageStatus = value;
					OnPropertyChanged();
				}
			}
		}

		public Command CountTempFromKelvin { get; private set; }
		public Command CountTempFromFarenheit { get; private set; }
		public Command CountTempFromCelsius { get; private set; }

		/// <summary>
		/// Modelview constructor
		/// </summary>
		public WindowTempModelView()
		{
			_temp = new Temperature();
			CountTempFromKelvin = new Command(ChangeTemperatureK, isKelvinOK);
			CountTempFromCelsius = new Command(ChangeTemperatureC, isCelsiusOK);
			CountTempFromFarenheit = new Command(ChangeTemperatureF, isFarenheitOK);
		}

		public void ChangeTemperatureK(object temp)
		{
			MessageStatus = "Przeliczyles Kelvina";
			_temp.ChangeTemperatureFromKelvin(double.Parse(temp.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture));
		}

		public void ChangeTemperatureC(object temp)
		{
			MessageStatus = "Przeliczyles Celsiusa";
			_temp.ChangeTemperatureFromCelsius(double.Parse(temp.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture));
		}

		public void ChangeTemperatureF(object temp)
		{
			MessageStatus = "Obliczyles Farenheita";
			_temp.ChangeTemperatureFromFarenheit(double.Parse(temp.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture));
		}

		public bool isKelvinOK(object parameter)
		{
			if(parameter == null)
				return false;

			double parsed;
			if(double.TryParse(parameter.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out parsed))
			{
				if(parsed < 0)
				{
					MessageStatus = "Przekroczono zero bezględne w Kelvinach";
					return false;
				}
				else
					return true;
			}
			else
			{
				MessageStatus = "Nie możesz przeliczyć podanej wartości!";
				return false;
			}
		}

		public bool isCelsiusOK(object parameter)
		{
			if(parameter == null)
				return false;

			double parsed;
			if(double.TryParse(parameter.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out parsed))
			{
				if(parsed < -273.15)
				{
					MessageStatus = "Przekroczono zero bezwzględne w Celsiuszach";
					return false;
				}
				else
					return true;
			}
			else
			{
				MessageStatus = "Nie możesz przeliczyć podanej wartości!";
				return false;
			}
		}

		public bool isFarenheitOK(object parameter)
		{
			if(parameter == null)
				return false;

			double parsed;
			if(double.TryParse(parameter.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out parsed))
			{
				if(parsed < -459.67)
				{
					MessageStatus = "Przekroczono zero bezwględne w Farenheitach!";
					return false;
				}
				else
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
