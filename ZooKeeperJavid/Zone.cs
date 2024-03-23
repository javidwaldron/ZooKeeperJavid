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
            
            TextBlock zb = (TextBlock)zoneButton.Child;
            zb.Text = $"{emoji}{rtLabel}";
            Console.WriteLine("Zone info: " + emoji + rtLabel);
        }


        public Zone(int x, int y, Animal animal)
        {
            location.x = x;
            location.y = y;
            occupant = animal;

            zoneButton = ((MainWindow)Application.Current.MainWindow).MakeGridButton(x, y);
           
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
           
            TextBlock tb = (TextBlock)zoneButton.Child;
            tb.MouseDown += PassMyClick;
            UpdateZoneImage();
        }

        public void PassMyClick(object sender, MouseButtonEventArgs e)
        {
            
            Game.ZoneClick(this);
        }
    }
}
