using System;
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
		public void should_return_1_with_I()
		{
			var result = _romanNumberalsConverter.toNumber("I");
			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public void should_return_2_with_II()
		{
			var result = _romanNumberalsConverter.toNumber("II");
			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void should_return_4_with_IV()
		{
			var result = _romanNumberalsConverter.toNumber("IV");
			Assert.That(result, Is.EqualTo(4));
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
		public void should_return_400_with_CD()
		{
			var result = _romanNumberalsConverter.toNumber("CD");
			Assert.That(result, Is.EqualTo(400));
		}

		[Test]
		public void should_return_506_with_DVI()
		{
			var result = _romanNumberalsConverter.toNumber("DVI");
			Assert.That(result, Is.EqualTo(506));
		}

		[Test]
		public void should_return_506_with_CM()
		{
			var result = _romanNumberalsConverter.toNumber("CM");
			Assert.That(result, Is.EqualTo(900));
		}

		[Test]
		public void should_return_1202_with_MCCII()
		{
			var result = _romanNumberalsConverter.toNumber("MCCII");
			Assert.That(result, Is.EqualTo(1202));
		}

		[Test]
		public void should_return_XLIX_for_49()
		{
			var result = _romanNumberalsConverter.toNumber("XLIX");
			Assert.That(result, Is.EqualTo(49));
		}

		[Test]
		public void should_return_99_for_XCIX()
		{
			var result = _romanNumberalsConverter.toNumber("XCIX");
			Assert.That(result, Is.EqualTo(99));
		}

		[Test]
		public void should_return_1999_for_bbc()
		{
			var result = _romanNumberalsConverter.toNumber("MCMXCIX");
			Assert.That(result, Is.EqualTo(1999));
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
			var numeralList = splitStringToList(romanNumberal);

			var total = 0;
			for (int i = 0; i < numeralList.Count(); i++)
			{
				total += getNumericalValueOfNumeral(numeralList, i);
			}

			return total;
		}

		private IList<string> splitStringToList(string source)
		{
			var charArray = source.ToArray();
			return charArray.Select(c => c.ToString()).ToList();
		}

		private int getNumericalValueOfNumeral(IList<string> numerals, int position)
		{
			var numericalValue = _numeralToNumberMapping[numerals[position]];

			if (position != 0)
			{
				var previousValue = _numeralToNumberMapping[numerals[position - 1]];
				if (previousValue < numericalValue)
				{
					numericalValue -= previousValue;
				}
			}

			if (position != numerals.Count() - 1)
			{
				var nextValue = _numeralToNumberMapping[numerals[position + 1]];
				if (nextValue > numericalValue)
				{
					numericalValue = 0;
				}
			}
			return numericalValue;
		}

		private static void Main(string[] args)
		{
		}


	}



}
