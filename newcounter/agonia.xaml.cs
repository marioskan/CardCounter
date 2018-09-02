using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace newcounter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class agonia : Page
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
        public agonia()
        {
            this.InitializeComponent();

        }





        private void clear_Click(object sender, RoutedEventArgs e)
        {
            sumagonia1.Text = "0";
            sumagonia2.Text = "0";
            result.Text = "";
            number1 = 0;
            number2 = 0;
            sum1 = 0;
            sum2 = 0;
            agonia1.IsEnabled = true;
            agonia2.IsEnabled = true;

        }
        int sum1 = 0;
        int sum2 = 0;
        int number1 = 0;
        int number2 = 0;
        int flag = 0;
        private void add_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(agonia1.Text, out number1))
            {
                flag = 1;
            }
            else
            {
                agonia1.Text = "Δώστε έναν έγκυρο αριθμό";
                flag = 0;
                return;
            }

            if (int.TryParse(agonia2.Text, out number2))
            {
                flag = 1;
            }
            else
            {
                agonia2.Text = "Δώστε έναν έγκυρο αριθμό";
                flag = 0;
                return;
            }

            sum1 = sum1 + number1;
            sum2 = sum2 + number2;
            sumagonia1.Text = Convert.ToString(sum1);
            sumagonia2.Text = Convert.ToString(sum2);
            agonia1.Text = "0";
            agonia2.Text = "0";

            if (sum1 >= 51)
            {
                result.Text = "Team 2 wins!";
                agonia1.IsEnabled = false;
                agonia2.IsEnabled = false;
            }
            else if (sum2 >= 51)
            {
                result.Text = "Team 1 wins!";
                agonia1.IsEnabled = false;
                agonia2.IsEnabled = false;
            }
            else if (sum1 == 51 && sum2 == 51)
            {
                result.Text = "Ισοπαλία!";
                agonia1.IsEnabled = false;
                agonia2.IsEnabled = false;
            }

        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            if (flag == 1)
            {
                if (!string.IsNullOrEmpty(sumagonia1.Text))
                {
                    sum1 = sum1 - number1;

                    sumagonia1.Text = sum1.ToString();

                }
                else
                {
                    sumagonia1.Text = "0";
                }
                if (!string.IsNullOrEmpty(sumagonia2.Text))
                {

                    sum2 = sum2 - number2;

                    sumagonia2.Text = sum2.ToString();
                }
                else
                {
                    sumagonia2.Text = "0";
                }
                flag = 0;
            }


        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            ring1.IsActive = true;
            Sum();
            IMobileServiceTable<newcountertable> countertable = App.MobileService.GetTable<newcountertable>();
            try
            {

                newcountertable obj = new newcountertable
                {
                    agoniateam1 = sumagonia1.Text,
                    agoniateam2 = sumagonia2.Text,
                    id = cheat1.Text,
                    
                };
                countertable.UpdateAsync(obj);

            }
            catch (Exception x)
            {

            }
            ring1.IsActive = false;
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {

            Default_Load();

        }

        public async void Default_Load()
        {

            try
            {
                var counterTable = App.MobileService.GetTable<newcountertable>();
                var result = await counterTable.Where(x => x.id ==cheat1.Text).ToListAsync();
                var item = result.FirstOrDefault();
                if (result.Count == 0)
                {
                    newcountertable obj=new newcountertable
                    {
                        agoniateam1 = sumagonia1.Text,
                        agoniateam2=sumagonia2.Text,
                        id=cheat1.Text,
                    };
                    await counterTable.InsertAsync(obj);
                }
                else
                {
                    sumagonia1.Text = item.agoniateam1;
                    sumagonia2.Text = item.agoniateam2;
                    sum1 = int.Parse(sumagonia1.Text);
                    sum2 = int.Parse(sumagonia2.Text);
                
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
                var result = await counterTable.Where(x => x.id != "").ToListAsync();
                var item = result.FirstOrDefault();

                sum1 = int.Parse(item.agoniateam1);
                sum2 = int.Parse(item.agoniateam2);
            }
            catch (Exception x)
            {

            }

        }

        
    }
}