using NLayerApp.BLL.Configuration.MapperConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.App_Start
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(
                cfg => {
                    cfg.AddProfile<WebAutomapperConfig>();
                    cfg.AddProfile<BllToDalMapperConfiguration>();
                });
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
        
    }
}