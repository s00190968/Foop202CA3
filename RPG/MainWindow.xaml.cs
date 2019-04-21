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
using Engine.EventArgs;
using Engine.Models;
using Engine.ViewModels;

namespace RPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly GameSession gameSession = new GameSession();
        public MainWindow()
        {
            InitializeComponent();

            gameSession.OnMessageRaised += OnGameMessageRaised;

            //xaml gets the values from the gamesession
            DataContext = gameSession;
            //WeaponsCbx.ItemsSource = gameSession.CurrentPlayer.Weapons;
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            gameSession.MoveUp();
        }

        private void MoveRight_Click(object sender, RoutedEventArgs e)
        {
            gameSession.MoveRight();
        }

        private void MoveLeft_Click(object sender, RoutedEventArgs e)
        {
            gameSession.MoveLeft();
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            gameSession.MoveDown();
        }

        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessagesRTxbx.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessagesRTxbx.ScrollToEnd();
        }

        private void OnClick_AttackMonster(object sender, RoutedEventArgs e)
        {
            gameSession.AttackCurrentMonster();
        }

        //private void WeaponsCbx_DropDownOpened(object sender, EventArgs e)
        //{
        //    WeaponsCbx.ItemsSource = gameSession.CurrentPlayer.Weapons;
        //}

        //private void WeaponsCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    gameSession.CurrentWeapon = WeaponsCbx.SelectedItem as Weapon;
        //}
    }
}
