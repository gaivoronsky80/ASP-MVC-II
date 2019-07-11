using System;

namespace ViewModel_Fun.Models
{
    public class User
    {
       public string fname {get; set;}
       public string lname {get; set;}
       public User(string fName, string lName)
       {
           fname = fName;
           lname = lName;
       }
    }
}