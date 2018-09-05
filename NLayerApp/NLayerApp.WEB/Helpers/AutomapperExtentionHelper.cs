using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Helpers
{
    public static class AutomapperExtentionHelper
    {
        public static TDestination Map<TSource, TDestination>(this TDestination destination, TSource source)
        {
            return AutoMapper.Mapper.Map(source, destination);
        }
    }
}