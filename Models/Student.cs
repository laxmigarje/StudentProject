using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "id is required")]

        public int id { get; set; }

        [Required(ErrorMessage = "firstname is required")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "lastname is required")]
        public string lastname { get; set; }

       
        [Required(ErrorMessage = "age is required")]
        public int age { get; set; }

        [Required(ErrorMessage = "gender is required")]
        public string gender { get; set; }

        [Required(ErrorMessage = "address is required")]
        public string address { get; set; }


        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }

    }
}

    

