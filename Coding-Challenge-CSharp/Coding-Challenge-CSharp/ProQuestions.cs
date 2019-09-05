using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Coding_Challenge_CSharp
{
	static class ProQuestions
	{
		public static IEnumerable<T[][]> GetAllPartitions<T>(T[] elements) => GetAllPartitions(new T[][] { }, elements);
		
		public static string Question2(string input)
		{
			var textGroups = input.GroupBy(c => c).Select(g => new { Letter = g.Key, Count = g.Count() });
			var starText = new StringBuilder();

			foreach (var textGroup in textGroups)
			{
				if (textGroup.Count > 1)
				{
					starText.Append(textGroup.Letter + "*" + textGroup.Count);
				}
				else
				{
					starText.Append(textGroup.Letter);
				}
			}
			return starText.ToString();
		}

		public static bool Question3(int num)
		{
			string input = Convert.ToString(num);
			string reverseInput = input.Aggregate(new StringBuilder(), (j, k) => j.Insert(0, k)).ToString();
			bool isPalindrome;

			if (input.Equals(reverseInput))
			{
				isPalindrome = true;
			}
			else
			{
				string[] pairs = (from Match m in Regex.Matches(input, "..") select m.Value).ToArray();
				List<int> intSums = new List<int>();
				foreach (var pair in pairs)
				{
					int sum = 0;
					foreach (char c in pair)
					{
						int n = (int)char.GetNumericValue(c);
						sum += n;
					}
					intSums.Add(sum);
				}
				string childSums = intSums.Aggregate("", (a, b) => a + b);
				string reverseChildSums = childSums.Aggregate(new StringBuilder(), (j, k) => j.Insert(0, k)).ToString();
				if (childSums.Equals(reverseChildSums))
				{
					isPalindrome = true;
				}
				else
				{
					isPalindrome = false;
				}
			}

			return isPalindrome;

		}

		public static bool Question4(string ipString) => IPAddress.TryParse(ipString, out _);
		
		public static string Question5(int n)
		{
			List<int> dp = new List<int>(n + 1);

			for (int i = 1; i <= n; i++)
			{
				dp.Add(FindGolomb(i));
			}

			string golombList = dp.Aggregate(" ", (a, b) => a + b + " ");

			return golombList;
		}

		public static int FindGolomb(int n) => n == 1 ? 1 : 1 + FindGolomb(n - FindGolomb(FindGolomb(n - 1)));

		private static IEnumerable<T[][]> GetAllPartitions<T>(T[][] fixedParts, T[] suffixElements)
		{
			yield return fixedParts.Concat(new[] { suffixElements }).ToArray();

			var suffixPartitions = GetTuplePartitions(suffixElements);
			foreach (Tuple<T[], T[]> suffixPartition in suffixPartitions)
			{
				var subPartitions = GetAllPartitions(fixedParts.Concat(new[] { suffixPartition.Item1 }).ToArray(), suffixPartition.Item2);
				foreach (var subPartition in subPartitions)
				{
					yield return subPartition;
				}
			}
		}

		private static IEnumerable<Tuple<T[],T[]>> GetTuplePartitions<T>(T[] elements)
		{
			if (elements.Length < 2) yield break;

			for(int pattern = 1; pattern < 1 << (elements.Length - 1); pattern++)
			{
				List<T>[] resultSets =
				{
					new List<T> { elements[0] }, new List<T>() };

				for(int i = 1; i < elements.Length; i++)
				{
					resultSets[(pattern >> (i - 1)) & 1].Add(elements[i]);
				}
				yield return Tuple.Create(resultSets[0].ToArray(), resultSets[1].ToArray());
			}
		}
	}
}
