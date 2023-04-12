# <u>BetterConsole</u>

# Why use BetterConsole?

BetterConsole offers common display tools and quality of life features for developing console applications.
The ability to edit and refresh the console elements is very handy when maintaining a clean console output.
Prebuilt console components include tables, images, loading bars, timers, and much more.
Additionally, the console command structure makes creating, validating, and using console commands very easy.


# Instantiating The BetterConsole

Before the BetterConsole can be used its main components need to be instantiated.
The BetterConsole can be instantiated with default values or with parameters in order to define custom functionality.

Default initialisation:
```c#
BetterConsole.Instantiate();
```

Custom console style with default red color:
```c#
ConsoleTheme theme = new ConsoleTheme();
StaticColor staticRed = new StaticColor(ColorUtil.ConvertToColor(ConsoleColor.Red));
ConsoleStyle consoleStyle = new ConsoleStyle(staticRed, theme);

BetterConsole.Instantiate(new ConsoleHandler(100), new TimeHandler(), consoleStyle);
```


# Simple Functions

Read, write, and clear functions are all present as before.

```c#
BetterConsole.WriteLine("This is a line of text.");
BetterConsole.Write("Here's some more text.");
BetterConsole.Clear();
BetterConsole.Write("Enter some text: ");
string text = BetterConsole.ReadLine();
```

Using the write methods of the console will register them internally so written lines can be modified and updated within the console.
Call the reload method to clear and redisplay all console lines.

```c#
BetterConsole.Reload();
```
Reloading individual components can also be done if the component exists on the last line and is not multiline.
This strategy is effective when you expect to reload a component very regularly (like a timer or loading bar).
```c#
BetterConsole.Reload(component);
```


# Console Components

Console components are elements within a console display.
Most methods like Write and WriteLine accept console components as well as strings.


## <u>Text Components</u>

Text components represent strings stored within the console. 

<details>
    <summary>
        <b>Show Code Example</b>
    </summary>
<br/>

Let's write a text component in the color green.

```c#
TextComponent text = new TextComponent("This will appear green!");
text.SetColor(new StaticColor(Color.Green));
BetterConsole.WriteLine(text);
```

Alternatively, for plain text the regular Console methods are implemented to make usage easier.

```c#
BetterConsole.WriteLine("This will also appear green!", new StaticColor(Color.Green));
```

</details>


## <u>Loading Bars</u>
Loading bars are useful for displaying the execution progress of your code. 

<details>
    <summary>
        <b>Show Code Example</b>
    </summary>
<br/>

1. Let's create a loading bar with a defined length of 10 units. We will also write the loading bar to the console.

```c#
LoadingBar loadingBar = new LoadingBar(style, 10);
BetterConsole.WriteLine("Execution process: ");
BetterConsole.Write(loadingBar);
```

2. Great, now all we need to do is provide our loading bar with its the current program progress. Note that input values to the SetPercentage method are automatically bounded between 0 and 1.

```c#
for (int i = 0; i <= n; i++) {
    //Do stuff.
    loadingBar.SetPercentage(i/n);
}
```

</details>


## <u>Tables</u>

Tables are handy for organizing and displaying information, they are made of a 2d array of table cells. Cells will accept plain strings or console components. Additionally, table cells are able to resize in order to accomodate varying widths and heights. Cells may also span multiple rows and columns within the table in order to create larger spaces for them.
<br/>
Simple Table:
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

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>
    
Let's say two friends want to track how many animals they each saw throughout the day, let's help them display this important information in a table.
1. Create a 3x3 table and label the outer cells.

```c#
Table table = new Table(3,3);

table.SetCell(new Cell("Tom"),0,1);
table.SetCell(new Cell("John"),0,2);

table.SetCell(new Cell("Dogs"),1,0);
table.SetCell(new Cell("Cats"),2,0);
```

2. Fill the inner cells with their data and have the console write the table.

```c#
table.SetCell(new Cell("10"),1,1);
table.SetCell(new Cell("2"),1,2);
table.SetCell(new Cell("6"),2,1);
table.SetCell(new Cell("9"),2,2);

BetterConsole.Write(table);
```

