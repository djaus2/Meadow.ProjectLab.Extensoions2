using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Audio;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace HierarchicalMenu
{
    // Change F7FeatherV2 to F7FeatherV1 for V1.x boards
    public class MeadowApp : App<F7CoreComputeV2>
    {
        private IProjectLabHardware _projectLab;
        private MicroAudio? audio;
        private DisplayScreen _screen;
        private MultiMenu multiMenu;



        public override Task Initialize()
        {
            _projectLab = ProjectLab.Create();
            _projectLab.Speaker?.SetVolume(0.5f);
            if (_projectLab.Speaker is { })
            {
                audio = new MicroAudio(_projectLab.Speaker);
            }
            _screen = new DisplayScreen(_projectLab.Display, RotationType._270Degrees);

           

            return base.Initialize();
        }

        void ShowDemoScreen()
        {
            //var image = Image.LoadFromResource("HierarchicalMenu.img_meadow.bmp");
            var image = Image.LoadFromResource("HierarchicalMenu.smallazurexmas.bmp");

            const int ButtonHeight = 25;
            const int ButtonWidth = 100;
            const int pad = 2;

            _screen.Controls.Add(
                new Box(0, 0, _screen.Width, _screen.Height)
                {
                    ForeColor = Color.White
                },
                new Label(15, 20, 290, 40)
                {
                    Text = "Hierarchical Menu!",
                    TextColor = Color.Black,
                    BackColor = Color.FromHex("#C9DB31"),
                    Font = new Font12x20(),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                },
                new Picture(90, 74, 140, 90, image)
                {
                    BackColor = Color.FromHex("#23ABE3"),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },                
                new Button(_screen.Width/2 - (ButtonWidth/2), _screen.Height - 3 * (ButtonHeight + pad) , ButtonWidth, ButtonHeight)
                {
                    Text = "Previous",
                    TextColor = Color.Black,
                    Font = new Font12x20(),
                    PressedColor = Color.FromHex("#C9DB31")
                },
                new Button(_screen.Width / 2 - (ButtonWidth/2), _screen.Height -(ButtonHeight + pad) , ButtonWidth, ButtonHeight)
                {
                    Text = "Next",
                    TextColor = Color.Black,
                    Font = new Font12x20(),
                    PressedColor = Color.FromHex("#C9DB31")
                },
                new Button(1, _screen.Height - pad * (ButtonHeight + pad) , ButtonWidth, ButtonHeight)
                {
                    Text = "Back",
                    TextColor = Color.White,
                    ForeColor = Color.Red,
                    Font = new Font12x20(),
                    PressedColor = Color.FromHex("#C9DB31")
                    //,Pressed = ButtonPressed()
                },
                new Button(_screen.Width-(ButtonWidth+pad), _screen.Height - pad * (ButtonHeight + pad) , ButtonWidth, ButtonHeight)
                {
                    Text = "Select",
                    TextColor = Color.White,
                    ForeColor = Color.Green,
                    ShadowColor = Color.FromHex("#555555"),
                    Font = new Font12x20(),
                    PressedColor = Color.FromHex("#C9DB31")
                });
        }




        public override Task Run()
        {
            ShowDemoScreen();

            // Move to HierarchicalMenu after 10sec
            Thread.Sleep(5000);

            multiMenu = new MultiMenu(_projectLab, _screen, audio);
            multiMenu.Action0();

            return base.Run();
        }


        //Nb: Pressed is not working
        // Further, seems that this method was firing 
        // From its reference at
        // See //,Pressed = ButtonPressed()
        //public bool ButtonPressed()
        //{
        //    multiMenu = new MultiMenu(_projectLab, _screen, audio);
        //    multiMenu.Action0();
        //    return true;
        //}
    }
}