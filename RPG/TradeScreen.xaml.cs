using Engine.Models;
using Engine.ViewModels;
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
using System.Windows.Shapes;

namespace RPG
{
    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        public GameSession Session => DataContext as GameSession;
        public TradeScreen()
        {
            InitializeComponent();
        }

        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;
            if (item != null)
            {
                if (Session.CurrentPlayer.Gold >= item.Price)//player has enough money to buy item
                {
                    Session.CurrentPlayer.Gold -= item.Price;
                    Session.CurrentPlayer.AddItemToInventory(item);
                    Session.CurrentTrader.RemoveItemFromInventory(item);
                    MessagesTxbx.Text = "Thanks!";
                }
                else
                {
                    MessagesTxbx.Text = "You don't have enough money for that!";
                }
            }
            else
            {
                MessagesTxbx.Text = "It's as if you think empty air is an object...";
            }
        }

        private void OnClick_Sell(object sender, RoutedEventArgs e)
        {
            GameItem item = ((FrameworkElement)sender).DataContext as GameItem;

            if (item != null)
            {
                Session.CurrentPlayer.Gold += item.Price;
                Session.CurrentTrader.AddItemToInventory(item);
                Session.CurrentPlayer.RemoveItemFromInventory(item);
                MessagesTxbx.Text = "Buy something as well!";
            }
            else
            {
                MessagesTxbx.Text = "I'm not buying empty air.";
            }
        }

        private void OnClick_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
