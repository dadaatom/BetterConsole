# BetterConsole
Better console with prebuilt functionalities and offers improved display tools. Implements a ConsoleCommand framework so that new user defined commands can easily be added and executed.

# Usage
## Creating the BetterConsole
First, let's create an instance of the `BetterConsole` class. 
```
BetterConsole console = new BetterConsole();
```
By default the BetterConsole will only reload up to 1000 console lines, as depending on the implmentation reloads may occur frequently and adding a limit may improve preformance. Here's another constructor call where our implementation may contain very frequent reloads.
```
BetterConsole console = new BetterConsole(displayLimit = 100);
```
## Simple console commands
Read, write, and clear functions are all present as before.
```
console.WriteLine("This is a line of text.");
console.Write("Here's some more text.");
console.Clear();
console.Write("Enter some text: ");
string text = console.ReadLine();
```
Using the write methods of the console will register them internally so written lines can be modified and updated within the console.
Call the reload method to clear and redisplay all console lines.
```
console.Reload();
```
## Console Components
Console components can be described as linked lists where each node is a portion of text in a console line. The Write and WriteLine methods also accept console components.
## Text Component
Let's write a text component in the color green.
```
TextComponent text = new TextComponent("This will appear green!");
text.SetColor(ConsoleColor.Green);
console.WriteLine(text);
```
Alternatively, for plain text it's easier to use the method below.
```
console.WriteLine("This will also appear green!", ConsoleColor.Green);
```
## Loading Bars
Let's now create a loading bar to display the execution process of our program. Whilst optional, I am going to select different style options below.
```
LoadingBarStyle style = new LoadingBarStyle("-", "~", "<", ">");
```
We will now call the loading bar constructor with the style and length, then write the resulting loading bar to the console.
```
LoadingBar loadingBar = new LoadingBar(style, 10);
console.WriteLine("Execution process: ");
console.Write(loadingBar);
```
Great, now all we need to do is provide our loading bar with its progress percentage. Note that input values to the SetPercentage method are automatically bounded between 0 and 1.
```
for (int i = 0; i <= n; i++) {
    //Do stuff.
    loadingBar.SetPercentage(i*(1/n));
}
```
## Time Components [WIP]
There are several types of time components including countdown and timer components.

Let's create a timer to display the execution time of our program.
```
Timer timer = new Timer();
timer.Start();

console.WriteLine("Current execution duration: ");
console.Write(timer);
```

## Custom Commands
Creating custom console commands is easy, let's make a simple `PingCommand` class below. We just need to extend the `ConsoleCommand` class and to be sure to override the Execute method.
```
public class PingCommand : ConsoleCommand
{
    public PingCommand() : base("ping", new string[]{"p"}, "Pings the console for a response.") { }

    public override void Execute(string[] signature)
    {
        Console.WriteLine("pong");
    }
}
```
Great, now all we need to do is add this command to the console's command registry and begin command handling. The `BeginCommandHandling` method creates a new thread to handle incoming user inputs so new content can still be output to the console.
```
console.AddCommand(new PingCommand()):
console.BeginCommandHandling();
```

# Incoming Features
- Figlet text
- Preset style choices
- Time component implementation
- Preformance improvements
