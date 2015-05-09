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
        static int numbercard = 1;
        static int numbercardenemy = 2;
        static int score;
        static int scorenemy;
        static int timescorenemy;
        static int numbertime;
        static int number2time;

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int number;
            int number2;
            number = random.Next(0, 13);
            number2 = random.Next(0, 3);
            switch (numbercard)
            {
                case 1: Image1.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 2: Image2.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 3: Image3.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 4: Image4.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 5: Image5.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 6: Image6.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 7: Image7.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 8: Image8.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                default: MessageBox.Show("Количество карт вышло за пределы. Изправится в следущей версии");
                    break;
            }
            numbercard++;
            if (number == 12 && score > 10) score++;
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
                ImageEnemy1.Source = new BitmapImage(new Uri("C://Resources//card" + numbertime + "_" + number2time + ".png"));
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
                ImageEnemy1.Source = new BitmapImage(new Uri("C://Resources//card" + numbertime + "_" + number2time + ".png"));
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
                ImageEnemy1.Source = new BitmapImage(new Uri("C://Resources//card" + numbertime + "_" + number2time + ".png"));
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
                ImageEnemy1.Source = new BitmapImage(new Uri("C://Resources//card" + numbertime + "_" + number2time + ".png"));
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
                ImageEnemy1.Source = new BitmapImage(new Uri("C://Resources//card" + numbertime + "_" + number2time + ".png"));
            }
            else { }
        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {
            YourScore.Visibility = System.Windows.Visibility.Visible;
            EnemyScore.Visibility = System.Windows.Visibility.Visible;
            Random random = new Random();
            int number;
            int number2;
            int numcard = 0;
            scorenemy += timescorenemy;
            if (scorenemy > 15) numcard = 1;
            else if (scorenemy < 15) numcard = 2;
            else if (scorenemy < 20) numcard = 0;
            ImageEnemy1.Source = new BitmapImage(new Uri("C://Resources//card"+numbertime+"_"+number2time+".png"));
            while (numcard != 0)
            {
                number = random.Next(0,12);
                number2 = random.Next(0, 3);
                switch (numbercardenemy)
                {
                    case 2: ImageEnemy2.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 3: ImageEnemy3.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 4: ImageEnemy4.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 5: ImageEnemy5.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 6: ImageEnemy6.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 7: ImageEnemy7.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 8: ImageEnemy8.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    default: MessageBox.Show("Количество карт вышло за пределы. Изправится в следущей версии");
                        break;
                }
                numbercardenemy++;
                if (number == 12 && scorenemy > 10) scorenemy++;
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
            else if (((score > scorenemy) && (score<21)) && (scorenemy<21)) Win.Content = ("You Win!!!");
            else Win.Content = ("You Lose!!!");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
           
            Random random = new Random();
            int number;
            int number2;
            for (int i = 0; i < 2; i++)
            {
                number = random.Next(0, 13);
                number2 = random.Next(0, 3);
                switch (numbercard) { 
                    case 1: Image1.Source = new BitmapImage(new Uri("C://Resources//card"+number+"_"+number2+".png"));
                        break;
                    case 2: Image2.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 3: Image3.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 4: Image4.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 5: Image5.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 6: Image6.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 7: Image7.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    case 8: Image8.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                        break;
                    default: MessageBox.Show("Количество карт вышло за пределы. Изправится в следущей версии");
                        break;
                }
                numbercard++;
                if (number == 12 && score > 10) score++;
                else score+=scorecard[number];

            }
            //generation enemy
            numbertime = random.Next(0, 13);
            number2time = random.Next(0,3);
            ImageEnemy1.Source = new BitmapImage(new Uri("C://Resources//card.jpg"));
            timescorenemy+=scorecard[numbertime];
            //generation open card enemy
            number = random.Next(0, 13);
            number2 = random.Next(0, 3);
            switch (numbercardenemy)
            {
                case 2: ImageEnemy2.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 3: ImageEnemy3.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 4: ImageEnemy4.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 5: ImageEnemy5.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 6: ImageEnemy6.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 7: ImageEnemy7.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                case 8: ImageEnemy8.Source = new BitmapImage(new Uri("C://Resources//card" + number + "_" + number2 + ".png"));
                    break;
                default: MessageBox.Show("Количество карт вышло за пределы. Изправится в следущей версии");
                    break;
            }
            numbercardenemy++;
            if (number == 12 && timescorenemy > 10) scorenemy++;
            else scorenemy+=scorecard[number];
            YourScore.Content = String.Format("Ваш счет: {0}", score);
            EnemyScore.Content = String.Format("Счет противника: {0} + 1 карта не известна", scorenemy);
            Start.IsEnabled = false;
            Start.Visibility = System.Windows.Visibility.Hidden;
            Hit.IsEnabled = true;
            Split.IsEnabled = true;
            Hit.Visibility = System.Windows.Visibility.Visible;
            Split.Visibility = System.Windows.Visibility.Visible;
            YourScore.Visibility = System.Windows.Visibility.Visible;
            EnemyScore.Visibility = System.Windows.Visibility.Visible;
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

        }
    }
}
