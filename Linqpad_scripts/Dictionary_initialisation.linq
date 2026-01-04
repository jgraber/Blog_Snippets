<Query Kind="Statements" />

var dictAdd = new Dictionary<string, string> {
	{"A", "Hello"},
	{"B", "World"},
	{"C", ".Net" }
};

var dictIndex = new Dictionary<string, string> {
	["A"] = "Hello",
	["B"] = "World",
	["C"] = ".Net" 
};

Console.WriteLine(dictAdd);
Console.WriteLine(dictIndex);


//var dictAddDouble = new Dictionary<string, string> {
//	{"A", "Hello"},
//	{"B", "World"},
//	{"B", ".Net" }
//};

var dictIndexDouble = new Dictionary<string, string>
{
	["A"] = "Hello",
	["B"] = "World",
	["B"] = ".Net"
};

//Console.WriteLine(dictAddDouble);
Console.WriteLine(dictIndexDouble);