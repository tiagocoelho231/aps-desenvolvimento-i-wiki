using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wiki.Business;
using Wiki.Web.ViewModels.CharacterType;

namespace Wiki.Web.ViewModels.Character
{
    public class CharacterIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Character Name")]
        public string Name { get; set; }

        [Display(Name = "Character Description")]
        public string Description { get; set; }

        [Display(Name = "Character Type")]
        public virtual CharacterTypeIndexViewModel Type { get; set; }

        [Display(Name = "Character Origin")]
        public string Origin { get; set; }
    }
}