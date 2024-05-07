using System.Net.Http;
using System;
using System.Windows.Controls;
using CinesphereProject.ObjectClasses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CinesphereProject.UserControls
{
    /// <summary>
    /// Interaction logic for PersonDetailsView.xaml
    /// </summary>
    public partial class PersonDetailsView : UserControl
    {
        //get api key and api url
        private const string ApiKey = "157aa10c34c2b883c1990f99dc95d834";
        private const string MovieDetailsApiUrl = "https://api.themoviedb.org/3/person/{0}?api_key={1}&language=en-US";

        //create a HttpClient
        private readonly HttpClient _httpClient = new HttpClient();
        
        //object to represent the chosen person
        private readonly Person _selectedPerson;

        //constructor passing the chosen person object plus knownForData from person.cs because here i use personDetails.cs for displaying the data and that does not have the knownFor property from the api
        public PersonDetailsView(Person Person, List<KnownFor> knownForData)
        {
            InitializeComponent();
            _selectedPerson = Person;
            lbxKnownFor.ItemsSource = knownForData;
            LoadPersonDetails();
        }

        //method to load person data
        private async void LoadPersonDetails()
        {
            try
            { 
                // Create the URL for the specific movie
                string url = string.Format(MovieDetailsApiUrl, _selectedPerson.Id, ApiKey);

                // Get the movie details from the API
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();

                //desertialize directly into a personDetails object
                var personDetails = JsonConvert.DeserializeObject<PersonDetails>(json);

                // Set the DataContext of the UserControl to the movie details
                DataContext = personDetails;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine("Error loading movie details: " + ex.Message);
            }
        }

      
    }
}
