## Answers to Professional Questions in Python

### Question 1

Write a function that returns all possible partitions of an array from left to right.
With an _n_ amount of elements in the input the returned array should have _n-1_ subarrays.
An empty array should return an empty array.

### Question 1 Answer

``` python
### Question 1
def part(x):
    #Create a range iterater that goes from 1 - Length(list)
    l = range(1,len(x))
​
    #A For loop which lasts the length of the range above
    #First iter of loop takes a slice of just the first element. And a slice of everything else
    #Second iter takes first 2, then everything else.
    return [[x[:i],x[i:]]for i in l]
```

### Question 2

Write a function to return a string in star shorthand. If a chacacter is repeated n amount of times,
convert the character _x_ into _x_*_n_. Leave single characters alone. An empty string should return
an empty string.

### Question 2 Answer

``` python
def starformat(string):
    #Turn String into a list (array) of Chars
    slist = [c for c in string]
​
    #newstr will be the string that we build and return
    newstr = ''
​
    #counter counts how many times we have seen a letter consecutively
    counter = 1
​
    #Previous character seen. Used to check for consecutive chars
    lastchar = ''
​
    #For loop which goes the duration of the list (array)
    for i in range(len(slist)):
​
        #Grabs first element of list and assigns it to current char
        curchar = slist.pop(0)
​
        #if that char is the same as the last char. counter goes up
        if curchar == lastchar:
            counter+=1
​
        #
        else:
            #Adds 1 copy of the previous char if there was only 1 counter
            if counter ==1:
                newstr+=lastchar
                #Resets counter to 1
                counter =1
            #Adds That char and a multiplier based on the counter that is greater than 1
            else:
                newstr+=f'{counter}*{lastchar}'
                counter = 1
        # Assigns lastchar to curchar before grabbing the next 'curchar'
        lastchar = curchar
​
    #Does the same as the above code. But it is outside of the loop for the last char
    if counter ==1:
        newstr+=lastchar
        counter =1
    else:
        newstr+=f'{counter}*{lastchar}'
        counter = 1
​
    return newstr
```

### Question 3

Even if a number is not a palindrome, one of the number's descendants may be. A number's descendant
can be found by adding each pair of adjacent digits together to make the digits of the next number.
Write a function that returns _true_ if the input number or any of its descendants down to 2 digits
is a palindrome, return _false_ otherwise. Your input will always have an even number of digits.
if there is a single number trailing after addition leave it.

### Question 3 Answer

``` python
def pali(num):
    return str(num) == str(num)[::-1]
​
def decend(num):
    #Turn that number into a char list(array)
    x = [c for c in str(num)]
​
    #Creates an empty leftover string which will be filled up if there is an odd number of digits
    leftover = ''
​
    #if odd number of digits. grab the final digit to hold for later.
    if len(x)%2 == 1:
        leftover = x.pop()
​
    #loops over a range that is 1/2 the size of the remaining digits.
    #For each iter of the loop it grabs the next 2 digits. Adds them together then adds that new number to a list(array)
    #Then it smooshes the list together into a string
    #Adds the leftover digit to that string
    return ''.join([str(int(x[i*2]) + int(x[i*2 + 1])) for i in range(len(x)//2)]) + leftover
​
def dpali(num):
    #If the number is palidrome return true
    if pali(num):
        return True
​
    #Else if the Decendent of the number is a paladrome, return true
    while len(str(num)) > 2:
        num = decend(num)
        #print(num)   # Prints the decendent step, helpful for seeing the trickle down
        if pali(num):
            return True
    return False
```

### Question 4

An IPv4 formatted address contains 4 integers ranging from 0 to 255 separated by periods (.).
Write a function that takes a string as input and returns _true_ if the string is a valid IPv4 address.
Return _false_ otherwise.

### Question 4 Answer

``` python
def isIPV4(string):
​
    #Breaks the ip address into an list (array) of strings seperated by the '.'
    ip = string.split('.')
​
    #if the length of that list (array) Not a valid IP
    if len(ip) != 4:
        return False
​
    #if any piece of the ip address is longer than 3 digits, it's not a valid IP address
    for piece in ip:
        if len(piece) > 3:
            return False
​
​
    for piece in ip:
​
        #Tries to turn the pieces into integers. If it fails. Not a valid IP
        #If it successfully turns them into integers, but the int is >255 or less than 0. not a valid IP
        try:
            if int(piece) >255 or int(piece)<0:
                return False
​
        except:
            return False
​
​
    #If it made it through all the tests and didn't fail. Its a valid IP
    return True
```

### Question 5

Write a function that calculates the Golomb sequence to the _nth_ term. The Golomb sequence is a
non-decreasing sequence of integers where a(n) is the total amount of times that _n_ appears in the 
sequence, beginning with a(1) = 1. The equation to find the next number in the sequence is as follows:

### Question 5 Answer

``` python
def golomb(n):
​
    #Recursive function Base Case
    if n == 1:
        return 1
    #Non Base case (take the formula from the paper. and subtract 1 from all the n)
    return 1 + golomb(n - golomb(golomb(n - 1)))
​
​
#This just loops through all the piece of the golomb, and adds each piece to a list to be returned
def seq_golomb(n):
​
    return [golomb(i) for i in range(1, n + 1)]
```