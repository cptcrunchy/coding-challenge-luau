using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coding_Challenge_CSharp
{
	static class AmateurQuestions
	{
		public static bool Question1(string input)
		{
			var strippedInput = input.Where(char.IsLetter);
			if (strippedInput.All(char.IsUpper)) return true;
			if (strippedInput.All(char.IsLower)) return true;
			return false;
		}

		public static string Question2(int[] input)
		{
			int sum = 0;
			List<int> collector = new List<int>();

			for (int i = 0; i < input.Length; i++)
			{
				sum += input[i];
				collector.Add(sum);
			}
			return collector.Aggregate("", (a, b) => a + b + " ");
		}

		public static bool Question3(string input) => input.Distinct().Count() == input.Length;

		public static string Question4(string input)
		{
			Dictionary<char, int> PhonePad = new Dictionary<char, int>
			{
				{ 'a', 2 },
				{ 'b', 2 },
				{ 'c', 2 },
				{ 'd', 3 },
				{ 'e', 3 },
				{ 'f', 3 },
				{ 'g', 4 },
				{ 'h', 4 },
				{ 'i', 4 },
				{ 'j', 5 },
				{ 'k', 5 },
				{ 'l', 5 },
				{ 'm', 6 },
				{ 'n', 6 },
				{ 'o', 6 },
				{ 'p', 7 },
				{ 'q', 7 },
				{ 'r', 7 },
				{ 's', 7 },
				{ 't', 8 },
				{ 'u', 8 },
				{ 'v', 8 },
				{ 'w', 9 },
				{ 'x', 9 },
				{ 'y', 9 },
				{ 'z', 9 }
			};


			var numPairs = input.ToLower().Split("-");
			var convertedNums = new StringBuilder();

			foreach (var numPair in numPairs)
			{
				foreach(char c in numPair)
				{
					if(PhonePad.TryGetValue(c, out int numKey))
					{
						convertedNums.Append(numKey);
					}
					else
					{
						convertedNums.Append(char.GetNumericValue(c));
					}
				}
				convertedNums.Append("-");
			}
			return convertedNums.Remove(convertedNums.Length - 1, 1).ToString();
		}

	}
}
