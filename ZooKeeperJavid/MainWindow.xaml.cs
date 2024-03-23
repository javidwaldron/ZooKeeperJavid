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
                Width = 60,
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

        private void HoldingPen1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            HoldingPen1.Background = Brushes.LightGray;
            

            if (Game.holdingPen.occupant != null)
            {
                Game.holderzone.occupant = Game.holdingPen.occupant;
                
               
            }


        }

        private void HoldingPen2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HoldingPen2.Background = Brushes.LightGray;

            if (Game.holdingPen2.occupant != null)
            {
                Game.holderzone.occupant = Game.holdingPen2.occupant;
            }

        }

        private void HoldingPen3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HoldingPen3.Background = Brushes.LightGray;

            if (Game.holdingPen3.occupant != null)
            {
                Game.holderzone.occupant = Game.holdingPen3.occupant;
            }

        }


        //Same as zone click but for UI

        private void ZooGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if(Game.holderzone.occupant == null)
            {
                HoldingPen1.Background = Brushes.White;
                HoldingPen2.Background = Brushes.White;
                HoldingPen3.Background = Brushes.White;



            }

           
                

           


        }






    }
}


