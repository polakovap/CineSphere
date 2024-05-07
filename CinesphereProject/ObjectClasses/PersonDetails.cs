using System;

namespace CinesphereProject.ObjectClasses
{
    //class for person objects - more detailed data about people than in person.cs but misses KnownFor!!
    public class PersonDetails
    {
        public string Biography { get; set; }
        public DateTime Birthday { get; set; }
        public string FormattedBirthday => Birthday.ToString("yyyy-MM-dd");
        public int Gender { get; set; }
        public string FormattedGender 
        {
            get
            {
                string gender = "";
                switch (Gender)
                {
                    case 1:
                        gender = "Female";
                        return gender;
                    case 2:
                        gender = "Male";
                        return gender;
                    case 3:
                        gender = "Non-binary";
                        return gender;
                }
                return gender;
            }
        }
        public int Id { get; set; }
        public string Known_For_Department { get; set; }
        public string Name { get; set; }
        public string Place_Of_Birth { get; set; }
        public string Profile_Path { get; set; }
        public string FullPosterPath
        {
            get
            {
                return "https://image.tmdb.org/t/p/w500/" + Profile_Path;
            }
        }
    }
}
