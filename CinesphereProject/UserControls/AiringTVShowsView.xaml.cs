using CinesphereProject.ObjectClasses;
using Newtonsoft.Json;
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

namespace CinesphereProject.UserControls
{
    /// <summary>
    /// Interaction logic for AiringTVShowsView.xaml
    /// </summary>
    public partial class AiringTVShowsView : UserControl
    {
        //declare the api key as a string
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";

        //movies endpoint
        private const string TVApiUrl = "https://api.themoviedb.org/3/tv/airing_today?api_key=" + ApiKey;


        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();

        public AiringTVShowsView()
        {
            InitializeComponent();
            LoadTVShowData();
        }

        //method to load movies data
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

        //method to open a new view when a tv show is selected
        private void lbxTVShows_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxTVShows.SelectedItem != null)
            {
                TVShow selectedTVShow = (TVShow)lbxTVShows.SelectedItem;

                //navigate to TVShowDetailsView passing the selected show
                TVShowDetailsView tvShowDetailsView = new TVShowDetailsView(selectedTVShow);
                ((MainWindow)Application.Current.MainWindow).AddUserControl(tvShowDetailsView);
            }
        }
    }
}
