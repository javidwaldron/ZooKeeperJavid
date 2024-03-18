using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace ZooKeeperJavid
{
    public class Zone
    {
        private Animal _occupant = null;
        public Animal occupant
        {
            get { return _occupant; }
            set
            {
                _occupant = value;
                if (_occupant != null)
                {
                    _occupant.location = location;
                }
            }
        }

        public Point location;
        public Border zoneButton;

        public string emoji
        {
            get
            {
                if (occupant == null) return "";
                return occupant.emoji;
            }
        }

        public string rtLabel
        {
            get
            {
                if (occupant == null) return "";
                return occupant.reactionTime.ToString();
            }
        }

        public void UpdateZoneImage()
        {
            // Above "getter" ensures we always get a String, whether an emoji or blank, so we don't have to write extra conditional logic here.
            TextBlock zb = (TextBlock)zoneButton.Child;
            zb.Text = $"{emoji}{rtLabel}";
            Console.WriteLine("Zone info: " + emoji + rtLabel);
        }

        /* Notice that we have two constructors for Zone. C# determines which one to call based on the signature (the list of parameters) from the caller.
         * 
         * The first creates a new button for the grid and associates it with the new zone.
         * 
         * The second associates the new zone with an already-existing button, which is provided by the fourth parameter.
         * 
         * As the game exists currently, we only use the second Zone constructor for the "holding pen", so we could probably rewrite the code to require fewer parameters... but we might find another use for this version later.
         * 
         * Alternatively, we might write more constructors with different signatures in order to handle different Zone creation scenarios!
         */

        public Zone(int x, int y, Animal animal)
        {
            location.x = x;
            location.y = y;
            occupant = animal;

            zoneButton = ((MainWindow)Application.Current.MainWindow).MakeGridButton(x, y);
            /* The next two lines are because C#/.NET are stubborn about how you can add event handlers. You can't just add it in the declaration for the TextBlock that we create over in MainWindow.xaml.cs. Annoying, but hey, that's Microsoft for ya! */
            TextBlock tb = (TextBlock)zoneButton.Child;
            tb.MouseDown += PassMyClick;
            UpdateZoneImage();
        }

        public Zone(int x, int y, Animal animal, Border existingButton)
        {
            location.x = x;
            location.y = y;
            occupant = animal;

            zoneButton = existingButton;
            // See note on other version of Zone constructor above
            TextBlock tb = (TextBlock)zoneButton.Child;
            tb.MouseDown += PassMyClick;
            UpdateZoneImage();
        }

        public void PassMyClick(object sender, MouseButtonEventArgs e)
        {
            /* Send the actual Zone on to the game
             * instead of the UI element that was
             * clicked on 
             */
            Game.ZoneClick(this);
        }
    }
}
