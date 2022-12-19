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
using System.Windows.Shapes;

namespace Practice13_15
{
    /// <summary>
    /// Логика взаимодействия для Seettings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            this.Height += 25;
        }

        private void CalculateS(object sender, RoutedEventArgs e)
        {
            Data1.ColumnCount = Int32.Parse(ColumnCountS.Text);
            Data1.RowCount = Int32.Parse(RowCountS.Text);
        }
    }
}
