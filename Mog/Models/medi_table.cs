using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mog.Models
{
    public class medi_table
    {
        [Required]
        [Display(Description = "Medicine Name")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Medicine Name")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Fill the highlighted Mandatory Fields")]
        [StringLength(50)]
        public string Name { get; set; }



        [Required(ErrorMessage = "Please Fill the highlighted Mandatory Fields")]
        [StringLength(50)]
        public string Category { get; set; }



        [Required]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Medicine Name")]
        [StringLength(250)]
        public string Description { get; set; }


        [Required]
        [StringLength(50)]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]|)[a-zA-Z]+[\w\d.]", ErrorMessage = "Invalid Disease")]
        public string Disease { get; set; }



        [Required]
        [StringLength(50)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string Quantity { get; set; }
    }
}