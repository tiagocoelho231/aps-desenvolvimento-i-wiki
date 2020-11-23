using AutoMapper;
using Wiki.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiki.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.AddProfile<ViewModelToBusinessProfile>();
            Mapper.AddProfile<BusinessToViewModelProfile>();
        }
    }
}