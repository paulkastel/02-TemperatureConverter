using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemperatureConverter.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter.ModelViews.Tests
{
	[TestClass()]
	public class WindowTempModelViewShould
	{
		[TestMethod()]
		public void CheckifKelvinOK()
		{
			WindowTempModelView MV = new WindowTempModelView();
			var obj = 1000;
			Assert.IsTrue(MV.isKelvinOK(obj));
		}

		[TestMethod()]
		public void CheckifKelvinOK1()
		{
			WindowTempModelView MV = new WindowTempModelView();
			var obj = -5;
			Assert.IsFalse(MV.isKelvinOK(obj));
		}

		[TestMethod()]
		public void CheckifKelvinNULL()
		{
			WindowTempModelView MV = new WindowTempModelView();
			Assert.IsFalse(MV.isKelvinOK(null));
		}

		[TestMethod()]
		public void CheckifKelvinTxt()
		{
			WindowTempModelView MV = new WindowTempModelView();
			Assert.IsFalse(MV.isKelvinOK("text"));
		}

		[TestMethod()]
		public void CheckifCelsiusOK()
		{
			WindowTempModelView MV = new WindowTempModelView();
			var obj = 1000;
			Assert.IsTrue(MV.isCelsiusOK(obj));
		}

		[TestMethod()]
		public void CheckifCelsiusOK1()
		{
			WindowTempModelView MV = new WindowTempModelView();
			var obj = -300;
			Assert.IsFalse(MV.isCelsiusOK(obj));
		}

		[TestMethod()]
		public void CheckifCelsiusNULL()
		{
			WindowTempModelView MV = new WindowTempModelView();
			Assert.IsFalse(MV.isCelsiusOK(null));
		}

		[TestMethod()]
		public void CheckifCelsiustxt()
		{
			WindowTempModelView MV = new WindowTempModelView();
			Assert.IsFalse(MV.isCelsiusOK("txt"));
		}

		[TestMethod()]
		public void CheckifFarenheitOK()
		{
			WindowTempModelView MV = new WindowTempModelView();
			var obj = 100;
			Assert.IsTrue(MV.isFarenheitOK(obj));
		}

		[TestMethod()]
		public void CheckifFarenheitOK1()
		{
			WindowTempModelView MV = new WindowTempModelView();
			var obj = -500;
			Assert.IsFalse(MV.isFarenheitOK(obj));
		}
		[TestMethod()]
		public void CheckifFarenheitNULL()
		{
			WindowTempModelView MV = new WindowTempModelView();
			Assert.IsFalse(MV.isFarenheitOK(null));
		}

		[TestMethod()]
		public void CheckifFarenheittxt()
		{
			WindowTempModelView MV = new WindowTempModelView();
			Assert.IsFalse(MV.isFarenheitOK("txt"));
		}
	}
}