## Answers to Amateur Questions in C#

### Question 1

Write a function that takes a string and returns _true_ if all of the chracters are the same case,
_false_ otherwise.

### Question 1 Answer

``` csharp
public static bool Question1(string input)
{
	var strippedInput = input.Where(char.IsLetter);
	if (strippedInput.All(char.IsUpper)) return true;
	if (strippedInput.All(char.IsLower)) return true;
	return false;
}
```

### Question 2

Write a function that takes an array of integers and returns an array of integers where each number is
the sum of itself and all of the previous numbers in the array.

### Question 2 Answer

``` csharp
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
```

### Question 3

An Isogram is a word that has no repeating letters, consecutive or not. Write a function that takes
a string and returns _true_ if it's an isogram and _false_ if it isn't.

### Question 3 Answer

``` csharp
public static bool Question3(string input) => input.Distinct().Count() == input.Length;
```

### Question 4

Write a function that takes a phone number with letters in it and converts it to one with only numbers.
All input phone numbers will follow this pattern: "###-###-####" (Hint: Search for "phone keypad")

### Question 4 Answer

``` csharp
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
```

### Question 5

Write a function that calculates the Golomb sequence to the _nth_ term. The Golomb sequence is a
non-decreasing sequence of integers where a(n) is the total amount of times that _n_ appears in the 
sequence, beginning with a(1) = 1. The equation to find the next number in the sequence is as follows:

### Question 5 Answer

``` csharp
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
```