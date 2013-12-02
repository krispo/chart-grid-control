## Chart Grid control

This is a user control wich provides a simple and convenient tool for playing with time series data based on [ZedGraph Graphing Library](http://zedgraph.sourceforge.net/samples.html). Written on VB.NET.

.NET platform provides a huge variety of controls that help you to create rich user interfaces. Any control is usually designed as an independent element placed to the Visual Studio control toolbox (such as Button, DataGridView,...) to be integrated then to any .NET application. 

ChartGridControl contains the following controls:

* `DataGridView` - interactive data table. "0"-th column contains Date value, the other columns contain series values. Each series corresponds to the special column.
* `ZedGraphControl` - chart vizualization tool for DataGridView
* `TextBox` for logging
* `ChartSettingsDialog` for chart appearance adjustment
* `AddDialog` for adding the data, including via Excel COM Object
* `Buttons` for dialogs (settings, add, save)
* `DateTimePicker` for navigating over the data range

and looks like

![control](https://raw.github.com/krispo/chart-grid-control/master/resources/control.png)


### How to use

To use it you should add reference to `ZedGraph.dll` and `ChartGridControl.dll` libs in your Visual Studio project. You can get libs by:

* [download](https://s3-us-west-2.amazonaws.com/chartgrid/ChartGridControl.zip) libs pack,
* or, just compile and build this project, and in the `bin\release` folder you will find the libs.

In the Visual Studio control toolbox you will find then the *ChartGridControl* that can be placed to your form. If it's not found than try to do next: Right click on toolbox -> Choose Items... -> Browse -> Choose library (dll) -> In Components check the Control. 

You can find a real *ChartGrid* application that uses the control in `\samples\` folder. The basics of usage is provided below.

## ChartGrid

There are a couple of simple examples in a `\samples\` folder written on C# and VB.NET that use the ChartGridControl. Examples are at first designed to demonstrate how to use the control regadless of the programming language. Examples are completely the same, except for the programming language, so each of those ones you can use as a standalone software - *ChartGrid*. The program have a quite intuitive interface.

### Installation (for Windows)

* **Simple**.
You can download directly the installation file for 32- or 64 bit system ([setup32](https://s3-us-west-2.amazonaws.com/chartgrid/setup32.exe), [setup64](https://s3-us-west-2.amazonaws.com/chartgrid/setup64.exe)):
    1. Install it. 
    2. Click on the `ChartGrid` icon on the Desktop to run.  
* **Prof**.
If you have Visual Studio installed:
    1. Clone this repo.
    2. Choose any example in the `samples` folder and run project solution file `ChartGrid.sln` using Visual Studio.
    3. Due to *Add Reference...* option add references to *ZedGraphControl* and *ChartGridControl*. To do this you need `ZedGraph.dll` and `ChartGridControl.dll` libs. You can get libs by:
        * [download](https://s3-us-west-2.amazonaws.com/chartgrid/ChartGridControl.zip) libs pack,
        * or, just compile and build this project, and in the `bin/release` folder you will find the libs.
    4. Compile and run it via `F5`.

### Get started

The main form of the *ChartGrid* application contains *MenuStrip* and *TabControl* controls. The *ChartGridControl* is placed into each Tab object of the TabControl. All the functionality of the app, except for Menu and Tab control, is associated with the *ChartGridControl*.

After running the application you will see an empty *ChartGridControl* within the only Tab object:

![startWin](https://raw.github.com/krispo/chart-grid-control/master/resources/startWin.png)

Add a new series by clicking on the *Add* button. The *Add Series* dialog will be displayed:

![addDialog](https://raw.github.com/krispo/chart-grid-control/master/resources/addDialog.png)

You can select a method for adding a series:

* *Create new...* - Add an empty series with specified range (from, to) and time interval.    
* *From file* - Load data from a specified file. The program connect to the file via Excel COM Object. First row must contains column names. Date column must have Date or Double format. You should select Time variable and, if necessary, specify Time interval and Date format for it. Also you should select one or multiple Series variables.

Browse the `prices.xlsx` file in the `\data\` folder and click OK. Then the program main thread will split into two parallel threads. While the data is reading in one thread, another thread is used to display the loading form:

![loading](https://raw.github.com/krispo/chart-grid-control/master/resources/loading.png)

After data is ready the control will be filled like

![singleSeries](https://raw.github.com/krispo/chart-grid-control/master/resources/singleSeries.png)

All columns of the table are mapped to the chart in accordance to the Time column. You can play with data as you like. For instance, you can change any point value via the table as well as the chart. Provide you a list of operations and corresponding actions that can help you to interact with chart:

Mouse operation          | Action 
:-----------------------:|:-----------------------
 Moving                  | Chart moving 
 Ctrl + Selecting        | Zoom selected box 
 Shift + Point selecting | Allows you to move the point in vertical direction
 Scrolling               | Zooming 
 H + Scrolling           | Horizontal zooming
 V + Scrolling           | Vertical zooming 
 Right click             | Open context menu 

ZedGraph control context menu provide you also a number of helpful features:

![singleSeries](https://raw.github.com/krispo/chart-grid-control/master/resources/chartContextMenu.png)

Now you can add a new Tab object named *Multiple Series* via *File* menu:

![singleSeries](https://raw.github.com/krispo/chart-grid-control/master/resources/menu.png)

And add several series into this tab. You can add an emty column with name *New Series* to the table and then fill it from any other series column via the regular commands like *Ctrl+C*, *Ctrl+V*, *Ctrl+Z*.

![singleSeries](https://raw.github.com/krispo/chart-grid-control/master/resources/multipleSeries.png)

You can interact with a lot of completely independent tab elements.

You can adjust the appearance of the chart as you want via the *Settings* dialog. Click on the *Settings* button to display this dialog:

![singleSeries](https://raw.github.com/krispo/chart-grid-control/master/resources/settingsDialog.png)

To remove some series you should select those series at first, and then remove it.

Finally, after playing with the data you can save it in common Excel formats (Excel Workbook [.xlsx]; Excel Document 97-2003 [.xls]) via clicking on the *Save* button. 

If you need more functionality for your project, please, feel free to add or change it as you want.

### License

This library is under the MIT license. Check the [LICENSE](https://github.com/krispo/chart-grid-control/blob/master/LICENSE) file.