using System;
using System.Collections.Generic;
using System.Linq;

namespace CinesphereProject.ObjectClasses
{
    //class for all TV Show details objects - more detailed than tvshow.cs
    public class TVShowDetails
    {
        public DateTime First_Air_Date { get; set; }
        public List<Genre> Genres { get; set; }
        //method for formatted genres
        public string getGenres
        {
            get
            {
                // Check if genres exist
                if (Genres != null && Genres.Any())
                {
                    return string.Join(", ", Genres.Select(g => g.Name));
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        //method for formatted title - title (year)
        public string FormattedName
        {
            get
            {
                return $"{Name} ({First_Air_Date.Year})";
            }
        }
        public List<Network> Networks { get; set; }
        public int Number_Of_Episodes { get; set; }
        public string formattedEpisodes
        {
            get
            {
                return $"{Number_Of_Episodes} episodes";
            }
        }
        public int Number_Of_Seasons { get; set; }
        public string formattedSeasons
        {
            get
            {
                return $"{Number_Of_Seasons} season(s)";
            }
        }
        public List<string> Origin_Country { get; set; }
        public string formattedOriginCountry
        {
            get
            {
                // Check if country exist
                if (Origin_Country != null && Origin_Country.Any())
                {
                    return string.Join(", ", Origin_Country);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string Original_Language { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
        public string FullPosterPath
        {
            get
            {
                return "https://image.tmdb.org/t/p/w500/" + Poster_Path;
            }
        }
        public List<ProductionCompany> Production_Companies { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Type { get; set; }
        public double Vote_Average { get; set; }
        //method for vote avg in %
        public string formattedVoteAvg
        {
            get
            {
                double votesPerc = Vote_Average * 10;
                int roundedVotesPerc = (int)Math.Round(votesPerc);
                return $"{roundedVotesPerc} %";
            }
        }
    }

    public class Network
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo_Path { get; set; }
        public string FullLogoPath
        {
            get
            {
                return "https://image.tmdb.org/t/p/w500/" + Logo_Path;
            }
        }
    }

}
