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

namespace InterfaceBlackJackWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Hit.Visibility = System.Windows.Visibility.Hidden;
            Split.Visibility = System.Windows.Visibility.Hidden;
            YourScore.Visibility = System.Windows.Visibility.Hidden;
            EnemyScore.Visibility = System.Windows.Visibility.Hidden;
            Win.Visibility = System.Windows.Visibility.Hidden;
            Hit.IsEnabled = false;
            Split.IsEnabled = false;
        }
        static int[] scorecard = new int[13] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
        static int numbercard;
        static int numbercardenemy;
        static int score;
        static int scorenemy;
        static int timescorenemy;

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int number;
            number = random.Next(0, 13);
            if (number == 13 && score > 10) score++;
            else score = score + scorecard[number];
            YourScore.Content = String.Format("Ваш счет: {0}", score);
            if (score > 21)
            {
                scorenemy += timescorenemy;
                EnemyScore.Content = String.Format("Счет противника: {0}", scorenemy);
                Win.Content = ("You Lose!!!");
                Hit.IsEnabled = false;
                Split.IsEnabled = false;
                Hit.Visibility = System.Windows.Visibility.Hidden;
                Split.Visibility = System.Windows.Visibility.Hidden;
                Win.Visibility = System.Windows.Visibility.Visible;
            }
            else if ((score == 21) && (score > scorenemy))
            {
                scorenemy += timescorenemy;
                EnemyScore.Content = String.Format("Счет противника: {0}", scorenemy);
                Win.Content = ("You Win!!!");
                Hit.IsEnabled = false;
                Split.IsEnabled = false;
                Hit.Visibility = System.Windows.Visibility.Hidden;
                Split.Visibility = System.Windows.Visibility.Hidden;
                Win.Visibility = System.Windows.Visibility.Visible;
            }
            else if ((score == 21) && (score < scorenemy))
            {
                scorenemy += timescorenemy;
                EnemyScore.Content = String.Format("Счет противника: {0}", scorenemy);
                Win.Content = ("You Win!!!");
                Hit.IsEnabled = false;
                Split.IsEnabled = false;
                Hit.Visibility = System.Windows.Visibility.Hidden;
                Split.Visibility = System.Windows.Visibility.Hidden;
                Win.Visibility = System.Windows.Visibility.Visible;
            }
            else if ((score == 21) && (score == scorenemy))
            {
                scorenemy += timescorenemy;
                EnemyScore.Content = String.Format("Счет противника: {0}", scorenemy);
                Win.Content = ("You Lose!!!");
                Hit.IsEnabled = false;
                Split.IsEnabled = false;
                Hit.Visibility = System.Windows.Visibility.Hidden;
                Split.Visibility = System.Windows.Visibility.Hidden;
                Win.Visibility = System.Windows.Visibility.Visible;
            }

            else if ((score == scorenemy) && (score > 21))
            {
                scorenemy += timescorenemy;
                EnemyScore.Content = String.Format("Счет противника: {0}", scorenemy);
                Win.Content = ("You Lose!!!");
                Hit.IsEnabled = false;
                Split.IsEnabled = false;
                Hit.Visibility = System.Windows.Visibility.Hidden;
                Split.Visibility = System.Windows.Visibility.Hidden;
                Win.Visibility = System.Windows.Visibility.Visible;
            }
            else { }
        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {
            YourScore.Visibility = System.Windows.Visibility.Visible;
            EnemyScore.Visibility = System.Windows.Visibility.Visible;
            Random random = new Random();
            int number;
            int numcard = 0;
            scorenemy += timescorenemy;
            if (scorenemy > 15) numcard = 1;
            else if (scorenemy < 15) numcard = 2;
            else if (scorenemy < 20) numcard = 0;
            while (numcard != 0)
            {
                number = random.Next(0, 13);
                if (number == 13 && scorenemy > 10) scorenemy++;
                else scorenemy = scorenemy + scorecard[number];
                numcard--;
            }
            Hit.IsEnabled = false;
            Split.IsEnabled = false;
            Hit.Visibility = System.Windows.Visibility.Hidden;
            Split.Visibility = System.Windows.Visibility.Hidden;
            Win.Visibility = System.Windows.Visibility.Visible;
            YourScore.Content = String.Format("Ваш счет: {0}", score);
            EnemyScore.Content = String.Format("Счет противника: {0}", scorenemy);
            if (score > 21) Win.Content = ("You Lose!!!");
            else if ((score == 21) && (score > scorenemy)) Win.Content = ("You Win!!!");
            else if ((score == 21) && (score < scorenemy)) Win.Content = ("You Win!!!");
            else if ((score == 21) && (score == scorenemy)) Win.Content = ("You Lose!!!");
            else if ((score == scorenemy) && (score > 21)) Win.Content = ("You Lose!!!");
            else if ((score == scorenemy) && (score < 21)) Win.Content = ("You Lose!!!");
            else if (((score < scorenemy) && (score < 21)) && (scorenemy < 21)) Win.Content = ("You Lose!!!");
            else if (((score < scorenemy) && (score < 21)) && (scorenemy == 21)) Win.Content = ("You Lose!!!");
            else if (((score < scorenemy) && (score < 21)) && (scorenemy > 21)) Win.Content = ("You Win!!!");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
           
            Random random = new Random();
            int number;
            for (int i = 0; i < 2; i++)
            {
                number = random.Next(0, 13);
                if (number == 13 && score > 10) score++;
                else score+=scorecard[number];
            }
            //generation enemy
            number = random.Next(0, 13);
            timescorenemy+=scorecard[number];
            //generation open card enemy
            number = random.Next(0, 13);
            if (number == 13 && timescorenemy > 10) scorenemy++;
            else scorenemy+=scorecard[number];
            YourScore.Content = String.Format("Ваш счет: {0}", score);
            EnemyScore.Content = String.Format("Счет противника: {0} + 1 карта не известна", scorenemy);
            Start.IsEnabled = false;
            Start.Visibility = System.Windows.Visibility.Hidden;
            if ((score == 21) && (score > scorenemy))
            {
                Win.Content = ("You Win!!!");
                scorenemy += timescorenemy;
                EnemyScore.Content = String.Format("Счет противника: {0}", scorenemy);
                Hit.IsEnabled = false;
                Split.IsEnabled = false;
                Hit.Visibility = System.Windows.Visibility.Hidden;
                Split.Visibility = System.Windows.Visibility.Hidden;
                Win.Visibility = System.Windows.Visibility.Visible;
            }
            Hit.IsEnabled = true;
            Split.IsEnabled = true;
            Hit.Visibility = System.Windows.Visibility.Visible;
            Split.Visibility = System.Windows.Visibility.Visible;
            YourScore.Visibility = System.Windows.Visibility.Visible;
            EnemyScore.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
