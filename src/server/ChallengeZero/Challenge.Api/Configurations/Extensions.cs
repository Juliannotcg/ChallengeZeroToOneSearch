using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Challenge.Api.Configurations
{
    public static class Extensions
    {
        public static void AddAutoMapper(this ContainerBuilder builder, Type objectType)
        {
            builder.RegisterAssemblyTypes(objectType.Assembly).As<Profile>();
            builder.RegisterAssemblyTypes(objectType.Assembly).As(typeof(IValueResolver<,,>));

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}