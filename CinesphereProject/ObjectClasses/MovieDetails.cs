using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CinesphereProject.ObjectClasses
{
    //class for movieDetails objects - more data about a movie than in movie.cs
    public class MovieDetails
    {
        public List<Genre> Genres { get; set; }
        public int Id { get; set; }
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
        public DateTime Release_Date { get; set; }
        public string FormattedReleaseDate => Release_Date.ToString("dd.MM.yyyy");
        public long Revenue { get; set; }
        public string FormattedRevenue
        {
            get
            {
                string rev = "";
                if (Revenue == 0)
                {
                    rev = "-";
                }
                else
                    rev = Revenue.ToString("#,0", CultureInfo.InvariantCulture);
                return rev;
            }
        }
        public int Runtime { get; set; }
        public string formattedRuntime
        {
            get
            {
                return $"{Runtime} mins";
            }
        }
        public string Tagline { get; set; }
        public string Title { get; set; }
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

        //method for formatted title - title (year)
        public string FormattedTitle
        {
            get 
            {
                return $"{Title} ({Release_Date.Year})";
            }
        }

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
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductionCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
