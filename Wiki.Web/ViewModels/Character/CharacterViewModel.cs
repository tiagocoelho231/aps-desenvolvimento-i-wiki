using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wiki.Web.Annotations;

namespace Wiki.Web.ViewModels.Character
{
    public class CharacterViewModel
    {

        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Display(Name = "Character Name")]
        [Required(ErrorMessage = "Name is required.")]
        [Capitalized(ErrorMessage = "Character name should begin with a capital letter.")]
        [MaxLength(100, ErrorMessage = "Character Name must have 100 characters or less.")]
        public string Name { get; set; }

        [Display(Name = "Character Description")]
        [MaxLength(200, ErrorMessage = "Character Description must have 200 characters or less.")]
        public string Description { get; set; }        

        [Display(Name = "Character Type")]
        [Required(ErrorMessage = "Select a type")]
        public int IdType { get; set; }

        [Display(Name = "Character Origin")]
        [MaxLength(50, ErrorMessage = "Character Origin must have 50 characters or less.")]
        public string Origin { get; set; }
    }
}