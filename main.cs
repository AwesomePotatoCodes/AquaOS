using System;
using System.IO;

// sort all utilities into a single class
// making it easier to access functions and prevent code repetition
class Utils {
	public static string ReadFile(string path) {
		string text = File.ReadAllText(path);
		return text;
	}

	public static void SetColor(ConsoleColor color) {
		Console.ForegroundColor = color;
	}

	public static void Warning(string warning) {
		SetColor(ConsoleColor.DarkRed);
		Console.WriteLine($"[X] {warning}");
		SetColor(ConsoleColor.White);
	}
}

// system things, like variables and such
class AquaSys {
	public static void CommandInput() {
		Utils.SetColor(ConsoleColor.DarkBlue); Console.Write($"~/{AquaOS.username}");
		Utils.SetColor(ConsoleColor.White); Console.Write("$ ");
	}
	
	public static string core_partials = "core/partials/";
	public static string public_path = "public/user/";
	public static string helpList = Utils.ReadFile(core_partials+"COMMANDS.txt");
	public static string info = Utils.ReadFile(core_partials+"INFO.txt");
}

// main system things, functions and etc.
class AquaOS {
	public static string username = "username";

	public static void Main (string[] args) {
		string command, message;
		
		Console.Write("Username: ");
		username = Console.ReadLine();
		
		if (!username.Contains(" ")) {
			if (username.Length <= 10) {
				Environment.Exit(4); // username too long
			}
			username = username.ToLower();
		} else {
			Environment.Exit(3); // 3 means empty value
		}
		
		Console.Clear();
		Console.WriteLine("Use 'help' for info");

		while (true) {
			AquaSys.CommandInput();
			
			command = Console.ReadLine();
			command = command.ToLower();

			// process command
			// TODO: make this cleaner
			if (command=="help") {
				Console.WriteLine(AquaSys.helpList);
			} else if (command=="echo") {
				message = command.Substring(5);
				Console.WriteLine("ok");
			} else if (command=="exit") {
				Environment.Exit(0);
			} else if (command=="info") {
				Console.WriteLine(AquaSys.info);
			} else if (command=="clear") {
				Console.Clear();
			} else {
				Utils.Warning($"Command '{command}' not found.");
			}
		}
	}
}