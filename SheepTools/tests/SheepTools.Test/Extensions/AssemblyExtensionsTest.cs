using Microsoft.Extensions.DependencyInjection;
using SheepTools.Extensions;
using System.Reflection;
using Xunit;

using AssemblyExtensions = SheepTools.Extensions.AssemblyExtensions;

namespace SheepTools.Test.Extensions;

public class AssemblyExtensionsTest
{
    [Fact]
    public void GetTypesFromDefaultAssembly()
    {
        var currentTypes = AssemblyExtensions.GetTypes<FooAttribute>();
        ValidateTypes(currentTypes);
    }

    [Fact]
    public void GetTypesFromSpecificAssembly()
    {
        var currentTypes = Assembly.GetAssembly(typeof(IScopedBar)).GetTypes<FooAttribute>();
        ValidateTypes(currentTypes);
    }

    [Fact]
    public void GetTypesAndAttributesFromDefaultAssembly()
    {
        var typesAndAttributes = AssemblyExtensions.GetTypesAndAttributes<FooAttribute>();
        ValidateTypesAndAttributes(typesAndAttributes);
    }

    [Fact]
    public void GetTypesAndAttributesFromSpecificAssembly()
    {
        var typesAndAttributes = Assembly.GetAssembly(typeof(ITransientBar)).GetTypesAndAttributes<FooAttribute>();
        ValidateTypesAndAttributes(typesAndAttributes);
    }

    [Fact]
    public void GetTypesAndAttributesWhenATypeHasMultipleInstancesOfTheSameAttribute()
    {
        var typesAndAttributes = Assembly.GetAssembly(typeof(ISingletonBar)).GetTypesAndAttributes<FooAttribute>();

        var singletonTuples = typesAndAttributes.Where(tuple => tuple.Item1 == typeof(SingletonBar));
        Assert.Equal(2, singletonTuples.Count());

        var singletonBarTuple = singletonTuples.Single(tuple => tuple.Item2.Interface == typeof(ISingletonBar));
        Assert.Equal(ServiceLifetime.Singleton, singletonBarTuple.Item2.ServiceLifetime);

        var yetAnotherInterfaceTuple = singletonTuples.Single(tuple => tuple.Item2.Interface == typeof(IYetAnotherInterface));
        Assert.Equal(ServiceLifetime.Scoped, yetAnotherInterfaceTuple.Item2.ServiceLifetime);
    }

    [Fact]
    public void GetAssembliesImplementingInterface()
    {
        var assemblies = AssemblyExtensions.GetAssemblies<IAssemblyExtensionTestInterface>();
        Assert.Equal(Assembly.GetAssembly(typeof(AssemblyExtensionTest))?.GetName().Name, assemblies.Single());

        assemblies = AssemblyExtensions.GetAssemblies<IAssemblyExtensionTestInterfaceNotImplemented>();
        Assert.Empty(assemblies);
    }

    private static void ValidateTypes(IEnumerable<Type>? currentTypes)
    {
        var expectedTypes = new List<Type>()
            {
               typeof(ScopedBar),
               typeof(TransientBar),
               typeof(SingletonBar)
            };

        Assert.NotNull(currentTypes);
        Assert.Subset(currentTypes!.ToHashSet(), expectedTypes.ToHashSet());
    }

    private static void ValidateTypesAndAttributes(IEnumerable<Tuple<Type, FooAttribute>>? tuples)
    {
        Assert.NotNull(tuples);
        var scopedTuples = tuples!.Where(tuple => tuple.Item1 == typeof(ScopedBar));
        Assert.NotEmpty(scopedTuples);
        foreach (var tuple in scopedTuples)
        {
            Assert.Equal(ServiceLifetime.Scoped, tuple.Item2.ServiceLifetime);
        }

        var singletonTuples = tuples!.Where(tuple => tuple.Item1 == typeof(ScopedBar));
        Assert.NotEmpty(singletonTuples);
        foreach (var tuple in singletonTuples)
        {
            Assert.Equal(
                tuple.Item2.Interface == typeof(ISingletonBar)
                    ? ServiceLifetime.Singleton
                    : ServiceLifetime.Scoped,
                tuple.Item2.ServiceLifetime);
        }

        var transientTuples = tuples!.Where(tuple => tuple.Item1 == typeof(TransientBar));
        Assert.NotEmpty(transientTuples);
        foreach (var tuple in transientTuples)
        {
            Assert.Equal(ServiceLifetime.Transient, tuple.Item2.ServiceLifetime);
        }
    }
}
