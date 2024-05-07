using CinesphereProject.ObjectClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CinesphereProject.UserControls
{
    /// <summary>
    /// Interaction logic for SearchMovieView.xaml
    /// </summary>
    public partial class SearchMovieView : UserControl
    {
        //declare the api key and endpoint
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";
        private const string SearchApiUrl = "https://api.themoviedb.org/3/search/movie?api_key={0}&language=en-US&query={1}";

        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();

        //declare a variable to store what was searched 
        private readonly string _query;

        //constructor in which a searchquery is passed to add to the api endpoint
        public SearchMovieView(string searchQuery)
        {
            InitializeComponent();
            _query = searchQuery;
            LoadSearchResults();
        }

        //method to load search results
        private async void LoadSearchResults()
        {
            try
            {
                // Create the URL for the specific movie
                string url = string.Format(SearchApiUrl, ApiKey, _query);

                // Get the movie details from the API
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                //desertialize directly into a movie object
                var result = JsonConvert.DeserializeObject < TrendingResponse<Movie>>(json);
                var searchedMovies = result?.Results;

                //if no results are found, display a message
                if (searchedMovies == null || searchedMovies.Count == 0)
                {
                    searchedMovies = new List<Movie>
                    {
                        new Movie { Title = "No results found:("}
                    };
                }

                // Set the DataContext of the UserControl to the movie details
                lbxSearchedMovies.ItemsSource = searchedMovies;
                DataContext = result;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error loading movie details: " + ex.Message);
            }
        }

        //method to open up a new window in case a movie is clicked
        private void lbxSearchedMovies_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxSearchedMovies.SelectedItem != null)
            {
                Movie selectedMovie = (Movie)lbxSearchedMovies.SelectedItem;

                //navigate to MovieDetailsView passing the selected movie
                MovieDetailsView movieDetailsView = new MovieDetailsView(selectedMovie);
                ((MainWindow)Application.Current.MainWindow).AddUserControl(movieDetailsView);
            }
        }
    }
}
