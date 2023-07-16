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

namespace EG_2020_4068_Desktop_UI
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            DataContext = new ViewModel();
            InitializeComponent();
        }

        public AddStudentWindow(ViewModel studentVM)
        {
            StudentVM = studentVM;
        }

        public ViewModel StudentVM { get; }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            var vm = (ViewModel)DataContext;
            vm.LoadPerson();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var vm = (ViewModel)DataContext;
            vm.InsertPerson();
            
        }
    }
}
