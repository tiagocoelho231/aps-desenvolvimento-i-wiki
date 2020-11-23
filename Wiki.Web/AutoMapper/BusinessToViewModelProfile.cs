using AutoMapper;
using Wiki.Business;
using Wiki.Web.ViewModels.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiki.Web.ViewModels.CharacterType;

namespace Wiki.Web.AutoMapper
{
    public class BusinessToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Character, CharacterIndexViewModel>();
            Mapper.CreateMap<Character, CharacterViewModel>();
            Mapper.CreateMap<CharacterType, CharacterTypeViewModel>();
            Mapper.CreateMap<CharacterType, CharacterTypeIndexViewModel>();
        }
    }
}