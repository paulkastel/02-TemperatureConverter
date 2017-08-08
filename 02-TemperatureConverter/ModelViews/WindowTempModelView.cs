using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
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

		//TODO: Kolor graidentu w zależnosci od wpisanej tempertury?

		private Temperature _temp;

		/// <summary>
		/// Model instance
		/// </summary>
		public Temperature Temperature
		{
			get { return _temp; }
			set
			{
				_temp = value;
			}
		}

		private string _messageStatus;

		/// <summary>
		/// Message displayed in window
		/// </summary>
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

		/// <summary>
		/// Change Kelvin temperature and change message status
		/// </summary>
		/// <param name="temp">Content from textbox</param>
		public void ChangeTemperatureK(object temp)
		{
			_temp.ChangeTemperatureFromKelvin(double.Parse(temp.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture));
			if(_temp.WhatPhenomenon(_temp.Kelvin) != string.Empty)
				MessageStatus = _temp.WhatPhenomenon(_temp.Kelvin);
			else
				MessageStatus = Properties.Resources.infoKelvinCounted;
		}

		/// <summary>
		/// Change Celsius temperature and change message status
		/// </summary>
		/// <param name="temp">Content from textbox</param>
		public void ChangeTemperatureC(object temp)
		{
			_temp.ChangeTemperatureFromCelsius(double.Parse(temp.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture));
			if(_temp.WhatPhenomenon(_temp.Kelvin) != string.Empty)
				MessageStatus = _temp.WhatPhenomenon(_temp.Kelvin);
			else
				MessageStatus = Properties.Resources.infoCelsiusCounted;
		}

		/// <summary>
		/// Change Farenheit temperatue and change message status
		/// </summary>
		/// <param name="temp">Content from textbox</param>
		public void ChangeTemperatureF(object temp)
		{
			_temp.ChangeTemperatureFromFarenheit(double.Parse(temp.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture));
			if(_temp.WhatPhenomenon(_temp.Kelvin) != string.Empty)
				MessageStatus = _temp.WhatPhenomenon(_temp.Kelvin);
			else
				MessageStatus = Properties.Resources.infoFarenheitCounted;
		}

		/// <summary>
		/// Checks whether user can change Kelvin temperature
		/// </summary>
		/// <param name="parameter">content from textbox</param>
		/// <returns>true if Command can be executed</returns>
		public bool isKelvinOK(object parameter)
		{
			if(parameter == null)
				return false;

			double parsed;
			if(double.TryParse(parameter.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out parsed))
			{
				if(parsed < 0)
				{
					MessageStatus = Properties.Resources.errAbsoluteZero;
					return false;
				}
				else
					return true;
			}
			else
				return false;
		}

		/// <summary>
		/// Chcecks whether user can change Celsius temperature
		/// </summary>
		/// <param name="parameter">content from textbox</param>
		/// <returns>true if Command can be executed</returns>
		public bool isCelsiusOK(object parameter)
		{
			if(parameter == null)
				return false;

			double parsed;
			if(double.TryParse(parameter.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out parsed))
			{
				if(parsed < -273.15)
				{
					MessageStatus = Properties.Resources.errAbsoluteZero;
					return false;
				}
				else
					return true;
			}
			else
				return false;
		}

		/// <summary>
		/// Checks whether user can change Farenheit temperature
		/// </summary>
		/// <param name="parameter">content from textbox</param>
		/// <returns>true if Command can be executed</returns>
		public bool isFarenheitOK(object parameter)
		{
			if(parameter == null)
				return false;

			double parsed;
			if(double.TryParse(parameter.ToString(), System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out parsed))
			{
				if(parsed < -459.67)
				{
					MessageStatus = Properties.Resources.errAbsoluteZero;
					return false;
				}
				else
					return true;
			}
			else
				return false;
		}
	}
}
