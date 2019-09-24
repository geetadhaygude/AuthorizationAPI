using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthorizationAPI.Models
{
    public class Person
    {
            [Required(ErrorMessage ="name is required"),MaxLength(5,ErrorMessage ="name should be less than 5")]
            public string name { get; set; }
            [MinLength(1,ErrorMessage ="Surname should not be empty")]
            [Required]
            public string surname{ get; set; }
            [Range(1,99,ErrorMessage ="age should be a number")]
            public int age { get; set; }

    }
}