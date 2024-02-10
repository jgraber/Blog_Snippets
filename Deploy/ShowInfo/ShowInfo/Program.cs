// old cmd: dotnet publish --self-contained --runtime ubuntu.20.04-x64 =>  See https://aka.ms/netsdk1083
// new cmd: dotnet publish --self-contained --runtime linux-x64

Console.WriteLine($".Net version: \t{Environment.Version}");
Console.WriteLine($"OS version: \t{Environment.OSVersion}");
Console.WriteLine($"Machine name: \t{Environment.MachineName}");
Console.WriteLine($"Command: \t{Environment.CommandLine}");