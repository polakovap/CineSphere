using CinesphereProject.ObjectClasses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CinesphereProject.UserControls
{
    /// <summary>
    /// Interaction logic for UpcomingMoviesView.xaml
    /// </summary>
    public partial class UpcomingMoviesView : UserControl
    {
        //declare the api key as a string
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";

        //movies endpoint
        private const string MoviesApiUrl = "https://api.themoviedb.org/3/movie/upcoming?api_key=" + ApiKey;


        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();

        public UpcomingMoviesView()
        {
            InitializeComponent();
            LoadMovieData();
        }

        //method to load movies data
        private async void LoadMovieData()
        {
            try
            {
                //get the data from api and convert to json format
                var response = await _httpClient.GetAsync(MoviesApiUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TrendingResponse<Movie>>(json);
                var movies = result?.Results;
                // Bind the movies data to UI elements
                lbxMovies.ItemsSource = movies;
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                Console.WriteLine(ex.Message);
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors
                Console.WriteLine(ex.Message);
            }
        }

        //method to open up a new view when a movie is selected
        private void lbxMovies_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxMovies.SelectedItem != null)
            {
                Movie selectedMovie = (Movie)lbxMovies.SelectedItem;

                //navigate to MovieDetailsView passing the selected movie
                MovieDetailsView movieDetailsView = new MovieDetailsView(selectedMovie);
                ((MainWindow)Application.Current.MainWindow).AddUserControl(movieDetailsView);
            }
        }
    }
}
