using LibMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practice13_15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        Matrix<double> _matrix = new Matrix<double>(0, 0);

        private void CreateArray(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RowCount.Text, out int rowcount) & !int.TryParse(ColumnCount.Text, out int columncount))
            {
                MessageBox.Show("Неверный размер массива", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (columncount <= 0 || rowcount <= 0)
            {
                MessageBox.Show("Размер массива должен быть больше 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _matrix = new Matrix<double>(rowcount, columncount);
            _matrix.Init();

            Table.ItemsSource = _matrix.ToDataTable().DefaultView;
        }

        private void AboutProgramm(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Text");
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            int x = _matrix.Calculate();
            Answer.Text = x.ToString();
        }
    }
}
