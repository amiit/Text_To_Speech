using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.Networking;
using Windows.Web;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace text2speech
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       // public event DisplayPropertiesEventHandler OrientationChanged;

      //  public event WindowSizeChangedEventHandler sizechanged;
          
        public MainPage()
        {

            this.InitializeComponent();
            msg_txt.GotFocus += msg_txt_GotFocus;
            snap_msg.GotFocus += snap_msg_GotFocus;
            media1.BufferingProgressChanged += media1_BufferingProgressChanged;
            snappedgrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            es.IsChecked = true;
            en1.IsChecked = true;
            Window.Current.SizeChanged += MainPage_sizechanged;
           
             
            //this.Window.sizechanged += MainPage_sizechanged;
            
        }

        private void snap_msg_GotFocus(object sender, RoutedEventArgs e)
        {
            //snap_msg.Text = "";
        }

        private void MainPage_sizechanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {

           
            try
            {
                if (ApplicationViewState.Snapped == ApplicationView.Value)
                {
                    gridfull.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                    snappedgrid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    snap_msg.Text = "";
                    snap_msg.Text = msg_txt.Text;
                    
                }
                else if (ApplicationViewState.Filled == ApplicationView.Value)
                {
                    if (gridfull.Visibility == Windows.UI.Xaml.Visibility.Collapsed)
                    {
                        gridfull.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        snappedgrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                        msg_txt.Text = "";
                        msg_txt.Text = snap_msg.Text;
                    }
                }
                else if (ApplicationViewState.FullScreenLandscape == ApplicationView.Value)
                {
                    if (gridfull.Visibility == Windows.UI.Xaml.Visibility.Collapsed)
                    {
                        gridfull.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        snappedgrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                        msg_txt.Text = "";
                        msg_txt.Text = snap_msg.Text;
                    }
                }
                else if (ApplicationViewState.FullScreenPortrait == ApplicationView.Value)
                {
                    if (gridfull.Visibility == Windows.UI.Xaml.Visibility.Collapsed)
                    {
                        gridfull.Visibility = Windows.UI.Xaml.Visibility.Visible;
                        snappedgrid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                        msg_txt.Text = "";
                        msg_txt.Text = snap_msg.Text;
                    }
                }
            }
            catch
            { 
            
            }
        }

       

        private void msg_txt_GotFocus(object sender, RoutedEventArgs e)
        {
            msg_txt.Text = "";
        }

      

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //convert tp playop
            try
            {
                
               // media1.Volume = 10;
                string ln = "";
                if ((bool)en.IsChecked)
                {
                    ln = "en";
                }
                if ((bool)es.IsChecked)
                {
                    ln = "es";
                }
                if ((bool)fr.IsChecked)
                {
                    ln = "fr";
                }
                if ((bool)de.IsChecked)
                {
                    ln = "de";
                }
                if ((bool)it.IsChecked)
                {
                    ln = "it";
                }
                if ((bool)ht.IsChecked)
                {
                    ln = "ht";
                }
                                
                prog1.IsIndeterminate = true;
                
               Uri url = new Uri("http://translate.google.com/translate_tts?tl="+ln+"&q="+msg_txt.Text+"", UriKind.Absolute);
              
               media1.Source = url;
               
               media1.Play();

              if (prog2.Value == 100)
               {
                   Task.Delay(2000);
                   prog2.Value = 0;
               }
               prog1.IsIndeterminate = false;


               // media1.Stop();
               
            }
            catch {
                MessageDialog msgdlg = new MessageDialog("sorry for error");
                msgdlg.ShowAsync();
            }
        }

        private void media1_BufferingProgressChanged(object sender, RoutedEventArgs e)
        {
            prog2.Value = (media1.BufferingProgress * 100);
            
        }

   
        void clearall()
        {
            msg_txt.Text = "";
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           media1.Stop();
        
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (pause.Content.Equals("Pause"))
            {
                media1.Pause();
                pause.Content = "Re-Play";
            }
            else if (pause.Content.Equals("Re-Play"))
            {
                media1.Play();
                pause.Content = "Pause";
            }
        }

        private void snap_btn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                // media1.Volume = 10;
                string ln = "";
                if ((bool)en1.IsChecked)
                {
                    ln = "en";
                }
                if ((bool)es1.IsChecked)
                {
                    ln = "es";
                }
                if ((bool)fr1.IsChecked)
                {
                    ln = "fr";
                }
                if ((bool)de1.IsChecked)
                {
                    ln = "de";
                }
                if ((bool)it1.IsChecked)
                {
                    ln = "it";
                }
                if ((bool)ht1.IsChecked)
                {
                    ln = "ht";
                }


                snap_prog1.IsIndeterminate = true;

                Uri url = new Uri("http://translate.google.com/translate_tts?tl=" + ln + "&q=" +snap_msg.Text+ "", UriKind.Absolute);

                media1.Source = url;

                media1.Play();

                snap_prog1.IsIndeterminate = false;


                // media1.Stop();

            }
            catch
            {
                MessageDialog msgdlg = new MessageDialog("sorry for error");
                msgdlg.ShowAsync();
            }
        }
    }
}
