# <u>BetterConsole</u>

Better console with prebuilt functionalities and offers improved display tools. Implements a ConsoleCommand framework so that user defined commands can easily be added and handled.


## Creating the BetterConsole

First, let's create an instance of the `BetterConsole` class. 

```csharp
BetterConsole console = new BetterConsole();
```

By default the BetterConsole will only reload up to 1000 console lines, as depending on the implmentation reloads may occur frequently and adding a limit may improve preformance. Here's another constructor call where our implementation may contain very frequent reloads.

```csharp
BetterConsole console = new BetterConsole(displayLimit = 100);
```


## Simple Functions

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

Console components can be described as linked lists where each node is a portion of text in a console line.
Most methods like Write and WriteLine accept console components as well as strings.


### <u>Text Components</u>

Text components represent strings stored within the console. 

<details>
    <summary>
        <b>Show Code Example</b>
    </summary>
<br/>

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

</details>


### <u>Loading Bars</u>
Loading bars are useful for displaying the execution progress of your code. 

<details>
    <summary>
        <b>Show Code Example</b>
    </summary>
<br/>

1. Let's display the current progress of our program. Firstly, whilst completely optional, I am going to define different style options below.
    
```csharp
LoadingBarStyle style = new LoadingBarStyle("-", "~", "<", ">");
```

2. We will now create our loading bar with the our new style options and a defined length. We will also write the loading bar to the console.

```csharp
LoadingBar loadingBar = new LoadingBar(style, 10);
console.WriteLine("Execution process: ");
console.Write(loadingBar);
```

3. Great, now all we need to do is provide our loading bar with its the current program progress. Note that input values to the SetPercentage method are automatically bounded between 0 and 1.

```csharp
for (int i = 0; i <= n; i++) {
    //Do stuff.
    loadingBar.SetPercentage(i*(1f/n));
}
```

</details>


### <u>Tables</u>

Tables are handy for organizing and displaying information, they are made of a 2d array of table cells. Cells will accept plain strings or console components. Additionally, table cells are able to resize in order to accomodate varying widths and heights. Cells may also span multiple rows and columns within the table in order to create larger spaces for them.

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>
    
Let's say two friends want to track how many animals they each saw throughout the day, let's help them display this important information in a table.
1. Create a 3x3 table and label the outer cells.

```csharp
Table table = new Table(3,3);

table.SetCell(new Cell("Tom"),0,1);
table.SetCell(new Cell("John"),0,2);

table.SetCell(new Cell("Dogs"),1,0);
table.SetCell(new Cell("Cats"),2,0);
```

2. Fill the inner cells with their data and have the console write the table.

```csharp
table.SetCell(new Cell("10"),1,1);
table.SetCell(new Cell("2"),1,2);
table.SetCell(new Cell("6"),2,1);
table.SetCell(new Cell("9"),2,2);

console.Write(table);
```

3. Let's now add a new row of data. Resize the table, add the information to the new row, and reload the console.

```csharp
table.Resize(4,3);

table.SetCell(new Cell("Cool\nBird"),3,0);
table.SetCell(new Cell("1"),3,1);
table.SetCell(new Cell("0"),3,2);

console.Reload();
```

4. Observe your beautifully displayed table.

```
 ____ ___ ____
|    |Tom|John|
|----|---|----|
|Dogs| 10|  2 |
|----|---|----|
|Cats| 6 |  9 |
|----|---|----|
|Cool| 1 |  0 |
|Bird|   |    |
|____|___|____|
```

</details>


### <u>Time Components</u>

Time components are handy for tracking the runtime of a program or conveying other time related information to the user.
<br/>
Types of time components:
- Timer
- Countdown

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

1. Create timer and write it to the console.

```csharp
Timer timer = new Timer();

console.WriteLine("This timer has been running for: ");
console.Write(timer);
```

2. Start the timer to begin timed updates.

```csharp
timer.Start();
```

3. Stop the timer when ready.

```csharp
timer.Stop();
```

</details>


## Custom Commands

Console commands provide an easy framework in which to create and handle console inputs.

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

1. Create a new class `PingCommand` and extend `ConsoleCommand`. Make sure to override the Execute method with a simple implementation.

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

2. Now all we need to do is register an instance of our new command within the BetterConsole. The `BeginCommandHandling` method creates a new thread to handle incoming user inputs so new content can still be output to the console.

```csharp
console.AddCommand(new PingCommand()):
console.BeginCommandHandling();
```

</details>