using CinesphereProject.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace CinesphereProject
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

        private void addUserControl(UserControl userControl)
        {
            //add children - view, to the stack panel
            viewContainer.Children.Clear();
            viewContainer.Children.Add(userControl);
        }

        private void setHomeView()
        {
            HomeView hvw = new HomeView();
            addUserControl(hvw);
        }
        private void rbtnHome_Click(object sender, RoutedEventArgs e)
        {
           setHomeView();
        }

        private void rbtnMovies_Click(object sender, RoutedEventArgs e)
        {
            MoviesView hvw = new MoviesView();
            addUserControl(hvw);
        }

        private void rbtnTVShows_Click(object sender, RoutedEventArgs e)
        {
            TVShowsView hvw = new TVShowsView();
            addUserControl(hvw);
        }

        private void rbtnProviders_Click(object sender, RoutedEventArgs e)
        {
            ProvidersView hvw = new ProvidersView();
            addUserControl(hvw);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setHomeView();
        }
    }
}
