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
    /// Interaction logic for SearchPersonView.xaml
    /// </summary>
    public partial class SearchPersonView : UserControl
    {
        //declare the api key and endpoint
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";
        private const string SearchApiUrl = "https://api.themoviedb.org/3/search/person?api_key={0}&language=en-US&query={1}";

        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();

        //declare a variable to store what was searched 
        private readonly string _query;

        //constructor in which a searchquery is passed to add to the api endpoint
        public SearchPersonView(string searchQuery)
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

                //desertialize directly into a Person object
                var result = JsonConvert.DeserializeObject<TrendingResponse<Person>>(json);
                var searchedPeople = result?.Results;

                //if no results are found, display a message
                if (searchedPeople == null || searchedPeople.Count == 0)
                {
                    searchedPeople = new List<Person>
                    {
                        new Person { Name = "No results found:("}
                    };
                }

                // Set the DataContext of the UserControl to the movie details
                lbxSearchedPeople.ItemsSource = searchedPeople;
                DataContext = result;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error loading movie details: " + ex.Message);
            }
        }

        //method to open up a new view when person is clicked
        private void lbxSearchedPeople_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbxSearchedPeople.SelectedItem != null)
            {
                Person selectedPerson = (Person)lbxSearchedPeople.SelectedItem;
                List<KnownFor> knownFor = selectedPerson.Known_For; // Extract knownFor data from selectedPerson

                //navigate to persondetailsview passing the selected person
                PersonDetailsView personDetailsView = new PersonDetailsView(selectedPerson, knownFor);
                ((MainWindow)Application.Current.MainWindow).AddUserControl(personDetailsView);

            }
        }
    }
}
