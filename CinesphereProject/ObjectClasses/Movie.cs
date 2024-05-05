using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesphereProject.ObjectClasses
{
    //class for movie objects
    public class Movie
    {
        //add all needed attributes for the movie object 
        public int ID { get; set; }
        public string OriginalTitle { get; set; }
        public string Title { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
        public string FullPosterPath
        {
            get 
            { 
                return "https://image.tmdb.org/t/p/w500/" + Poster_Path;
            }
        }
        public string MediaType { get; set; }
        public bool Adult { get; set; }
        public string OriginalLanguage { get; set; }
        public List<int> GenreIDs { get; set; }
        public float Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }

    }
}
