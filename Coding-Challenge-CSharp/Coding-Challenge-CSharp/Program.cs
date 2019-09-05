using System;

namespace Coding_Challenge_CSharp
{
	static class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Professional Questions");
			var pq1 = ProQuestions.GetAllPartitions(new[] { 1, 5, 3, 2 });
			Console.WriteLine("Question 1: {0}", pq1);
			var pq2 = ProQuestions.Question2("zmmxxxy");
			Console.WriteLine("Question 2: {0}",pq2);
			var pq3 = ProQuestions.Question3(121113);
			Console.WriteLine("Question 3: {0}", pq3);
			var pq4 = ProQuestions.Question4("0.0.0.256");
			Console.WriteLine("Question 4: {0}", pq4);
			var pq5 = ProQuestions.Question5(15);
			Console.WriteLine("Question 5: [{0}]", pq5);
			Console.WriteLine();
			Console.WriteLine("Amateur Questions");
			var aq1 = AmateurQuestions.Question1("HELLo wORLD");
			Console.WriteLine("Question 1: {0}", aq1);
			var aq2 = AmateurQuestions.Question2(new[] { 1, 1, 1 });
			Console.WriteLine("Question 2: {0}", aq2);
			var aq3 = AmateurQuestions.Question3("color");
			Console.WriteLine("Question 3: {0}", aq3);
			var aq4 = AmateurQuestions.Question4("TRY-THE-FOOD");
			Console.WriteLine("Question 4: {0}", aq4);
		}
	}
}
