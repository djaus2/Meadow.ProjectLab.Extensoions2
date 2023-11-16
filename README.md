# Meadow.ProjectLab.Extensions2

Based upon the Meadow.Foundation project sample, **MicroLayoutMenu**.  
This implments a Multi-level Menu System with menu Up/Down as well as [Select] _(choose item and move to next menu level)_ and [Back] _(go back one menu level)_.

![The board](https://github.com/djaus2/Meadow.ProjectLab.Extensions/blob/master/theboard.png)  
**_The WILDERNESS LABS Project Lab V3 board_**

## Links

- Previous repository: [Meadow.ProjectLab.Extensions](https://github.com/djaus2/Meadow.ProjectLab.Extensions)
- Original Meadow.ProjectLab [MicroLayoutMenu Project](https://github.com/WildernessLabs/Meadow.ProjectLab.Samples/tree/main/Source/MicroLayoutMenu)
- As previous:
  - [Blog about Meadow Project Lab](https://davidjones.sportronics.com.au/med/WildernessLabs_Project_Lab-About_Project_Lab_V3-med.html)
  - The target board:  [The Wilderness Labs project V3](https://store.wildernesslabs.co/collections/frontpage/products/project-lab-board)
  - [Meadow ProjectLab_Demo](https://github.com/WildernessLabs/Meadow.ProjectLab/tree/main/Source/)
  - [WildernessLabs/Meadow.ProjectLab](https://github.com/WildernessLabs/Meadow.ProjectLab)
  - [Meadow ProjectLab Samples](https://github.com/WildernessLabs/Meadow.ProjectLab.Samples)
  - [Meadow.Core.Samples](https://github.com/WildernessLabs/Meadow.Core.Samples)
  - [Meadow.Foundation.Grove](https://github.com/WildernessLabs/Meadow.Foundation.Grove)
  - [WildernessLabs](https://github.com/Wildernesslabs)
  - [WildernessLabs fork of MQTTnet](https://github.com/WildernessLabs/MQTTnet)

## Suggested update for MicroLayoutMenu

The original MicroLayoutMenu project has a bug that, if ShowMenuScreen is uncommented, the textual scxreen fails to be drawn.

- In ```MeadowApp.cs``` change:
```cs 
        public override Task Run()
        {
            ShowDemoScreen();

            //ShowMenuScreen();

            return base.Run();
        }
```
- To:  
```cs
        public override Task Run()
        {
            ShowDemoScreen();

            // Move to Menu after 5sec
            Thread.Sleep(5000);

          __screen.Controls.Clear(); // <-This IS needed!
           ShowMenuScreen();

             return base.Run();
        }
```

This implements the clearing of the Demo screen when the textual menu is drawn.