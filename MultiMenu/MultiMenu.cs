using Meadow.Devices;
using Meadow.Foundation.Audio;
using Meadow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Meadow.Foundation.Graphics.MicroLayout;

namespace MultiMenu
{
    internal class MultiMenu
    {
        private IProjectLabHardware _projectLab;
        private MicroAudio? audio;
        private DisplayScreen _screen;
        private Menu _menu = null;
        private Stack _menuStack  = null;

        MenuDetails _menuDetails = null;
        public MenuSettings _MenuSettings { get; private set; }


        public MultiMenu(IProjectLabHardware _projectLab,DisplayScreen _screen, MicroAudio audio)
        {
            this._projectLab = _projectLab;
            this.audio = audio;
            this._screen = _screen;

            InitMenu();
        }
        private class MenuDetails
        {

            public string Title { get; set; }
            public string Items { get; set; }
            public System.EventHandler Action { get; set; }

            public int MenuSelection { get; set; } = 0;
        }

      

        private void InitMenu()
        {
            _menu = null;
            _menuDetails = null;
            _menuStack = new Stack();
            _projectLab.UpButton.Clicked += (s, e) => _menu.Up();
            _projectLab.DownButton.Clicked += (s, e) => _menu.Down();
            _projectLab.LeftButton.Clicked += ActionBack;
            _projectLab.LeftButton.LongClickedThreshold = TimeSpan.FromMilliseconds(1500);
            _projectLab.LeftButton.LongClicked += ActionRestart;
        }
        void ShowMenuScreen(string Title, string items, System.EventHandler action, bool menuBack = false)
        {
            _screen.Controls.Clear();
            string[] menuItems;

            if (_menuDetails != null)
            {
                if (_menuDetails.Action != null)
                    _projectLab.RightButton.Clicked -= _menuDetails.Action;
            }

            if (!menuBack)
            {
                if (_menu != null) // Ignore for first entry
                    Resolver.Log.Info($"MENU ITEM SELECTED: {_menu.SelectedItem}");

                if (_menuDetails != null)
                {
                    _menuDetails.MenuSelection = _menu.SelectedRow;
                    _menuStack.Push(_menuDetails);
                }

                menuItems = items.Split(',');
                _menu = new Menu(Title, menuItems, _screen);

                _menuDetails = new MenuDetails { Title = Title, Items = items, Action = action };
                Resolver.Log.Info($"CURRENT MENU ITEM: {_menu.SelectedItem}");
                if (audio is { })
                {
                    _ = audio.PlaySystemSound(SystemSoundEffect.Success);
                }
            }
            else
            {
                if (_menuStack.Count != 0)
                {
                    Resolver.Log.Info($"MENU [BACK]");
                    _menuDetails = (MenuDetails)_menuStack.Pop();
                    string prevItems = _menuDetails.Items;
                    string prevTitle = _menuDetails.Title;
                    action = _menuDetails.Action;
                    int prevIndex = _menuDetails.MenuSelection;
                    menuItems = prevItems.Split(',');
                    _menu = new Menu(prevTitle, menuItems, _screen, prevIndex);
                    Resolver.Log.Info($"CURRENT MENU ITEM: {_menu.SelectedItem}");
                    if (audio is { })
                    {
                        _ = audio.PlaySystemSound(SystemSoundEffect.Notification);
                    }
                }
            }

            if (action != null)
                _projectLab.RightButton.Clicked += action;


        }
        private void ActionRestart(object sender, EventArgs e)
        {
            _menu = null;
            _menuDetails = null;
            _menuStack = new Stack();
            Action0();
        }

        private void ActionBack(object sender, EventArgs e)
        {
            if (_menuStack.Count != 0)
            {
                ShowMenuScreen(null, null, null, true);
            }
            else
            {
                if (audio is { })
                {
                    _ = audio.PlaySystemSound(SystemSoundEffect.Beep);
                }
            }
        }

        public void Action0()
        {
            int actionNo = 0;
            // Setup first menu only
            MenuData md = AppSettings.MenuDataList[actionNo];
            ShowMenuScreen(md.Title, md.Items, Action1);
        }

        private void Action1(object sender, EventArgs e)
        {
            int actionNo = 1;
            int index = _menu.SelectedRow;
            //Do Whatever for first menu

            MenuData md = AppSettings.MenuDataList[actionNo];
            ShowMenuScreen(md.Title, md.Items, Action2);
        }

        private void Action2(object sender, EventArgs e)
        {
            int actionNo = 2;
            int index = _menu.SelectedRow;
            //Do Whatever for second menu

            MenuData md = AppSettings.MenuDataList[actionNo];
            ShowMenuScreen(md.Title, md.Items, Action3);
        }

        private void Action3(object sender, EventArgs e)
        {
            int actionNo = 3;
            int index = _menu.SelectedRow;
            //Do Whatever for previous menu

            MenuData md = AppSettings.MenuDataList[actionNo];
            ShowMenuScreen(md.Title, md.Items, Action4);
        }

        private void Action4(object sender, EventArgs e)
        {
            int actionNo = 4;
            int index = _menu.SelectedRow;
            //Do Whatever for previous menu
            // Perhaps remove  the next line.  It is just to show that you can continue to add menus.
            
            MenuData md = AppSettings.MenuDataList[actionNo];
            ShowMenuScreen(md.Title, md.Items, null);
        }

        // Add more of these as needed
    }
}
