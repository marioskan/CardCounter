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
        public agonia()
        {
            this.InitializeComponent();
            Default_Load();
        }

        public async void Default_Load()
        {
            
            try
            {
                var counterTable = App.MobileService.GetTable<newcountertable>();
                var result = await counterTable.Where(x => x.id=="AG").ToListAsync();
                var item = result.FirstOrDefault();
                sumagonia1.Text = item.agoniateam1;
                sumagonia2.Text = item.agoniateam2;


            }
            catch (Exception x)
            {

            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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

        }
        

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            sumagonia1.Text = "0";
            sumagonia2.Text = "0";
            result.Text = "";
        }
        int sum1 = 0;
        int sum2 = 0;
        int number1 = 0;
        int number2 = 0;
        private void add_Click(object sender, RoutedEventArgs e)
        {
            if(agoniateam1.Text!=" " && agoniateam2.Text!=" ")
            {
                number1 = int.Parse(agoniateam1.Text);
                number2 = int.Parse(agoniateam2.Text);
            }
            else if (agoniateam1.Text != " ")
            {
                number1 = int.Parse(agoniateam1.Text);
            }
            else
            {
                number2 = int.Parse(agoniateam2.Text);
            }
            sum1 = sum1 + number1;
            sum2 = sum2 + number2;
            sumagonia1.Text = Convert.ToString(sum1);
            sumagonia2.Text = Convert.ToString(sum2);
            agoniateam1.Text = "0";
            agoniateam2.Text = "0";
            if(sum1>=51)
            {
                result.Text = "Team 1 wins!";
            }
            else if (sum2>=51)
            {
                result.Text = "Team 2 wins!";
            }
            else if (sum1==51 && sum2==51)
            {
                result.Text = "Ισοπαλία!";
            }
            IMobileServiceTable<newcountertable> countertable = App.MobileService.GetTable<newcountertable>();
            try
            {
                newcountertable obj = new newcountertable();
                obj.agoniateam1 = sumagonia1.Text;
                obj.agoniateam2 = sumagonia2.Text;
                obj.id = "AG";
                countertable.InsertAsync(obj);

            }
            catch (Exception x )
            {

            }
        
        }
    }
}
