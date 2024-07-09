using System.Reflection;
using FastExpressionCompiler;
using Mapster;

namespace HolidayApi.DependencyInjection.Mapster
{
    public class MapsterConfiguration : IMapsterConfiguration
    {
        public MapsterConfiguration()
        {
            TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
            TypeAdapterConfig.GlobalSettings.AllowImplicitDestinationInheritance = true;

        }

        public MapsterConfiguration Scan()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            if (assemblies != null && assemblies.Length > 0)
            {
                Type baseType = typeof(IRegister);
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly.ManifestModule.Name.Contains("HolidayApi"))
                    {
                        List<Type> registers = assembly.GetTypes()
                            .Where(x => x != null && !x.IsAbstract && !x.IsInterface && baseType.IsAssignableFrom(x))
                            .ToList();
                        foreach (Type mpType in registers)
                        {
                            (Activator.CreateInstance(mpType) as IRegister)!.Register(TypeAdapterConfig.GlobalSettings);
                        }
                    }
                }
            }
            return this;
        }

        public MapsterConfiguration Compile()
        {
            TypeAdapterConfig.GlobalSettings.Compile();
            return this;
        }
    }
}