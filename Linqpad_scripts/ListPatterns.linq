<Query Kind="Statements" />

int[] numbers = [1, 2, 3];

// Does not work:
// CS0019 Operator '==' cannot be applied to operands of type 'int[]' and 'collection expressions'
//if (numbers == [1, 2, 3])
//{
//	Console.WriteLine("Exact match");
//}

if (numbers is [1, 2, 3])
{
	Console.WriteLine("Exact match");
}

if (numbers is [1, ..])
{
	Console.WriteLine("Starts with 1");
}

if (numbers is [.., 3])
{
	Console.WriteLine("Ends with 3");
}

if (numbers is [1, .., 3])
{
	Console.WriteLine("Starts with 1 and ends with 3");
}

if (numbers is [_, .., 3])
{
	Console.WriteLine("Has at least one element before it ends with 3");
}

int[] small = [8,3];
if (small is [_, .., 3])
{
	Console.WriteLine("Has at least one element before it ends with 3");
}