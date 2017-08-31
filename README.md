# Prize Draw
We have been asked by a large online retailer to develop an application for calculating the total prize monies given out as a result of a sales campaign.

The campaign takes the form of a series of prize draws over a number of days with the following rules:

-	Every order that is placed is automatically entered into the draw
-	At the end of every day, two orders are selected from all those entered into the draw
-	Firstly, the order for the largest amount is selected
-	Secondly, the order for the smallest amount is selected
-	The customer who placed the largest order receives prize money equal to the amount of their order less the amount of the smallest order
-	The two selected orders are removed from the draw
-	All other orders remain eligible for draws on subsequent days

Due to the size of the retailer you can assume that there will always be at least two orders in each draw.

Write a C# program, which reads (from standard input) a list of order amounts for each day of the campaign calculates the total prize money amount over the whole campaign and writes it to standard output.

## Input Format
The first line of the input contains the duration of the campaign in days as a single positive integer d (1 <= d <= 5000). The next d lines each consist of a list of non-negative integers separated by single spaces. 

The integers in the (i+1)th line are the details of the orders placed on the ith day of the campaign. 

The first integer in each line is r, the number of orders placed that day, where 0 <= r <= 100000. The next r numbers are positive integers - the amounts of each order. No amount is larger than 1000000.

The total number of orders placed during the whole campaign does not exceed 1000000.

## Output
The output must contain exactly one integer, equal to the total prize money given out during the whole campaign.
All integers in the input/output are encoded as ASCII characters.

## Example
Input:

5

3 1 2 3

2 1 1

4 10 5 5 1

0

1 2

Output:

19

