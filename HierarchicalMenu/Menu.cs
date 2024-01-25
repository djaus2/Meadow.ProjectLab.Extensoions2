using Meadow;
using Meadow.Foundation;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;
using System;

namespace HierarchicalMenu
{
    public class Menu
    {
        public Label[] Labels { get; set; }
        private Box _highlightBox;

        private const int ItemHeight = 30;

        public int SelectedRow { get; set; } = 0;
        public string SelectedItem => Labels[SelectedRow].Text;

        public readonly Color UnselectedTextColor = Color.AntiqueWhite;
        public readonly Color SelectedTextColor = Color.Black;
        public readonly Color SelectionColor = Color.Orange;
        public readonly Color TitleTextColor = Color.Red;
        public readonly Color TitleColor = Color.Black;
        public readonly IFont MenuFont = new Font12x20();
        public readonly IFont TitleFont = new Font12x20();

        public Menu(string Title, string[] items, DisplayScreen screen, int prevIndex=0)
        {
            Labels = new Label[items.Length];

            var x = 2;
            var y = 0;
            var height = ItemHeight;
            SelectedRow = prevIndex;

            // we compose the screen from the back forward, so put the box on first
            _highlightBox = new Box(0, -1, screen.Width, ItemHeight + 2)
            {
                ForeColor = SelectionColor,
                IsFilled = true,
            };
            
            screen.Controls.Add(_highlightBox);

            Label title  = new Label(
            left: x,
            top: 0 * height,
            width: screen.Width,
            height: height)
            {
                Text = Title,
                Font = MenuFont,             
                BackColor = TitleColor,
                VerticalAlignment = VerticalAlignment.Center,
                TextColor = TitleTextColor,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            screen.Controls.Add(title);

            for (var i = 0; i < items.Length; i++)
            {
                Labels[i] = new Label(
                    left: x,
                    top: (i+1) * height,
                    width: screen.Width,
                    height: height)
                {
                    Text = items[i],
                    Font = MenuFont,
                    BackColor = Color.Transparent,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                // select the first itemx
                //if (i == 0)
                //{
                //    Labels[i].TextColor = SelectedTextColor;
                //}
                //else
                //{
                    Labels[i].TextColor = UnselectedTextColor;
                //}

                screen.Controls.Add(Labels[i]);


                y += height;
            }
            //if(prevIndex != 0)
                Draw(0, prevIndex);
        }

  
        public void Action(object sender, EventArgs e)
        {

            int index = SelectedRow++;// _menu.SelectedRow;
            Resolver.Log.Info($"Action1 Enter: {index}");
        }

        public void Down()
        {
            if (SelectedRow < Labels.Length - 1)
            {
                SelectedRow++;
                Resolver.Log.Info($"[Down]: CURRENT MENU ITEM: {Labels[SelectedRow].Text}");
                Draw(SelectedRow - 1, SelectedRow);
            }
        }

        public void Up()
        {
            if (SelectedRow > 0)
            {
                SelectedRow--;

                Resolver.Log.Info($"[Up]: CURRENT MENU ITEM: {Labels[SelectedRow].Text}");

                Draw(SelectedRow + 1, SelectedRow);
            }
        }

        public void Draw(int oldRow, int newRow)
        {
            Labels[oldRow].TextColor = UnselectedTextColor;
            Labels[newRow].TextColor = SelectedTextColor;

            _highlightBox.Top = Labels[newRow].Top - 1;
        }
    }
}