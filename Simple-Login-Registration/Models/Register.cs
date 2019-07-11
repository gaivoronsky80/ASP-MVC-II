using System;
using System.ComponentModel.DataAnnotations;

namespace Simple_Login_Registration.Models
{
    public class Register
	{
		[Required]
		[MinLength(2)]
		[Display(Name = "First Name")]
		public string FName {get;set;}

		[Required]
		[MinLength(2)]
		[Display(Name = "Last Name")]
		public string LName {get;set;}

		[Required]
		[EmailAddress]
		public string REmail {get;set;}

		[Required]
		[MinLength(8)]
		[DataType(DataType.Password)]
		public string RPassword {get;set;}

		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]
		[Compare(nameof(RPassword), ErrorMessage = "Password mismatch")]
		public string PasswordConfirm {get;set;}
	}
}