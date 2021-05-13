##Plugin Documentation

I apologize in advance for the lack of documentation 

###Name
You will see this line of code inside the Example Plugin source:
`public string Name => "Example Plugin";`
This will be displayed inside the Plugins MenuItem

###Initialization
You will see a function called: Init, which will be called when the plugin is loaded (on startup)

###Update
There is a function called Update, this function will be called every 100 milliseconds

###Custom Menu Item
There is a function called GetMenuItem which allows you to create your own menu item inside your plugin tool strip item

###Main
You will see this code below the name:
`
public Main main;

public void GetMain(Form form)
{
  main = (Main)form;
}
`
I recommend not changing anything,
this will be the main form which you can modify with your plugin.

If you were to go into the source code and changing the main form,
it will result in most likely a crash when you export your plugin.

The "main" variable will update every 100 milliseconds.

`main.ApplicationPath` will return the path Stenitor is located in.

`main.CurrentLanguage` will return the current set programming language.

`main.GetMonaco(<Tab Index>)` will return the monaco box of the specified tab.
<Tab Index>: which tab you want to get the box from

`main.AddTab(<Content>, <Title>, <Path>)` will add a tab to the tab control.
<Content>: the content the monaco box contains after creation
<Title>: the text of the tab item
<Path>: only used for python to know what file to execute

`main.GetText(<Tab Index>)` gets the text of the monaco box of the tab.
<Tab Index>: the index of what tab you want

`main.Run()` runs the script of the selected tab if its runnable.

`main.OpenFile()` opens the open file dialog for you to select what file to open.

`main.SaveFile()` opens the save file dialog for you to select where to save opened file.

`main.NewFile()` opens the save file dialog for you to select where to create a new file.

`main.ToggleFullscreen()` toggles fullscreen.
