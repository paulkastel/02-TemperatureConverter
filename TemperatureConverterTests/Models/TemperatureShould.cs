using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperatureConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter.Models.Tests
{
	[TestClass()]
	public class TemperatureShould
	{
		[TestMethod()]
		public void WhatPhenomenonTest()
		{
			Temperature temperature = new Temperature();
			Assert.AreEqual("", temperature.WhatPhenomenon(18));
		}

		[TestMethod()]
		public void WhatPhenomenonTest1()
		{
			Temperature temperature = new Temperature();
			Assert.AreEqual("Średnia temperature ciała człowieka", temperature.WhatPhenomenon(310));
		}

		[TestMethod()]
		public void ChangeTemperatureFromKelvinToFarenheit()
		{
			Temperature temperature = new Temperature();
			temperature.ChangeTemperatureFromKelvin(273.15);
			Assert.AreEqual(32, temperature.Fahrenheit);
		}

		[TestMethod()]
		public void ChangeTemperatureFromKelvinToCelsius()
		{
			Temperature temperature = new Temperature();
			temperature.ChangeTemperatureFromKelvin(273.15);
			Assert.AreEqual(0, temperature.Celsius);
		}

		[TestMethod()]
		public void ChangeTemperatureFromCelsiusToKelvin()
		{
			Temperature temperature = new Temperature();
			temperature.ChangeTemperatureFromCelsius(0);
			Assert.AreEqual(273.15, temperature.Kelvin);
		}

		[TestMethod()]
		public void ChangeTemperatureFromCelsiusToFarenheit()
		{
			Temperature temperature = new Temperature();
			temperature.ChangeTemperatureFromCelsius(0);
			Assert.AreEqual(32, temperature.Fahrenheit);
		}

		[TestMethod()]
		public void ChangeTemperatureFromFarenheitToCelsius()
		{
			Temperature temperature = new Temperature();
			temperature.ChangeTemperatureFromFarenheit(-459.67);
			Assert.AreEqual(-273.15, temperature.Celsius);
		}

		[TestMethod()]
		public void ChangeTemperatureFromFarenheitToKelvin()
		{
			Temperature temperature = new Temperature();
			temperature.ChangeTemperatureFromFarenheit(-459.67);
			Assert.AreEqual(0, temperature.Kelvin);
		}
	}
}