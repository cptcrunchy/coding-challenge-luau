# Coding Challenge Professional

## Professional Questions

### Question 1

Write a function that returns all possible partitions of an array from left to right.
With an _n_ amount of elements in the input the returned array should have _n-1_ subarrays.
An empty array should return an empty array.

### Question 2

Write a function to return a string in star shorthand. If a chacacter is repeated n amount of times,
convert the character _x_ into _x_*_n_. Leave single characters alone. An empty string should return
an empty string.

### Question 3

Even if a number is not a palindrome, one of the number's descendants may be. A number's descendant
can be found by adding each pair of adjacent digits together to make the digits of the next number.
Write a function that returns _true_ if the input number or any of its descendants down to 2 digits
is a palindrome, return _false_ otherwise. Your input will always have an even number of digits.
if there is a single number trailing after addition leave it.

### Question 4

An IPv4 formatted address contains 4 integers ranging from 0 to 255 separated by periods (.).
Write a function that takes a string as input and returns _true_ if the string is a valid IPv4 address.
Return _false_ otherwise.

### Question 5

Write a function that calculates the Golomb sequence to the _nth_ term. The Golomb sequence is a
non-decreasing sequence of integers where a(n) is the total amount of times that _n_ appears in the 
sequence, beginning with a(1) = 1. The equation to find the next number in the sequence is as follows:
```
_a(n + 1) = 1 + a(n + 1 - a(a(n)))_
```


## Amateur Questions

### Question 1

Write a function that takes a string and returns _true_ if all of the chracters are the same case,
_false_ otherwise.

### Question 2

Write a function that takes an array of integers and returns an array of integers where each number is
the sum of itself and all of the previous numbers in the array.

### Question 3

An Isogram is a word that has no repeating letters, consecutive or not. Write a function that takes
a string and returns _true_ if it's an isogram and _false_ if it isn't.

### Question 4

Write a function that takes a phone number with letters in it and converts it to one with only numbers.
All input phone numbers will follow this pattern: "###-###-####" (Hint: Search for "phone keypad")
