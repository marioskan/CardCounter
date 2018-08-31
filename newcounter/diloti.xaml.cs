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
    public sealed partial class diloti : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameters = (move)e.Parameter;
            cheat1.Text = parameters.username;
            Frame rootFrame = Window.Current.Content as Frame;

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
            Default_Load();
        }
        public diloti()
        {
            this.InitializeComponent();
        }

        

        int sum1 = 0;
        int sum2 = 0;
        int number1 = 0;
        int number2 = 0;
        int flag = 0;
        private void adddiloti_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(diloti1.Text, out number1))
            {
                flag = 1;
            }
            else
            {
                diloti1.Text = "Δώστε έναν έγκυρο αριθμό";
                flag = 0;
                return;
            }

            if (int.TryParse(diloti2.Text, out number2))
            {
                flag = 1;
            }
            else
            {
                diloti2.Text = "Δώστε έναν έγκυρο αριθμό";
                flag = 0;
                return;
            }

            sum1 = sum1 + number1;
            sum2 = sum2 + number2;
            sumdiloti1.Text = Convert.ToString(sum1);
            sumdiloti2.Text = Convert.ToString(sum2);
            diloti1.Text = "0";
            diloti2.Text = "0";

            if (sum1 >= 61)
            {
                resultdiloti.Text = "Team 1 wins!";
                diloti1.IsEnabled = false;
                diloti2.IsEnabled = false;
            }
            else if (sum2 >= 61)
            {
                resultdiloti.Text = "Team 2 wins!";
                diloti1.IsEnabled = false;
                diloti2.IsEnabled = false;
            }
            else if (sum1 == 51 && sum2 == 51)
            {
                resultdiloti.Text = "Ισοπαλία!";
                diloti1.IsEnabled = false;
                diloti2.IsEnabled = false;
            }
        }

        private void undodiloti_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 1)
            {
                if (!string.IsNullOrEmpty(sumdiloti1.Text))
                {
                    sum1 = sum1 - number1;

                    sumdiloti1.Text = sum1.ToString();

                }
                else
                {
                    sumdiloti1.Text = "0";
                }
                if (!string.IsNullOrEmpty(sumdiloti2.Text))
                {

                    sum2 = sum2 - number2;

                    sumdiloti2.Text = sum2.ToString();
                }
                else
                {
                    sumdiloti2.Text = "0";
                }
                flag = 0;
            }
        }

        private void cleardiloti_Click(object sender, RoutedEventArgs e)
        {
            sumdiloti1.Text = "0";
            sumdiloti2.Text = "0";
            resultdiloti.Text = "";
            number1 = 0;
            number2 = 0;
            sum1 = 0;
            sum2 = 0;
            diloti1.IsEnabled = true;
            diloti2.IsEnabled = true;
        }

       

        private void savediloti_Click(object sender, RoutedEventArgs e)
        {
            Sum();
            IMobileServiceTable<newcountertable> countertable = App.MobileService.GetTable<newcountertable>();
            try
            {

                newcountertable obj = new newcountertable
                {
                    dilotiteam1 = sumdiloti1.Text,
                    dilotiteam2 = sumdiloti2.Text,
                    id = cheat1.Text,
                };
                countertable.UpdateAsync(obj);


            }
            catch (Exception x)
            {

            }
        }

        public async void Default_Load()
        {

            try
            {
                var counterTable = App.MobileService.GetTable<newcountertable>();
                var result = await counterTable.Where(x => x.id == cheat1.Text).ToListAsync();
                var item = result.FirstOrDefault();
                if (result.Count == 0)
                {
                    newcountertable obj = new newcountertable
                    {
                        dilotiteam1 = sumdiloti1.Text,
                        dilotiteam2 = sumdiloti2.Text,
                        id = cheat1.Text,
                    };
                    await counterTable.InsertAsync(obj);
                }
                else
                {
                    sumdiloti1.Text = item.dilotiteam1;
                    sumdiloti2.Text = item.dilotiteam2;
                    sum1 = int.Parse(sumdiloti1.Text);
                    sum2 = int.Parse(sumdiloti2.Text);
                }
           
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
                var result = await counterTable.Where(x => x.id == "di").ToListAsync();
                var item = result.FirstOrDefault();

                sum1 = int.Parse(item.dilotiteam1);
                sum2 = int.Parse(item.dilotiteam2);
            }
            catch (Exception x)
            {

            }

        }

        private void loaddiloti_Click(object sender, RoutedEventArgs e)
        {
            Default_Load();
        }




    }
}