3. Let's now add a header within our table. Resize the table with a lower vertical alignment, add the title cell with a 3 column width, and reload the console.

```c#
table.Resize(4, 3, verticalAlignment: VerticalAlignment.Lower);
            
Cell titleCell = new Cell("Animals Spotted", 3, 1);
table.SetCell(titleCell, 0, 0);

BetterConsole.Reload();
```

</details>


## <u>Images</u>

Images are helpful for displaying specific graphics within the console.
When creating an image its important to note the size of the input image as pixels displayed here are quite large.
It's important to note when displaying images in the console many images are limited by the short selection of available ConsoleColors available.

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

1. Get the complete image path.
```c#
string imagePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))+"\\Images\\MyImage.png"));
```

2. Create and write the image to the console.
```c#
Image image = new Image(imagePath);
BetterConsole.WriteLine(image);
```

</details>


## <u>Time Components</u>

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

```c#
Timer timer = new Timer();

BetterConsole.WriteLine("This timer has been running for: ");
BetterConsole.Write(timer);
```

2. Start the timer to begin timed updates.

```c#
timer.Start();
```

3. Stop the timer when ready.

```c#
timer.Stop();
```

</details>


## <u>List Components</u>

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

```c#
string[] nums = new string[]{"1", "2", "64", "4"};
OrderedList orderedList = new OrderedListComponent("List of my top 4 favorite numbers:", nums);
BetterConsole.WriteLine(orderedList);
```

</details>


## <u>Graph Components</u>

Graphs are another helpful tool to organise data for users.
Additionally, lists accept an array of ConsoleComponents or an array of strings for ease of use.
<br/>
Currently there are two types of graph components:
- Histograms
- Scatter plots

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

1. First create a list of the HistoBars to display.

```c#
HistoBar histoBars = new HistoBar[]{
                        new HistoBar("A", 3.2), 
                        new HistoBar("B", 4.05), 
                        new HistoBar("C", 1.7)};
```

2. Create a HistoGram, set the Axis labels, and write the graph.

```c#
Histogram histo = new Histogram(histoBars);
histo.XAxis.Label = "X Axis";
histo.YAxis.Label = "Y Axis";
BetterConsole.WriteLine(histo);
```

</details>

# Console Colors

Console colors offer different types of color schemes than simple static colors.
Custom colors are easy to implement, see the code example for more information.

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

The following example will implement an example color that alternates colors every word.

1. Create a class and extend `ComponentColor`, make sure to implement the `ApplyTo` function.

```c#
using System.Drawing;

public class ExampleColor : ComponentColor
{
    public Color[] Colors { get; }
            
    public ExampleColor(Color[] colors)
    {
        Colors = colors;
    }

    public override ComponentBuilder ApplyTo(string toDisplay)
    {
        ComponentBuilder toReturn = new ComponentBuilder();
        string[] list = toDisplay.Split(new[] {' ', '\n'});

        for(int i = 0; i < list.Length; i++)
        {
            toReturn.Append(new ComponentBuilder.ComponentSegment(list[i], Colors[i % Colors.Length]));
        }

        return toReturn;
    }
}
```

2. Apply this color and output text.

```c#
TextComponent text = new TextComponent("Hello folks,\nLook at these cool colors!");
text.Color = new ExampleColor(new Color[]{Color.Red, Color.Green});
BetterConsole.WriteLine(text);
```

</details>


# Custom Commands

Console commands provide an easy framework in which to create and handle console inputs.
Both `ConsoleCommand` and `ParameterizedCommand` can be extended, the latter includes a parameter list and an implementation of the `ValidateSignature` virtual method from `ConsoleCommand.cs`.

<details>
    <summary>
        <b>Show Code Example:</b>
    </summary>
<br/>

1. Create a new class `PingCommand` and extend `ParameterizedCommand` to include default signature validation. 
Make sure to override the Execute method with a simple implementation.

```c#
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

```c#
BetterConsole.Register(new PingCommand()):
BetterConsole.BeginCommandHandling();
```

</details>
