using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wiki.Web.Annotations;

namespace Wiki.Web.ViewModels.CharacterType
{
    public class CharacterTypeViewModel
    {

        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Display(Name = "Type Name")]
        [Required(ErrorMessage = "Name is required.")]
        [Capitalized(ErrorMessage = "Type name should begin with a capital letter.")]
        [MaxLength(100, ErrorMessage = "Type Name must have 100 characters or less.")]
        public string Name { get; set; }

        [Display(Name = "Type Description")]
        [MaxLength(200, ErrorMessage = "Type Description must have 200 characters or less.")]
        public string Description { get; set; }
    }
}