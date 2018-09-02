using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace newcounter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class xeri : Page
    {

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            string myPages = "";
            base.OnNavigatedTo(e);
            var paramteters = (move)e.Parameter;
            cheat1.Text = paramteters.username;


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
            Default_Load();

        }

        public xeri()
        {
            this.InitializeComponent();
        }

        private void clearxeri_Click(object sender, RoutedEventArgs e)
        {
            sumxeri1.Text = "0";
            sumxeri2.Text = "0";
            resultxeri.Text = "";
            number1 = 0;
            number2 = 0;
            sum1 = 0;
            sum2 = 0;
            xeri1.IsEnabled = true;
            xeri2.IsEnabled = true;
        }
        int sum1 = 0;
        int sum2 = 0;
        int number1 = 0;
        int number2 = 0;
        int flag = 0;
        private void addxeri_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(xeri1.Text, out number1))
            {
                flag = 1;
            }
            else
            {
                xeri1.Text = "Δώστε έναν έγκυρο αριθμό";
                flag = 0;
                return;
            }

            if (int.TryParse(xeri2.Text, out number2))
            {
                flag = 1;
            }
            else
            {
                xeri2.Text = "Δώστε έναν έγκυρο αριθμό";
                flag = 0;
                return;
            }

            sum1 = sum1 + number1;
            sum2 = sum2 + number2;
            sumxeri1.Text = Convert.ToString(sum1);
            sumxeri2.Text = Convert.ToString(sum2);
            xeri1.Text = "0";
            xeri2.Text = "0";

            if (sum1 >= 51)
            {
                resultxeri.Text = "Team 2 wins!";
                xeri1.IsEnabled = false;
                xeri2.IsEnabled = false;
            }
            else if (sum2 >= 51)
            {
                resultxeri.Text = "Team 1 wins!";
                xeri1.IsEnabled = false;
                xeri2.IsEnabled = false;
            }
            else if (sum1 == 51 && sum2 == 51)
            {
                resultxeri.Text = "Ισοπαλία!";
                xeri1.IsEnabled = false;
                xeri2.IsEnabled = false;
            }
        }

        private void undoxeri_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 1)
            {
                if (!string.IsNullOrEmpty(sumxeri1.Text))
                {
                    sum1 = sum1 - number1;

                    sumxeri1.Text = sum1.ToString();

                }
                else
                {
                    sumxeri1.Text = "0";
                }
                if (!string.IsNullOrEmpty(sumxeri2.Text))
                {

                    sum2 = sum2 - number2;

                    sumxeri2.Text = sum2.ToString();
                }
                else
                {
                    sumxeri2.Text = "0";
                }
                flag = 0;
            }



        }

        private void savexeri_Click(object sender, RoutedEventArgs e)
        {
            ring2.IsActive = true;
            Sum();
            IMobileServiceTable<newcountertable> countertable = App.MobileService.GetTable<newcountertable>();
            try
            {

                newcountertable obj = new newcountertable();
                obj.xeriteam1 = sumxeri1.Text;
                obj.xeriteam2 = sumxeri2.Text;
                obj.id = cheat1.Text;
                countertable.UpdateAsync(obj);


            }
            catch (Exception x)
            {

            }
            ring2.IsActive = false;
        }

        public async void Default_Load()
        {

            try
            {
                var counterTable = App.MobileService.GetTable<newcountertable>();
                var result = await counterTable.Where(x => x.id == cheat1.Text).ToListAsync();
                var item = result.FirstOrDefault();
                if(result.Count==0)
                {
                    newcountertable obj = new newcountertable
                    {
                     xeriteam1 = sumxeri1.Text,
                    xeriteam2 = sumxeri2.Text,
                    id = cheat1.Text
                    
                };
                await counterTable.InsertAsync(obj);


            }
                sumxeri1.Text = item.xeriteam1;
                sumxeri2.Text = item.xeriteam2;
                sum1 = int.Parse(sumxeri1.Text);
                sum2 = int.Parse(sumxeri2.Text);
            }
            catch (Exception x)
            {

            }

        }
        public async void Sum()
        {

            try
            {
                var counterTable = App.MobileService.GetTable<newcountertable>();
                var result = await counterTable.Where(x => x.id == "xe").ToListAsync();
                var item = result.FirstOrDefault();

                sum1 = int.Parse(item.xeriteam1);
                sum2 = int.Parse(item.xeriteam2);
            }
            catch (Exception x)
            {

            }

        }

        private void loadxeri_Click(object sender, RoutedEventArgs e)
        {
            Default_Load();
        }
    }
}
        
 
