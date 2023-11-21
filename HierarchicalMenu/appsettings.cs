using System.Collections.Generic;

namespace HierarchicalMenu
{
    public class MenuData
    {
        public string Title { get; set; }
        public string Items { get; set; }
    }
    public static class AppSettings
    {
        public static List<MenuData> MenuDataList = new List<MenuData>
        {

            new MenuData
            {
                Title = "Main Menu",
                Items = @"Item 1,Item 2,Item 3,Item 4"
            },
            new MenuData
            {
                Title = "Menu 1",
                Items = @"Item 11,Item 12,Item 13,Item 14"
            },
            new MenuData
            {
                Title = "Menu 2",
                Items = @"Item 21,Item 22,Item 23,Item 24"
            },
            new MenuData
            {
                Title = "Menu 3",
                Items = @"Item 31,Item 32,Item 33,Item 34"
            },
            new MenuData
            {
                Title = "Menu 4",
                Items = @"Item 41,Item 42,Item 43,Item 44"
            }

            // Add more here if needed
        };
    }
}
