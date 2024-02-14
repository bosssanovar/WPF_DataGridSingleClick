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
        private const int InitCulumnCount = 100;

        public ObservableCollection<Detail> Items { get; private set; } = new ObservableCollection<Detail>();

        public MainWindow2()
        {
            InitializeComponent();

            InitData(InitCulumnCount);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            Cursor = Cursors.Wait;

            InitColumns(InitCulumnCount);

            grid.Visibility = Visibility.Visible;

            Dispatcher.InvokeAsync(new Action(() =>
            {
                Cursor = null;
            }), System.Windows.Threading.DispatcherPriority.ApplicationIdle);

            App.Current.MainWindow = this;
        }

        private void InitColumns(int count)
        {
            grid.Columns.Clear();

            var converter = new BooleanToVisibilityConverter();
            for (int columnIndex = 0; columnIndex < count; ++columnIndex)
            {
                var binding = new Binding($"V[{columnIndex}].Value");
                binding.Converter = converter;

                var factory = new FrameworkElementFactory(typeof(Rectangle));
                factory.SetValue(Rectangle.HeightProperty, 10.0);
                factory.SetValue(Rectangle.WidthProperty, 10.0);
                factory.SetValue(Rectangle.FillProperty, Brushes.LightSkyBlue);
                factory.SetBinding(Rectangle.VisibilityProperty, binding);

                var dataTemplate = new DataTemplate();
                dataTemplate.VisualTree = factory;

                var column = new DataGridTemplateColumn();
                column.CellTemplate = dataTemplate;

                grid.Columns.Add(column);
            }
        }

        private void InitData(int count)
        {
            // バインドを切断
            Binding b = new Binding("Items")
            {
                Source = null
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);

            var list = new List<Detail>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new Detail(InitCulumnCount));
            }

            Items = new ObservableCollection<Detail>(list);

            b = new Binding("Items")
            {
                Source = this
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);
        }

        private void DataGridCell_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (grid.SelectedCells.Count == 1)
            {
                var cell = sender as DataGridCell;
                if (cell is null) return;

                var columnIndex = cell.Column.DisplayIndex;
                var rowIndex = grid.Items.IndexOf(grid.CurrentItem);

                Items[rowIndex].Invert(columnIndex);
            }
        }
    }
}