## Answers to Professional Questions in C#

### Question 1

Write a function that returns all possible partitions of an array from left to right.
With an _n_ amount of elements in the input the returned array should have _n-1_ subarrays.
An empty array should return an empty array.

### Question 1 Answer

``` csharp
public static IEnumerable<T[][]> GetAllPartitions<T>(T[] elements) => GetAllPartitions(new T[][] { }, elements);
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
	List<T>[] resultSets ={ new List<T> { elements[0] }, new List<T>() };
        for(int i = 1; i < elements.Length; i++)
	{
	    resultSets[(pattern >> (i - 1)) & 1].Add(elements[i]);
	}
            yield return Tuple.Create(resultSets[0].ToArray(), resultSets[1].ToArray());
    }
}
```

### Question 2

Write a function to return a string in star shorthand. If a chacacter is repeated n amount of times,
convert the character _x_ into _x_*_n_. Leave single characters alone. An empty string should return
an empty string.

### Question 2 Answer

``` csharp
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
```

### Question 3

Even if a number is not a palindrome, one of the number's descendants may be. A number's descendant
can be found by adding each pair of adjacent digits together to make the digits of the next number.
Write a function that returns _true_ if the input number or any of its descendants down to 2 digits
is a palindrome, return _false_ otherwise. Your input will always have an even number of digits.
if there is a single number trailing after addition leave it.

### Question 3 Answer

``` csharp
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
```

### Question 4

An IPv4 formatted address contains 4 integers ranging from 0 to 255 separated by periods (.).
Write a function that takes a string as input and returns _true_ if the string is a valid IPv4 address.
Return _false_ otherwise.

### Question 4 Answer

``` csharp
public static bool Question4(string ipString) => IPAddress.TryParse(ipString, out _);
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