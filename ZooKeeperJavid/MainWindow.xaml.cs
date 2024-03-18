using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZooKeeperJavid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Game.SetUpGame();
        }

        /* Event handlers for buttons. Notice that these basically
 * pass on a request to the static Game class and get back
 * whether or not it succeeded. The success or failure in turn
 * controls whether or not the button stays enabled.
 * 
 * Technically this is not ideal, since the user has to click
 * the button once and have it fail BEFORE the button grays out.
 * Can you improve on this?
 */


        /* In this simple version, each kind of animal has a custom click handler for being added to the holding pen if it comes from the "add" buttons, yet animals can be put back into the holding pen from the "zoo" grid without needing custom code for each animal type.
 * 
 * Can you make similar improvements to the XAML and backing code so that the animal-generating buttons (the "add" buttons)
 *
 */
        private void Cat_Button_Clicked(object sender, MouseButtonEventArgs e)
        {
            Game.AddAnimalToHolding("cat");
        }
        private void Mouse_Button_Clicked(object sender, MouseButtonEventArgs e)
        {
            Game.AddAnimalToHolding("mouse");

        }
        private void Raptor_Button_Clicked(object sender, MouseButtonEventArgs e)
        {
            Game.AddAnimalToHolding("raptor");
        }
        private void Chick_Button_Clicked(object sender, MouseButtonEventArgs e)
        {
            Game.AddAnimalToHolding("chick");
        }


        public Border MakeGridButton(int x, int y)
        {
            Border theButton = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black
            };

            TextBlock tb = new TextBlock
            {
                Text = "?",
                FontSize = 24,
                Width = 50,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center
            };
            theButton.Child = tb;
            ZooGrid.Children.Add(theButton);
            Grid.SetColumn(theButton, x);
            Grid.SetRow(theButton, y);
            return theButton;
        }


    }
}


