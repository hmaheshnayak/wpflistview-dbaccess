using ListView_DatabaseAccess.ViewModels;
using System.Windows;
namespace ListView_DatabaseAccess.Views
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

        private void EmployeesViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeesViewModel employeesVM = new EmployeesViewModel();
            employeesVM.LoadEmployees();

            EmployeesListView employeesView = sender as EmployeesListView;

            if (employeesView != null)
            {
                employeesView.DataContext = employeesVM;
            }
        }
    }
}
