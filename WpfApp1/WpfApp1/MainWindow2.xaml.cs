using Reactive.Bindings;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {

        public ObservableCollection<Object> Items { get; private set; } = new ObservableCollection<Object>();

        public MainWindow2()
        {
            InitializeComponent();

            InitData(10);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            Cursor = Cursors.Wait;

            grid.Visibility = Visibility.Visible;

            Dispatcher.InvokeAsync(new Action(() =>
            {
                Cursor = null;
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);

            App.Current.MainWindow = this;
        }

        private void InitData(int count)
        {
            Items.Clear();

            for (int i = 0; i < count; i++)
            {
                Items.Add(new Object());
            }
        }
    }
}