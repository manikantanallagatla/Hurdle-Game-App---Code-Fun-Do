using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HurdleGame1.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;

namespace PhoneApp7
{
    public partial class MainPage : PhoneApplicationPage
    {
        int randomNo;
        int Retry = 0;
        int busted = 0;
        int scoreInInteger = 0;
        //  int i = 0;
        DispatcherTimer b;
        DispatcherTimer a;
        DispatcherTimer c;
        DispatcherTimer oneSecond;
        //  DispatcherTimer d;
        int j = 0;
        public int inew = 0;
        int jumpPosition = 0;
        int hurdlePosition = 0;
        // Constructor
        public MainPage()
        {

            InitializeComponent();
            scoreInInteger = 0;
            b = new DispatcherTimer();
            b.Interval = new TimeSpan(50000000);
            b.Tick += b_Tick;
            b.Start();
            oneSecond = new DispatcherTimer();
            oneSecond.Interval = new TimeSpan(50000000);
            oneSecond.Tick += oneSecond_Tick;
            oneSecond.Start();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Retry == 1)
            {
                ScoreFinalDisplay.Opacity = 0;
                Score_Copy.Opacity = 0;
                Retry = 0;
            }
            int ScoreNormalised = scoreInInteger / 5;
            String display1 = ScoreNormalised.ToString();
            Score.Text = display1;
            Score_Copy.Text = display1;
            if (busted == 1)
            {
                Button.Opacity = 0;
                Button_Copy.Opacity = 100;
                ScoreFinalDisplay.Opacity = 100;
                Score_Copy.Opacity = 100;
                frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/busted.jpg");
                //delay 30 seconds
                Task.Delay(30000);
                scoreInInteger = 0;
                //NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));
                busted = 0;
                inew = 0;
                j = 0;
                Retry = 1;
            }
            else
            {
                if (inew == 0 && j == 0)
                {
                    Button.Opacity = 100;
                    Button_Copy.Opacity = 0;
                    frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/manStanding.jpg");
                    scoreInInteger++;
                    inew = 1;
                }
                else
                {
                    if (inew == 1 && j == 0)
                    {
                        frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/manforward.jpg");
                        scoreInInteger++;
                        inew = 0;
                    }
                    else
                    {
                        if (j == 1 && jumpPosition == 0)
                        {
                            frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/jump1.jpg");
                            scoreInInteger++;
                            jumpPosition++;
                        }
                        else
                        {
                            if (j == 1 && jumpPosition == 1)
                            {
                                frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/jump2.jpg");
                                scoreInInteger++;
                                jumpPosition++;
                            }
                            else
                            {
                                frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/jump3.jpg");
                                scoreInInteger++;
                                jumpPosition = 0;
                                inew = 0;
                                j = 0;
                            }
                        }
                    }
                }
            }
        }
        public void oneSecond_Tick(object sender, EventArgs e)
        {
            if ((hurdlePosition == 3) && (j == 0))
            {
                busted = 1;
                if (busted == 1)
                {
                    Button_Copy.Opacity = 100;
                    Button.Opacity = 0;
                    ScoreFinalDisplay.Opacity = 100;
                    Score_Copy.Opacity = 100;
                    frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/busted.jpg");
                    Button.Content = "Retry";
                    //delay 30 seconds
                    Task.Delay(30000);
                    busted = 0;
                    inew = 0;
                    j = 0;
                    scoreInInteger = 0;
                    Retry = 1;
                    // NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));

                }
            }
        }
        public void b_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            randomNo = rnd.Next(1, 500);
            if (randomNo <= 450)
            {
                RoutedEventArgs e1 = new RoutedEventArgs();
                getHurdle_Click(sender, e1);
            }
        }
        public void a_Tick(object sender, EventArgs e)
        {
            switch (hurdlePosition)
            {
                case 0:
                    hurdle1.Opacity = 100;
                    hurdle2.Opacity = 0;
                    hurdle3.Opacity = 0;
                    hurdle4.Opacity = 0;
                    hurdle5.Opacity = 0;
                    hurdlePosition++;

                    //   System.Threading.Thread.Sleep(1000);
                    //  getHurdle_Click(sender, e);
                    break;
                case 1:

                    hurdle1.Opacity = 0;
                    hurdle2.Opacity = 100;
                    hurdle3.Opacity = 0;
                    hurdle4.Opacity = 0;
                    hurdle5.Opacity = 0;
                    hurdlePosition++;
                    //   System.Threading.Thread.Sleep(1000);
                    //  getHurdle_Click(sender, e);
                    break;
                case 2:
                    if ((hurdlePosition == 2) && (j == 0))
                    {
                        busted = 1;
                        if (busted == 1)
                        {
                            Button_Copy.Opacity = 100;
                            Button.Opacity = 0;
                            Score_Copy.Opacity = 100;
                            ScoreFinalDisplay.Opacity = 100;
                            frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/busted.jpg");
                            //delay 30 seconds
                            Task.Delay(30000);
                            // NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));
                            Retry = 1;
                            busted = 0;
                            inew = 0;
                            j = 0;
                            scoreInInteger = 0;
                        }
                    }
                    hurdle1.Opacity = 0;
                    hurdle2.Opacity = 0;
                    hurdle3.Opacity = 100;
                    hurdle4.Opacity = 0;
                    hurdle5.Opacity = 0;
                    hurdlePosition++;

                    //                    System.Threading.Thread.Sleep(1000);
                    //   getHurdle_Click(sender, e);
                    break;
                case 3:

                    hurdle1.Opacity = 0;
                    hurdle2.Opacity = 0;
                    hurdle3.Opacity = 0;
                    hurdle4.Opacity = 100;
                    hurdle5.Opacity = 0;
                    hurdlePosition++;
                    // System.Threading.Thread.Sleep(1000);
                    //    getHurdle_Click(sender, e);
                    break;
                case 4:
                    hurdle1.Opacity = 0;
                    hurdle2.Opacity = 0;
                    hurdle3.Opacity = 0;
                    hurdle4.Opacity = 0;
                    hurdle5.Opacity = 100;
                    hurdlePosition = 0;
                    a.Stop();
                    Task.Delay(1000);
                    hurdle5.Opacity = 0;
                    break;
            }
        }
        public void getHurdle_Click(object sender, RoutedEventArgs e)
        {
            if (hurdlePosition == 0)
            {
                a = new DispatcherTimer();
                a.Interval = new TimeSpan(8000000);
                a.Tick += a_Tick;
                a.Start();

            }
        }
        public void c_Tick(object sender, EventArgs e)
        {
            if (jumpPosition == 0)
            {
                frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/jump1.jpg");
                jumpPosition++;
            }
            else
            {
                if (jumpPosition == 1)
                {
                    frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/jump2.jpg");
                    jumpPosition++;
                }
                else
                {
                    if (jumpPosition == 2)
                    {
                        frame.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/Assets/jump1.jpg");
                        jumpPosition = 0;
                    }
                }
            }
        }
        public void executeJump()
        {
            c = new DispatcherTimer();
            c.Interval = new TimeSpan(5000000);
            c.Tick += a_Tick;
            c.Start();

        }
        private void jump_Click(object sender, RoutedEventArgs e)
        {
            j = 1;
        }


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}

