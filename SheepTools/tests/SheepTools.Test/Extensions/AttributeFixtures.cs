using Microsoft.Extensions.DependencyInjection;

namespace SheepTools.Test;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal sealed class FooAttribute : Attribute
{
    public ServiceLifetime ServiceLifetime { get; set; }

    public Type Interface { get; set; }

    public FooAttribute(Type classInterface, ServiceLifetime serviceLifetime)
    {
        Interface = classInterface;
        ServiceLifetime = serviceLifetime;
    }
}

internal interface IScopedBar { }

[Foo(typeof(IScopedBar), ServiceLifetime.Scoped)]
internal class ScopedBar : IScopedBar { }

internal interface ITransientBar { }

[Foo(typeof(ITransientBar), ServiceLifetime.Transient)]
internal class TransientBar : ITransientBar { }

internal interface ISingletonBar { }

internal interface IYetAnotherInterface { }

[Foo(typeof(ISingletonBar), ServiceLifetime.Singleton)]
[Foo(typeof(IYetAnotherInterface), ServiceLifetime.Scoped)]
internal class SingletonBar : ISingletonBar, IYetAnotherInterface { }

internal interface IAssemblyExtensionTestInterface { }
internal interface IAssemblyExtensionTestInterfaceNotImplemented { }
internal class AssemblyExtensionTest : IAssemblyExtensionTestInterface { }
