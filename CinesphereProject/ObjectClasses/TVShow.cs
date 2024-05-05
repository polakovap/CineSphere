using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesphereProject.ObjectClasses
{
    //class for all TV Show objects
    public class TVShow
    {
        //add all needed attributes for the TV Show object
        public int ID { get; set; }
        public string OriginalName { get; set; }
        public string Name { get; set; }
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
        public DateTime FirstAirDate { get; set; }
        public float VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public List<string> OriginCountry { get; set; }
    }
}
