<Query Kind="Statements" />

//var result = Combine(null, null, null);
//var result = Combine2("", "", " ");
var result = Combine("", "a", " ");
Console.WriteLine(result);


string Combine(string address, string city, string zipCode)
{
	if(address == null)
	{
		throw new ArgumentNullException(nameof(address));
	}
	if(String.IsNullOrEmpty(city))
	{
		throw new ArgumentNullException(nameof(city));
	}
	if(String.IsNullOrWhiteSpace(zipCode))
	{
		throw new ArgumentNullException(nameof(zipCode));
	}
	
	// Do the work
	return $"{address} - {zipCode} {city}";
}


string Combine2(string address, string city, string zipCode)
{
	ArgumentNullException.ThrowIfNull(address);
	ArgumentNullException.ThrowIfNullOrEmpty(city);
	ArgumentNullException.ThrowIfNullOrWhiteSpace(zipCode);

	// Do the work
	return $"{address} - {zipCode} {city}";
}