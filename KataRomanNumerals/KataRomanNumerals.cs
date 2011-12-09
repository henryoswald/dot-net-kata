using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KataRomanNumerals
{
	[TestFixture]
	public class RomanNumberalsConverterTests
	{
		RomanNumberalsConverter _romanNumberalsConverter;

		[SetUp]
		public void SetUp()
		{
			_romanNumberalsConverter = new RomanNumberalsConverter();
		}

		[Test]
		public void should_return_7_with_VII()
		{
			var result = _romanNumberalsConverter.toNumber("VII");
			Assert.That(result, Is.EqualTo(7));
		}

		[Test]
		public void should_return_12_with_XII()
		{
			var result = _romanNumberalsConverter.toNumber("XII");
			Assert.That(result, Is.EqualTo(12));
		}

		[Test]
		public void should_return_55_with_LV()
		{
			var result = _romanNumberalsConverter.toNumber("LV");
			Assert.That(result, Is.EqualTo(55));
		}

		[Test]
		public void should_return_101_with_CI()
		{
			var result = _romanNumberalsConverter.toNumber("CI");
			Assert.That(result, Is.EqualTo(101));
		}

		[Test]
		public void should_return_506_with_DVI()
		{
			var result = _romanNumberalsConverter.toNumber("DVI");
			Assert.That(result, Is.EqualTo(506));
		}

		[Test]
		public void should_return_1202_with_MCCII()
		{
			var result = _romanNumberalsConverter.toNumber("MCCII");
			Assert.That(result, Is.EqualTo(1202));
		}
	}

	public class RomanNumberalsConverter
	{
		private readonly Dictionary<string, int> _numeralToNumberMapping = new Dictionary<string, int>
				{
					{"I", 1},
					{"V", 5},
					{"X", 10},
					{"L", 50},
					{"C", 100},
					{"D", 500},
					{"M", 1000}
				};

		public int toNumber(string romanNumberal)
		{
			romanNumberal = romanNumberal.ToUpper();
			return romanNumberal.Sum(c => _numeralToNumberMapping[c.ToString()]);
		}

		private static void Main(string[] args)
		{
		}
	}



}
