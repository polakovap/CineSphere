using System;
using System.Collections.Generic;

namespace CinesphereProject.ObjectClasses
{
    //class for person objects - basic data + known for movies/series
    public class Person
    {
        public int Id { get; set; }
        public string Known_For_Department { get; set; }
        public string Name { get; set; }
        public string Profile_Path { get; set; }
        public string FullPosterPath
        {
            get
            {
                return "https://image.tmdb.org/t/p/w500/" + Profile_Path;
            }
        }
        public List<KnownFor> Known_For { get; set; }
    }

    public class KnownFor
    {
        public int Id { get; set; }
        public string Overview { get; set; }
        public string Poster_Path { get; set; }
        public string FullPosterPath
        {
            get
            {
                return "https://image.tmdb.org/t/p/w500/" + Poster_Path;
            }
        }
        public string Title { get; set; }
        public string Name { get; set; }

        public string TitleForAll
        {
            get
            {
                string title = "";
                if (Title != null)
                {
                    title = Title;
                }
                else if (Name != null)
                {
                    title = Name;
                }
                else
                {
                    title = "-";
                }

                return title;
            }
        }
    }
}
