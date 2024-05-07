using CinesphereProject.ObjectClasses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Windows.Controls;


namespace CinesphereProject.UserControls
{
    /// <summary>
    /// Interaction logic for MovieDetailsView.xaml
    /// </summary>
    public partial class MovieDetailsView : UserControl
    {
        //set the api key and apiurl
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";
        private const string MovieDetailsApiUrl = "https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=en-US";

        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly Movie _selectedMovie;

        //constructer with a movie object so whenever a movie is clicked it will send the specific movie object to this constructor
        public MovieDetailsView(Movie movie)
        {
            InitializeComponent();
            _selectedMovie = movie;
            LoadMovieDetails();
        }

        //method to load movie details
        private async void LoadMovieDetails()
        {
            try
            {
                // Create the URL for the specific movie
                string url = string.Format(MovieDetailsApiUrl, _selectedMovie.ID, ApiKey);

                // Get the movie details from the API
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                //desertialize directly into a MovieDetails object
                var movieDetails = JsonConvert.DeserializeObject<MovieDetails>(json);

                // Set the DataContext of the UserControl to the movie details
                DataContext = movieDetails;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error loading movie details: " + ex.Message);
            }
        }
    }
}
