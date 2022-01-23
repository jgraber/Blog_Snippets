IEnumerable<int> numbers = Enumerable.Range(1, 10);

foreach (int num in numbers)
{
    Console.WriteLine(num);
}


Console.WriteLine("\n\n\n");


IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

foreach (int num in squares)
{
    Console.WriteLine(num);
}