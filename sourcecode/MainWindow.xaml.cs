using System;
using System.Collections.Generic;
using System.Linq;
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

using Library;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICounter count1;

        public MainWindow()
        {
            InitializeComponent();
            count1 = new CounterImpl();
            //count1.CountChanged += Counter_CountChanged;
            DataContext = count1;
        }

        public MainWindow(ICounter myCounter)
        {
            InitializeComponent();
            count1 = myCounter;
            DataContext = count1;
        }

        private void pp_Click(object sender, RoutedEventArgs e)
        {
            count1.Increment();

        }

        private void mm_Click(object sender, RoutedEventArgs e)
        {
            count1.Decrement();
        }

        private void res_Click(object sender, RoutedEventArgs e)
        {
            count1.Reset();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Counter_CountChanged(ICounter sender, CountChangedEventArgs e)
        {
            mCountValue.Text = e.NewValue.ToString();
        }

    }
}
