using ASPTest.BLL.Util;
using AutoMapper;

namespace ASPTest.WebAPI.App_Start
{
    public class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }
    }
}