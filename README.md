# BetterConsole
Better console with prebuilt functionalities and offers improved display tools. Implements a ConsoleCommand framework so that user defined commands can easily be added and handled.

# Usage
## Creating the BetterConsole
First, let's create an instance of the `BetterConsole` class. 
```csharp
BetterConsole console = new BetterConsole();
```
By default the BetterConsole will only reload up to 1000 console lines, as depending on the implmentation reloads may occur frequently and adding a limit may improve preformance. Here's another constructor call where our implementation may contain very frequent reloads.
```csharp
BetterConsole console = new BetterConsole(displayLimit = 100);
```
## Simple console commands
Read, write, and clear functions are all present as before.
```csharp
console.WriteLine("This is a line of text.");
console.Write("Here's some more text.");
console.Clear();
console.Write("Enter some text: ");
string text = console.ReadLine();
```
Using the write methods of the console will register them internally so written lines can be modified and updated within the console.
Call the reload method to clear and redisplay all console lines.
```csharp
console.Reload();
```
## Console Components
Console components can be described as linked lists where each node is a portion of text in a console line. The Write and WriteLine methods also accept console components.
## Text Components
Let's write a text component in the color green.
```csharp
TextComponent text = new TextComponent("This will appear green!");
text.SetColor(ConsoleColor.Green);
console.WriteLine(text);
```
Alternatively, for plain text the regular Console methods are implemented to make usage easier.
```csharp
console.WriteLine("This will also appear green!", ConsoleColor.Green);
```
## Loading Bars
Let's now create a loading bar to display the execution process of our program. Whilst optional, I am going to select different style options below.
```csharp
LoadingBarStyle style = new LoadingBarStyle("-", "~", "<", ">");
```
We will now call the loading bar constructor with the style and length, then write the resulting loading bar to the console.
```csharp
LoadingBar loadingBar = new LoadingBar(style, 10);
console.WriteLine("Execution process: ");
console.Write(loadingBar);
```
Great, now all we need to do is provide our loading bar with its progress percentage. Note that input values to the SetPercentage method are automatically bounded between 0 and 1.
```csharp
for (int i = 0; i <= n; i++) {
    //Do stuff.
    loadingBar.SetPercentage(i*(1/n));
}
```
## Tables
Tables are handy for organizing and displaying information. They are able to support multiline strings of varying lengths.

Example: two friends want to track how many pets they each saw throughout the day, let's help them display this important information in a table.
First we will create a 3x3 table and label the columns appropriately.
```csharp
Table table = new Table(3,3);
            
table.SetCell(new Cell("Tom"),0,1);
table.SetCell(new Cell("John"),0,2);

table.SetCell(new Cell("Dogs"),1,0);
table.SetCell(new Cell("Cats"),2,0);
```
Good job, now we can fill the inner cells with their data and have the console write the table.
```csharp
table.SetCell(new Cell("10"),1,1);
table.SetCell(new Cell("2"),1,2);
table.SetCell(new Cell("6"),2,1);
table.SetCell(new Cell("9"),2,2);

console.Write(table);
```
Let's say one of the friends saw a cool bird, let's resize the table, add the new data, and finally reload the console.
```csharp
table.Resize(4,3);
            
table.SetCell(new Cell("Cool\nBird"),3,0);
table.SetCell(new Cell("1"),3,1);
table.SetCell(new Cell("0"),3,2);
            
console.Reload();
```

## Time Components [WIP]
There are several types of time components including countdown and timer components.

Let's create a timer to display the execution time of our program.
```csharp
Timer timer = new Timer();
timer.Start();

console.WriteLine("Current execution duration: ");
console.Write(timer);
```

## Custom Commands
Creating custom console commands is easy, let's make a simple `PingCommand` class below. We just need to extend the `ConsoleCommand` class and to be sure to override the Execute method.
```csharp
public class PingCommand : ConsoleCommand
{
    public PingCommand() : base("ping", new string[]{"p"}, "Pings the console for a response.") { }

    public override void Execute(string[] signature)
    {
        BetterConsole.Instance.WriteLine("pong");
    }
}
```
Great, now all we need to do is add this command to the console's command registry and begin command handling. The `BeginCommandHandling` method creates a new thread to handle incoming user inputs so new content can still be output to the console.
```csharp
console.AddCommand(new PingCommand()):
console.BeginCommandHandling();
```

# Incoming Features
- Figlet text
- Preset style choices
- Time component implementation
- Performance improvements
- Default help command
- Improved command parameter handling
- Subcommands
