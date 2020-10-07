using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wiki.Web.ViewModels.Characters
{
    public class CharactersIndexViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Character Name")]
        public string Name { get; set; }
        [Display(Name = "Character Description")]
        public string Description { get; set; }
        [Display(Name = "Character Type")]
        public string Type { get; set; }
        [Display(Name = "Character Origin")]
        public string Origin { get; set; }
    }
}