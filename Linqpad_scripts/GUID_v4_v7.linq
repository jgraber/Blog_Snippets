<Query Kind="Statements" />

Console.WriteLine("UUID Version 4");
for(int i = 0; i < 10; i++)
	Console.WriteLine(Guid.NewGuid());
	Thread.Sleep(100);

Console.WriteLine("\n\nUUID Version 7");

for (int i = 0; i < 10; i++)
	Console.WriteLine(Guid.CreateVersion7());
	Thread.Sleep(100);
	

Console.WriteLine("\n\nSpecific date");
var lastYear = DateTime.Now;
var id = Guid.CreateVersion7(new DateTimeOffset(lastYear));
Console.WriteLine(id);

Guid guidFromString = Guid.Parse(id.ToString().ToArray());
Console.WriteLine(guidFromString);
Console.WriteLine(guidFromString.Version);


Console.WriteLine(ExtractDate(id));

DateTimeOffset ExtractDate(Guid uuid)
{
	// Get the UUID bytes in big-endian order
	var bytes = uuid.ToByteArray();

	// Convert to big-endian layout (UUID is stored in mixed-endian in .NET)
	var reordered = new byte[16];
	reordered[0] = bytes[3];
	reordered[1] = bytes[2];
	reordered[2] = bytes[1];
	reordered[3] = bytes[0];
	reordered[4] = bytes[5];
	reordered[5] = bytes[4];
	reordered[6] = bytes[7];
	reordered[7] = bytes[6];
	Array.Copy(bytes, 8, reordered, 8, 8);

	// Extract the first 6 bytes (48 bits) as the timestamp in milliseconds
	ulong timestamp = 0;
	for (int i = 0; i < 6; i++)
	{
		timestamp = (timestamp << 8) | reordered[i];
	}

	// Convert Unix milliseconds to DateTime (UTC)
	var dateTime = DateTimeOffset.FromUnixTimeMilliseconds((long)timestamp).UtcDateTime;
	return dateTime;
}