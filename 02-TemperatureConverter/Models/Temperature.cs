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

		/// <summary>
		/// Class constructor - sets default values for zeros in proper scale
		/// </summary>
		public Temperature()
		{
			Celsius = 0;
			Fahrenheit = 32;
			Kelvin = 273.15;
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
				if(_celsius != value)
				{
					_celsius = value;
					OnPropertyChanged();
				}
			}
		}

		public double Fahrenheit
		{
			get { return _fahrenheit; }
			set
			{
				if(_fahrenheit != value)
				{
					_fahrenheit = value;
					OnPropertyChanged();
				}
			}
		}

		public double Kelvin
		{
			get { return _kelvin; }
			set
			{
				if(_kelvin != value)
				{
					_kelvin = value;
					OnPropertyChanged();
				}
			}
		}

		/// <summary>
		/// Converts temperature from Farenheit to other units
		/// </summary>
		/// <param name="temp">temperature in farenheit scale</param>
		public void ChangeTemperatureFromFarenheit(double temp)
		{
			Fahrenheit = Math.Round(temp, 3);
			Celsius = Math.Round((((temp + 40) / 1.8) - 40), 3);
			Kelvin = Math.Round((Celsius + 273.15), 3);
		}

		/// <summary>
		/// Converts temperature from Celsius to other units
		/// </summary>
		/// <param name="temp">temperature in celsius scale</param>
		public void ChangeTemperatureFromCelsius(double temp)
		{
			Kelvin = Math.Round((temp + 273.15), 3);
			Celsius = Math.Round(temp, 3);
			Fahrenheit = Math.Round((32 + (9 * temp) / 5), 3);
		}

		/// <summary>
		/// Converts temperature from Kelvins to other units
		/// </summary>
		/// <param name="temp">temperature in kelvin scale</param>
		public void ChangeTemperatureFromKelvin(double temp)
		{
			Kelvin = Math.Round(temp, 3);
			Celsius = Math.Round((temp - 273.15), 3);
			Fahrenheit = Math.Round((((Celsius + 40) * 1.8) - 40), 3);
		}

		/// <summary>
		/// Shows phenomenon description on passed temperature
		/// </summary>
		/// <param name="tempInK">temperature in kelvins</param>
		/// <returns>description of phenomenon</returns>
		public string WhatPhenomenon(double tempInK)
		{
			var temp = (int)tempInK;
			switch(temp)
			{
				case 0:
					return Properties.Resources.strAbsoluteZero;
				case 254:
				case 255:
					return Properties.Resources.strFarenheitZero;
				case 273:
					return Properties.Resources.strFrozenWater;
				case 309:
				case 310:
					return Properties.Resources.strAvgBodyTemperature;
				case 373:
					return Properties.Resources.strBoilingWater;
				case 1941:
					return Properties.Resources.strTitanMelting;
				case 5800:
					return Properties.Resources.strSunTemperature;
				default:
					return string.Empty;
			}
		}
	}
}