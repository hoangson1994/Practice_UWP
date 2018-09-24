using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Practice_UWP
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

        private async void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            
            var fold = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                // file found
                StorageFile file = await fold.GetFileAsync(Text_File.Text);
                string result = await FileIO.ReadTextAsync(file);
                if (result != Text_Content.Text)
                {
                    Message.Text = "File found but text not found";
                    await this.My_Dialog.ShowAsync();
                }
                else
                {
                    Message.Text = "File found and text found";
                    await this.My_Dialog.ShowAsync();
                }
            }
            catch(Exception)
            {
                // file not found
                Message.Text = "File not found";
                await this.My_Dialog.ShowAsync();
            }
            
        }      

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            My_Dialog.Hide();
        }
    }
}
