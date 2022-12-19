using LibMatrix;
using Microsoft.Win32;
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
using System.Windows.Media.Media3D;
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

        Matrix<double> _matrix = new Matrix<double>(0, 0);

        private void CreateArray(object sender, RoutedEventArgs e)
        {
            try
            {

                _matrix = new Matrix<double>(Int32.Parse(RowCount.Text), Int32.Parse(ColumnCount.Text));
                _matrix.Init();

                Table.ItemsSource = _matrix.ToDataTable().DefaultView;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new();
                saveFileDialog.DefaultExt = _matrix.Extension;
                if (saveFileDialog.ShowDialog() == true)
                {
                    _matrix.Save(saveFileDialog.FileName);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Выбран неверный файл", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.DefaultExt = _matrix.Extension;
            openFileDialog.Filter = "Матрица| *.matrix";
            if (openFileDialog.ShowDialog() == true)
            {
                _matrix.Load(openFileDialog.FileName);
                Table.ItemsSource = _matrix.ToDataTable().DefaultView;
            }
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            int x = _matrix.Calculate();
            Answer.Text = x.ToString();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AboutProgramm(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана целочисленная матрица размера M * N. Найти количество ее столбцов, все\r\nэлементы которых различны");
        }

        private void RowChange(object sender, TextChangedEventArgs e)
        {
            Answer.Text = null;
            Table.ItemsSource = null;
        }

        private void ColumnChange(object sender, TextChangedEventArgs e)
        {
            Answer.Text = null;
            Table.ItemsSource = null;
        }

        private void WindowStart(object sender, RoutedEventArgs e)
        {
            Login password = new();
            password.Owner = this;
            password.ShowDialog();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            Settings sett = new Settings();
            sett.ShowDialog();
        }
    }
}
