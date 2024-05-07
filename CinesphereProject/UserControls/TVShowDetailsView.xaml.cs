using CinesphereProject.ObjectClasses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows.Controls;

namespace CinesphereProject.UserControls
{
    /// <summary>
    /// Interaction logic for TVShowDetailsView.xaml
    /// </summary>
    public partial class TVShowDetailsView : UserControl
    {
        //get te apikey and apiurl
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";
        private const string TVShowDetailsApiUrl = "https://api.themoviedb.org/3/tv/{0}?api_key={1}&language=en-US";

        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly TVShow _selectedTVShow;

        //constructor with chosen tvshow object
        public TVShowDetailsView(TVShow TVShow)
        {
            InitializeComponent();
            _selectedTVShow = TVShow;
            LoadTVShowDetails();
        }

        //method to load tv show data
        private async void LoadTVShowDetails()
        {
            try
            {
                // Create the URL for the specific TVShow
                string url = string.Format(TVShowDetailsApiUrl, _selectedTVShow.ID, ApiKey);

                // Get the TVShow details from the API
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                //desertialize directly into a TVShowDetails object
                var TVShowDetails = JsonConvert.DeserializeObject<TVShowDetails>(json);

                // Set the DataContext of the UserControl to the TVShow details
                DataContext = TVShowDetails;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error loading TVShow details: " + ex.Message);
            }
        }
    }
}
