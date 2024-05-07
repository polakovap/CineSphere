using System;
using System.Collections.Generic;

namespace CinesphereProject.ObjectClasses
{
    //class for all TV Show objects - just basic data
    public class TVShow
    {
        //add all needed attributes for the TV Show object
        public int ID { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
        public string FullPosterPath
        {
            get
            {
                return "https://image.tmdb.org/t/p/w500/" + Poster_Path;
            }
        }
        public DateTime First_Air_Date { get; set; }
        public string formattedFirst_Air_Date => First_Air_Date.ToString("dd.MM.yyyy");
    }
}
