# <u>BetterConsole</u>

## Why use BetterConsole?

BetterConsole offers common display tools and quality of life features for developing console applications.
Features that offer ability to edit and refresh the console is very handy when maintaining a clean console output.
Additionally, the console command structure makes creating, validating, and using console commands very easy.

## BetterConsole Parameters

By default the BetterConsole will only reload up to 1000 console lines, as depending on the implementation reloads may occur frequently and adding a limit may improve preformance. Here's another constructor call where our implementation may contain very frequent reloads.

```csharp
BetterConsole.DisplayLimit = 100;
```


## Simple Functions

Read, write, and clear functions are all present as before.

```csharp
BetterConsole.WriteLine("This is a line of text.");
BetterConsole.Write("Here's some more text.");
BetterConsole.Clear();
BetterConsole.Write("Enter some text: ");
string text = BetterConsole.ReadLine();
```

Using the write methods of the console will register them internally so written lines can be modified and updated within the console.
Call the reload method to clear and redisplay all console lines.

```csharp
BetterConsole.Reload();
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
BetterConsole.WriteLine(text);
```

Alternatively, for plain text the regular Console methods are implemented to make usage easier.

```csharp
BetterConsole.WriteLine("This will also appear green!", ConsoleColor.Green);
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
LoadingBarStyle style = new LoadingBarStyle("-", " ", "<", ">");
```

2. We will now create our loading bar with the our new style options and a defined length. We will also write the loading bar to the console.

```csharp
LoadingBar loadingBar = new LoadingBar(style, 10);
BetterConsole.WriteLine("Execution process: ");
BetterConsole.Write(loadingBar);
```

3. Great, now all we need to do is provide our loading bar with its the current program progress. Note that input values to the SetPercentage method are automatically bounded between 0 and 1.

```csharp
for (int i = 0; i <= n; i++) {
    //Do stuff.
    loadingBar.SetPercentage(i/n);
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

BetterConsole.Write(table);
```

3. Let's now add a header within our table. Resize the table with a lower vertical alignment, add the title cell with a 3 column width, and reload the console.

```csharp
table.Resize(4, 3, verticalAlignment: VerticalAlignment.Lower);
            
Cell titleCell = new Cell("Animals Spotted", 3, 1);
table.SetCell(titleCell, 0, 0);

BetterConsole.Reload();
```

4. Observe your beautifully displayed table.

```
 _________________
| Animals Spotted |
|-----------------|
|     | Tom | John|
|-----|-----|-----|
| Dogs|  10 |  2  |
|-----|-----|-----|
| Cats|  6  |  9  |
|_____|_____|_____|

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

BetterConsole.WriteLine("This timer has been running for: ");
BetterConsole.Write(timer);
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


### <u>List Components</u>

List components are used to display a collection of components, either in an ordered or unordered fashion.
Additionally, lists accept an array of ConsoleComponents or an array of strings for ease of use.
<br/>
Two types of list components:
- Ordered
- Unordered

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

1. Create an ordered list and write it to the console.

```csharp
OrderedList orderedList = new OrderedListComponent("List of my top 4 favorite numbers:", new string[]{"1", "2", "64", "4"});
BetterConsole.WriteLine(orderedList);
```

</details>


## Custom Commands

Console commands provide an easy framework in which to create and handle console inputs.
Both `ConsoleCommand` and `ParameterizedCommand` can be extended, the latter includes a parameter list and an implementation of the `ValidateSignature` virtual method from `ConsoleCommand.cs`.

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

1. Create a new class `PingCommand` and extend `ParameterizedCommand` to include default signature validation. 
Make sure to override the Execute method with a simple implementation.

```csharp
public class PingCommand : ParameterizedCommand {
    public PingCommand() : base("ping")
    {
        Description = "Pings the console for a response.";
    }

    public override void Execute(CommandSignature signature)
    {
        BetterConsole.WriteLine("pong");
    }
}
```

2. Now all we need to do is register an instance of our new command within the BetterConsole. The `BeginCommandHandling` method creates a new thread to handle incoming user inputs so new content can still be output to the console.

```csharp
BetterConsole.Register(new PingCommand()):
BetterConsole.BeginCommandHandling();
```

</details>