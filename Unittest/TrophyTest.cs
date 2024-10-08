using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Obligatorisk_opgave_1_2;

namespace Unittest
{
	[TestClass]
	public class TrophyTest
	{
		private readonly Trophy _trophy = new() { Id = 1, Competition = "løb", Year = 1980 };
		private readonly Trophy _nullComp = new() { Id = 2, Year = 1895 };
		private readonly Trophy _shortComp = new() { Id = 3, Competition = "ti", Year = 2000 };
		private readonly Trophy _yearLow = new() { Id = 4, Competition = "fast", Year = 1969 };
		private readonly Trophy _yearHigh = new() { Id = 5, Competition = "løøb", Year = 2025 };

		[TestMethod]
		public void TestToString()
		{
			Assert.AreEqual("1, løb, 1980", _trophy.ToString());
		}
		[TestMethod]
		public void TestValidateCompetition()
		{
			_trophy.ValidateCompetition();
			Assert.ThrowsException<ArgumentNullException>(() => _nullComp.ValidateCompetition());
			Assert.ThrowsException<ArgumentException>(() => _shortComp.ValidateCompetition());
		}

		[TestMethod]
		public void ValidateYearTest()
		{
			_trophy.ValidateYear();
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _yearLow.ValidateYear());
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => _yearHigh.ValidateYear());

		}

		[TestMethod()]
		public void ValidateTest()
		{
			_trophy.validate();
			Assert.ThrowsException<ArgumentOutOfRangeException>(()=> _yearLow.validate());
			Assert.ThrowsException<ArgumentException>(() => _shortComp.validate());

		}

	}
}