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
    public class ViewModelToBusinessProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CharacterIndexViewModel, Character>();
            Mapper.CreateMap<CharacterViewModel, Character>();
            Mapper.CreateMap<CharacterTypeIndexViewModel, CharacterType>();
            Mapper.CreateMap<CharacterTypeViewModel, CharacterType>();
        }
    }
}