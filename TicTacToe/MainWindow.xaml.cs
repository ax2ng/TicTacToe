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

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private string value = "x";
        private int xWins = 0;
        private int oWins = 0;
        

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            ResetButtons();
            xWins = 0;
            oWins = 0;
            LabelPlayerX.Content = " 0";
            LabelPlayerO.Content = " 0";
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Foreground = Brushes.Black;
            button.IsEnabled = false;
            

            if (IsWin(Button1, Button2, Button3)) GameOver(Button1.Content.ToString());
            if (IsWin(Button4, Button5, Button6)) GameOver(Button4.Content.ToString());
            if (IsWin(Button7, Button8, Button9)) GameOver(Button7.Content.ToString());
            if (IsWin(Button1, Button4, Button7)) GameOver(Button1.Content.ToString());
            if (IsWin(Button2, Button5, Button8)) GameOver(Button2.Content.ToString());
            if (IsWin(Button3, Button6, Button9)) GameOver(Button3.Content.ToString());
            if (IsWin(Button1, Button5, Button9)) GameOver(Button1.Content.ToString());
            if (IsWin(Button3, Button5, Button7)) GameOver(Button3.Content.ToString());

            if (!Button1.IsEnabled && !Button2.IsEnabled && !Button3.IsEnabled &&
                !Button4.IsEnabled && !Button5.IsEnabled && !Button6.IsEnabled &&
                !Button7.IsEnabled && !Button8.IsEnabled && !Button9.IsEnabled)
                GameOver("");

            value = value == "X" ? "O" : "X";


        }
        private void GameOver(string end)
        {
            if (WinnerX.Visibility == Visibility.Visible) return;
            if (end == "X")
            {
                WinnerX.Content = "Player X Win!";
                LabelPlayerX.Content = $" {++xWins}";
            }
            else if (end == "O")
            {
                WinnerX.Content = "Player O Win!";
                LabelPlayerO.Content = $" {++oWins}";
            }
            else WinnerX.Content = "No Winner!";
            WinnerX.Visibility = Visibility.Visible;
            Wait1SecAndRestart();
            

            
        }

        private async void Wait1SecAndRestart()
        {
            await Task.Delay(1000);
            WinnerX.Visibility = Visibility.Hidden;
            ResetButtons();
        }

        private void ResetButtons()
        {
            ResetButtons(Button1);
            ResetButtons(Button2);
            ResetButtons(Button3);
            ResetButtons(Button4);
            ResetButtons(Button5);
            ResetButtons(Button6);
            ResetButtons(Button7);
            ResetButtons(Button8);
            ResetButtons(Button9);
        }

        private void ResetButtons(Button button)
        {
            button.Content = "";
            button.IsEnabled = true;
            
        }

        private bool IsWin(Button Button1, Button Button2, Button Button3) =>
            !Button1.IsEnabled && Button1.Content == Button2.Content && Button1.Content == Button3.Content;

        private void button_Enter(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.Content = value;
        }
        private void button_Leave(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (button.IsEnabled)
                button.Content = "";
        }
       
    }
}
