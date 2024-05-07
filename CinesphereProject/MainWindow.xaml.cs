using CinesphereProject.UserControls;
using System.Windows;
using System.Windows.Controls;

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

        internal void AddUserControl(UserControl userControl)
        {
            //add children - view, to the stack panel
            viewContainer.Children.Clear();
            viewContainer.Children.Add(userControl);
        }

        private void SetHomeView()
        {
            HomeView hvw = new HomeView();
            AddUserControl(hvw);
        }

        //methods for changing views based on the button that was clicked in the menu
        private void rbtnHome_Click(object sender, RoutedEventArgs e)
        {
           SetHomeView();
        }

        private void rbtnMovies_Click(object sender, RoutedEventArgs e)
        {
            UpcomingMoviesView hvw = new UpcomingMoviesView();
            AddUserControl(hvw);
        }

        private void rbtnTVShows_Click(object sender, RoutedEventArgs e)
        {
            AiringTVShowsView hvw = new AiringTVShowsView();
            AddUserControl(hvw);
        }

        //window loaded method to set the homeview when you open the app
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetHomeView();
        }

        //method to delete all previous text from the searchbox when clicking on it
        private void tbxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSearch.Clear();
        }

        //methods to open new view after one of the search buttons is clicked
        private void btnSearchMovie_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = tbxSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                // Create an instance of the search results view UserControl
                SearchMovieView searchMovieView = new SearchMovieView(searchQuery);

                // Add the search results view UserControl to the view container
                AddUserControl(searchMovieView);
            }
            else
            {
                // Display a message to prompt the user to enter a search query first
                MessageBox.Show("Please enter a search query first.", "Empty Search Query", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnSearchTV_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = tbxSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                // Create an instance of the search results view UserControl
                SearchTVShowView searchTVShowView = new SearchTVShowView(searchQuery);

                // Add the search results view UserControl to the view container
                AddUserControl(searchTVShowView);
            }
            else
            {
                // Display a message to prompt the user to enter a search query first
                MessageBox.Show("Please enter a search query first.", "Empty Search Query", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnSearchPerson_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = tbxSearch.Text.Trim();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                // Create an instance of the search results view UserControl
                SearchPersonView searchPersonView = new SearchPersonView(searchQuery);

                // Add the search results view UserControl to the view container
                AddUserControl(searchPersonView);
            }
            else
            {
                // Display a message to prompt the user to enter a search query first
                MessageBox.Show("Please enter a search query first.", "Empty Search Query", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
