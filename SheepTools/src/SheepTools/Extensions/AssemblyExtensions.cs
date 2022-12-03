using System.Reflection;

namespace SheepTools.Extensions;

public static class AssemblyExtensions
{
    /// <summary>
    /// Returns types marked with TAttribute within its assembly
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    public static IEnumerable<Type> GetTypes<TAttribute>()
        where TAttribute : Attribute
    {
        return GetTypes<TAttribute>(Assembly.GetAssembly(typeof(TAttribute)));
    }

    /// <summary>
    /// Returns types marked with TAttribute within a given assembly
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<Type> GetTypes<TAttribute>(this Assembly? assembly)
    {
        return (assembly?.GetTypes() ?? Array.Empty<Type>())
            .Where(type => type.IsDefined(typeof(TAttribute), true));
    }

    /// <summary>
    /// Returns types marked with TAttribute and TAttribute value within its assembly
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    public static IEnumerable<Tuple<Type, TAttribute>> GetTypesAndAttributes<TAttribute>()
        where TAttribute : Attribute
    {
        return GetTypesAndAttributes<TAttribute>(Assembly.GetAssembly(typeof(TAttribute)));
    }

    /// <summary>
    /// Returns types marked with TAttribute and TAttribute value within a given assembly
    /// </summary>
    /// <typeparam name="TAttribute"></typeparam>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<Tuple<Type, TAttribute>> GetTypesAndAttributes<TAttribute>(this Assembly? assembly)
        where TAttribute : Attribute
    {
        return (assembly?.GetTypes() ?? Array.Empty<Type>())
            .Where(type => type.IsDefined(typeof(TAttribute), true))
            .SelectMany(type => type.GetCustomAttributes<TAttribute>()
            .Select(attribute => Tuple.Create(type, attribute)));
    }

    /// <summary>
    /// Returns list of assembly names containing type/types implementing TInterface
    /// Method searches in Entry assembly and all its referenced ones
    /// </summary>
    /// <typeparam name="TInterface"></typeparam>
    /// <returns>string Collection</returns>
    public static IEnumerable<string> GetAssemblies<TInterface>()
    {
        IList<string> validAssemblies = new List<string>();
        IList<AssemblyName> assemblies = new List<AssemblyName>();
        assemblies.AddRange(Assembly.GetCallingAssembly().GetReferencedAssemblies());
        assemblies.Add(Assembly.GetCallingAssembly().GetName());
        foreach (var candidate in from assemblyName in assemblies
                                  let candidate = Assembly.Load(assemblyName)
                                  where candidate is not null
                                  from ti in candidate.DefinedTypes
                                  where ti.ImplementedInterfaces.Contains(typeof(TInterface))
                                  select candidate)
        {
            validAssemblies.Add(candidate.GetName().Name ?? candidate.GetName().FullName);
        }

        return validAssemblies;
    }
}
