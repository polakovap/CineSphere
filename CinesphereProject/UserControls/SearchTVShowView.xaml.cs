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
    /// Interaction logic for SearchTVShowView.xaml
    /// </summary>
    public partial class SearchTVShowView : UserControl
    {
        //declare the api key and endpoint
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";
        private const string SearchApiUrl = "https://api.themoviedb.org/3/search/tv?api_key={0}&language=en-US&query={1}";

        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();

        //declare a variable to store what was searched 
        private readonly string _query;

        //constructor in which a searchquery is passed to add to the api endpoint
        public SearchTVShowView(string searchQuery)
        {
            InitializeComponent();
            _query = searchQuery;
            LoadSearchResults();
        }

        //method to load search data
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

                //desertialize directly into a TV show object
                var result = JsonConvert.DeserializeObject<TrendingResponse<TVShow>>(json);
                var searchedTVShows = result?.Results;

                //if no results are found, display a message
                if (searchedTVShows == null || searchedTVShows.Count == 0)
                {
                    searchedTVShows = new List<TVShow>
                    {
                        new TVShow { Name = "No results found:("}
                    };
                }

                // Set the DataContext of the UserControl to the movie details
                lbxSearchedTVShows.ItemsSource = searchedTVShows;
                DataContext = result;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error loading movie details: " + ex.Message);
            }
        }

        //method to open up a new view when a tv show is selected
        private void lbxSearchedTVShows_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxSearchedTVShows.SelectedItem != null)
            {
                TVShow selectedTVShow = (TVShow)lbxSearchedTVShows.SelectedItem;

                //navigate to TVShowDetailsView passing the selected show
                TVShowDetailsView tvShowDetailsView = new TVShowDetailsView(selectedTVShow);
                ((MainWindow)Application.Current.MainWindow).AddUserControl(tvShowDetailsView);
            }
        }
    }
}
