using AutoMapper;
using Challenge.Api.AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge.Tests.AutoMapper
{
    [TestClass]
    public class AutoMapperTest
    {
      
        [TestMethod]
        public void ValidMappings()
        {
            MapperConfiguration config = AutoMapperConfiguration.RegisterMappings();
            config.AssertConfigurationIsValid();
        }
    }
}