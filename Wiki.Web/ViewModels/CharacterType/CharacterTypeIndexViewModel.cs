using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wiki.Web.ViewModels.CharacterType
{
    public class CharacterTypeIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Type Name")]
        public string Name { get; set; }

        [Display(Name = "Type Description")]
        public string Description { get; set; }
    }
}