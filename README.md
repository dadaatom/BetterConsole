# BetterConsole
Better console with prebuilt functionalities and offers improved display tools. Implements a ConsoleCommand framework so that new user defined commands can easily be added and executed.

# Examples
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
Reading and writing can still be done the same as before.
```
console.WriteLine("This is a line of text.");
console.Write("Here's some more text.");
console.Clear();
console.Write("Enter some text: ");
string text = console.ReadLine();
```
## Console Components
Console components can be described as linked lists where each node is a portion of text in a console line. The Write and WriteLine methods also accept console components.
### Text Component
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
## Loading Bar
Let's now create a loading bar to display the execution process of our program. We will be setting a length of 10 units and writing it to our value.
```
LoadingBar loadingBar = new LoadingBar(10);
console.WriteLine("Execution process: ");
console.Write(loadingBar);
```
Great, now all we need to do is set the percentage of our loading bar. Note that input values to the SetPercentage method are bounded between 0 and 1.
```
for (int i = 0; i <= n; i++) {
    //Do stuff.
    loadingBar.SetPercentage(i*(1/n));
}
```
