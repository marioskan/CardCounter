using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace newcounter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(info));
        }
      
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            base.OnNavigatedTo(e);
            var parameters = (move)e.Parameter;
            cheat.Text = parameters.username;
            
            string myPages = "";
            foreach (PageStackEntry page in rootFrame.BackStack)
            {
                myPages += page.SourcePageType.ToString() + "\n";
            }
            //stackCount.Text = myPages;

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
                SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) =>
                {
                    //Debug.WriteLine("BackRequested");
                    if (Frame.CanGoBack)
                    {
                        Frame.GoBack();
                        a.Handled = true;
                    }
                };
                Frame.GoBack();
                //a.Handled = true;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }

        }
       
      
      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            move user = new move();
            user.username = cheat.Text;
            this.Frame.Navigate(typeof(agonia),user);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            move user = new move();
            user.username = cheat.Text;
            this.Frame.Navigate(typeof(diloti),user);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            move user = new move();
            user.username = cheat.Text;
            this.Frame.Navigate(typeof(xeri),user);
        }
    }
}
