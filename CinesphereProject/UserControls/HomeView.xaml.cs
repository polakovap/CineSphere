using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinesphereProject.ObjectClasses;
//add newtonsoft.json (installed the NuGet package)
using Newtonsoft.Json;

namespace CinesphereProject.UserControls
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        //declare the api key as a string
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";

        //movies endpoint
        private const string MoviesApiUrl = "https://api.themoviedb.org/3/trending/movie/week?api_key=" + ApiKey;

        //tv shows endpoint
        private const string TVApiUrl = "https://api.themoviedb.org/3/trending/tv/week?api_key=" + ApiKey;

        //create a HttpClient
        private HttpClient _httpClient = new HttpClient();

        public HomeView()
        {
            InitializeComponent();
            LoadMovieData();
            LoadTVShowData();
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
                // Bind the movies data to your UI elements
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

        //method to load tv shows data
        private async void LoadTVShowData()
        {
            try
            {
                //get the data from api and convert to json format
                var response = await _httpClient.GetAsync(TVApiUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TrendingResponse<TVShow>>(json);
                var shows = result?.Results;
                // Bind the TV SHOWS data to your UI elements
                lbxTVShows.ItemsSource = shows;
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
    }

    //helper class to deserialize trending response
    public class TrendingResponse<T>
    {
        public List<T> Results { get; set; }
    }


}
