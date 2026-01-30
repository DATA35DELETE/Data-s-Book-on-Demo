using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using System.Threading;
using System.Threading.Tasks;
using Xilium.CefGlue;

namespace Data_s_Book_on_Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);

                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        WebSiteTitle.Content = Browser.Title;
                        Title = Browser.Title;
                    });
                }
            });

            Browser.Address = "file:///Data's%20Book%20on%20Demo/Lessons/Table%20Of%20Contents.html"; // Data's Demo Book url
            FaviconImage.Source = new Bitmap("Data's Book on Demo/Sources/favicon.png"); // Data's Demo Book icon

            Icon = new WindowIcon(new Bitmap("Data's Book on Demo/Sources/favicon.png")); // Data's Demo Book icon
        }

        private void GoBackWebView(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Browser.CanGoBack == true)
            {
                Browser.GoBack();
            }
        }
        private void GoForwardWebView(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Browser.CanGoForward == true)
            {
                Browser.GoForward();
            }
        }
    }
}