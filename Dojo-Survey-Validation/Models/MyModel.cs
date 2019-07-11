using System;
using System.ComponentModel.DataAnnotations;

namespace Dojo_Survey_Validation.Models
{
    public class Form
	{
		[Required]
		[MinLength(2)]
		public string Name {get;set;}

		[Required]
		public string Location {get;set;}

		[Required]
		public string Language {get;set;}

		[MinLength(2)]
		[MaxLength(20)]
		public string Comment {get;set;}
	}
}