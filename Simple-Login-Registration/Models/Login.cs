using System;
using System.ComponentModel.DataAnnotations;

namespace Simple_Login_Registration.Models
{
    public class Login
    {
		[Required]
		[EmailAddress]
		public string LEmail {get;set;}

		[Required]
		[DataType(DataType.Password)]
		public string LPassword {get;set;}
	}
}