using System;

namespace CinesphereProject.ObjectClasses
{
    //class for movie objects - only basic data
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
        public string FullPosterPath
        {
            get 
            { 
                return "https://image.tmdb.org/t/p/w500/" + Poster_Path;
            }
        }
        public DateTime Release_Date { get; set; }
        public string formattedReleaseDate => Release_Date.ToString("dd.MM.yyyy");
    }
}
