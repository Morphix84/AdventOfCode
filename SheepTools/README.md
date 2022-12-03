# SheepTools

[![GitHub Actions][githubactionslogo]][githubactionslink]
[![Azure DevOps][azuredevopslogo]][azuredevopslink]

[![Code coverage][coveragelogo]][coveragelink]
[![Sonar Quality][sonarqualitylogo]][sonarqubelink]
[![Sonar vulnerabilities][sonarvulnerabilitieslogo]][sonarqubelink]
[![Sonar bugs][sonarbugslogo]][sonarqubelink]
[![Sonar code smells][sonarcodesmellslogo]][sonarqubelink]

| SheepTools |[![Nuget][nugetlogo]][nugetlink] | [![API][apimundologo]][apimundolink]
|:---|:---|:---|
|**SheepTools.Moq**|[![Nuget][nugetlogo-moq]][nugetlink-moq]|[![API][apimundologo-moq]][apimundolink-moq]
|**SheepTools.XUnit**|[![Nuget][nugetlogo-xunit]][nugetlink-xunit]|[![API][apimundologo-xunit]][apimundolink-xunit]

SheepTools is a .NET toolbox library (yet another!) which contains handy classes, extension methods, etc.

It's divided in different libraries so that using the general purpose, main one doesn't imply adding any transitive dependencies to your project.

I'm more than happy to accept suggestions, comments, or addition proposals.

#### Relevant info

- .NET Standard 2.0 and 2.1 were supported until v0.2.x.
- `Nullable` is enabled from v0.2.x.

## Content

- [SheepTools](#sheeptools)

  - [Point](#point)
  - [IntPoint](#intpoint)
  - [Point3D](#point3d)
  - [Line](#line)
  - [BitMatrix](#bitmatrix)
  - [BitArrayComparer](#bitarray-comparer)
  - [TreeNode](#tree-node)
  - [Node](#node)
  - [Ensure](#ensure)
  - [RangeHelpers](#rangehelpers)
  - [LinearInterpolation](#lerp)
  - [AssemblyExtensions](#collection-extensions)
  - [BitArrayExtensions](#bitarray-extensions)
  - [CharExtensions](#char-extensions)
  - [CollectionExtensions](#datetime-extensions)
  - [DateTimeExtensions](#assembly-extensions)
  - [DictionaryExtensions](#dictionary-extensions)
  - [DirectionExtensions](#direction-extensions)
  - [DoubleExtensions](#double-extensions)
  - [EnumerableExtensions](#enumerable-extensions)
  - [IntExtensions](#int-extensions)
  - [NumericExtensions](#numeric-extensions)
  - [StringExtensions](#string-extensions)

- [SheepTools.Moq](#sheeptools-moq)

  - [MoqLoggerExtensions](#moq-logger-extensions)
  - [MoqGenericLoggerExtensions](#moq-genericlogger-extensions)

- [SheepTools.XUnit](#paragraph2)

  - [Asssert](#asssert)

---

<a name="sheeptools"></a>

## SheepTools

[![Nuget][nugetlogo]][nugetlink]

[nugetlogo]: https://img.shields.io/nuget/v/SheepTools.svg?style=flat-square&label=nuget
[nugetlink]: https://www.nuget.org/packages/SheepTools

<a name="point"></a>

### Point

2D Point class with an optional `string` Id.

<a name="intpoint"></a>

### IntPoint

Slim 2D Point class, using ints and without and optional `string` Id

<a name="point3d"></a>

### Point3D

3D point class with an optional `string` Id.

<a name="line"></a>

### Line

2D (straight) line class.

<a name="bitmatrix"></a>

### BitMatrix

Class to work with bidimensional matrixes of bits.

<a name="bitarray-comparer"></a>

### BitArrayComparer

`IEqualityComparer<BitArray>` implementation

<a name="tree-node"></a>

### TreeNode

[Tree](<https://en.wikipedia.org/wiki/Tree_(data_structure)>) node class with a generic key.

<a name="node"></a>

### Node

[Tree](<https://en.wikipedia.org/wiki/Tree_(data_structure)>) node class with a `string` key.

Essentially, `TreeNode<string>`.

<a name="maths"></a>

### Maths

General math algorithms

- `LeastCommonMultiple(this IEnumerable<ulong>)`
- `LeastCommonMultiple(ulong, ulong)`
- `GreatestCommonDivisor(this IEnumerable<ulong>)`
- `GreatestCommonDivisor(ulong, ulong)`

<a name="ensure"></a>

### Ensure

Assert-style class that throws exceptions when things don't go as expected.

- `Equal()` / `NotEqual()`
- `Equals()` / `NotEquals()`
- `True()` / `False()`
- `Null()` / `NotNull()`
- `Empty()` / `NotEmpty()`
- `NullOrEmpty()` / `NotNullOrEmpty()`
- `NullOrWhiteSpace()` / `NotNullOrWhiteSpace()`
- `Count<T>(int, IEnumerable<T>, Func<T, bool>)`

<a name="rangehelpers"></a>

### RangeHelpers

Helper class to generate ranges of numbers before having to check if it was (a, b), [a, b] or (a, b] in Microsoft documentation every time I use `Enumberable.Range`.

- `GenerateRange(int, int)` -> [a, b]

<a name="lerp"></a>

### LinearInterpolation

Helper methods to interpolate 2D points

- `InterpolateLinearly(double, double, double, double, double)`
- `InterpolateYLinearly(double, Point, point)`
- `InterpolateXLinearly(double, Point, point)`

<a name="assembly-extensions"></a>

### AssemblyExtensions

- `GetTypes<TAttribute>()`
- `GetTypesAndAttributes<TAttribute>()`
- `GetAssemblies<TInterface>()`

<a name="bitarray-extensions"></a>

### BitArrayExtensions

- `Reverse()`
- `ToBitString()`

<a name="char-extensions"></a>

### CharExtensions

- `GetDirection()`

<a name="string-extensions"></a>

<a name="collection-extensions"></a>

### CollectionExtensions

- `AddRange()`
- `RemoveAll()`

<a name="datetime-extensions"></a>

### DateTimeExtensions

- `IsAfterNow()`
- `IsAfter(DateTime)`
- `MillisecondsFromEpoch()`
- `StringId()`

<a name="dictionary-extensions"></a>

### DictionaryExtensions

- `AddOrUpdate(TKey, TValue, Func<TKey, TValue, TValue>)`
- `AddOrUpdate(TKey, Func<TKey, TValue>, Func<TKey, TValue, TValue>)`
- `AddOrUpdate(TKey, Func<TKey, TArg, TValue>, Func<TKey, TValue, TArg, TValue>, TArg)`

<a name="direction-extensions"></a>

### DirectionExtensions

- `TurnLeft()`
- `TurnRight()`
- `Turn180()`
- `Opposite()`

<a name="double-extensions"></a>

### DoubleExtensions

- `DoubleEquals(double, precision)`

<a name="enumerable-extensions"></a>

### EnumerableExtensions

- `ForEach()`
- `IsNullOrEmpty()`
- `IntersectAll()`

<a name="int-extensions"></a>

### IntExtensions

- `Factorial()`
- `Clamp(int, int)`

<a name="numeric-extensions"></a>

### NumericExtensions

- `Clamp<T>(T, T)`

### StringExtensions

- `IsEmpty()`
- `IsWhiteSpace()`
- `HasWhiteSpaces()`
- `Truncate(int)`
- `ReverseString()`
- `ToBitArray(char = '1')`
- `ToBoolEnumerable(char = '1')`
- `RemoveBlanksAndMakeInvariant()`
- `IsPalindrome()`

<a name="sheeptools-moq"></a>

## SheepTools.Moq

[![Nuget][nugetlogo-moq]][nugetlink-moq]

Depends on [Moq](https://github.com/moq/moq4) and [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/).

<a name="moq-logger-extensions"></a>

### MoqLoggerExtensions

Helps verifying `ILogger` invocations.

- `VerifyLog(LogLevel, Message, Times)`

- `VerifyLog<TException>(LogLevel, Exception, Message, Times)`

<a name="moq-genericlogger-extensions"></a>

### MoqGenericLoggerExtensions

Helps verifying `ILogger<T>` invocations.

- `VerifyLog<T>(LogLevel, Message, Times)`

- `VerifyLog<T, TException>(LogLevel, Exception, Message, Times)`

<a name="sheeptools-xunit"></a>

## SheepTools.XUnit

[![Nuget][nugetlogo-xunit]][nugetlink-xunit]

<a name="asssert"></a>

Depends on [XUnit](https://xunit.net/).

### Asssert

- `DoesNotThrow(Action)`
- `DoesNotThrow(Func<object)`
- `DoesNotThrowAsync(Func<Task>)`

[azuredevopslogo]: https://dev.azure.com/eduherminio/SheepTools/_apis/build/status/eduherminio.SheepTools?branchName=main
[azuredevopslink]: https://dev.azure.com/eduherminio/SheepTools/_build/latest?definitionId=1&branchName=main
[githubactionslogo]: https://github.com/eduherminio/SheepTools/workflows/CI/badge.svg
[githubactionslink]: https://github.com/eduherminio/SheepTools/actions?query=workflow%3ACI
[nugetlogo]: https://img.shields.io/nuget/v/SheepTools.svg?style=flat-square&label=nuget
[nugetlink]: https://www.nuget.org/packages/SheepTools
[nugetlogo-moq]: https://img.shields.io/nuget/v/SheepTools.Moq.svg?style=flat-square&label=nuget
[nugetlink-moq]: https://www.nuget.org/packages/SheepTools.Moq
[nugetlogo-xunit]: https://img.shields.io/nuget/v/SheepTools.XUnit.svg?style=flat-square&label=nuget
[nugetlink-xunit]: https://www.nuget.org/packages/SheepTools.XUnit
[apimundologo]: https://img.shields.io/badge/SheepTools%20API-Apimundo-728199.svg
[apimundolink]: https://apimundo.com/organizations/nuget-org/nuget-feeds/public/packages/SheepTools/versions/latest?tab=types
[apimundologo-moq]: https://img.shields.io/badge/SheepTools.Moq%20API-Apimundo-728199.svg
[apimundolink-moq]: https://apimundo.com/organizations/nuget-org/nuget-feeds/public/packages/SheepTools.Moq/versions/latest?tab=types
[apimundologo-xunit]: https://img.shields.io/badge/SheepTools.XUnit%20API-Apimundo-728199.svg
[apimundolink-xunit]: https://apimundo.com/organizations/nuget-org/nuget-feeds/public/packages/SheepTools.XUnit/versions/latest?tab=types
[coveragelogo]: https://img.shields.io/azure-devops/coverage/eduherminio/Sheeptools/8/main
[coveragelink]: https://dev.azure.com/eduherminio/SheepTools/_build/latest?definitionId=8&branchName=main
[sonarqubelink]: https://sonarcloud.io/dashboard?id=eduherminio_SheepTools
[sonarqualitylogo]: https://sonarcloud.io/api/project_badges/measure?project=eduherminio_SheepTools&metric=alert_status
[sonarvulnerabilitieslogo]: https://sonarcloud.io/api/project_badges/measure?project=eduherminio_SheepTools&metric=vulnerabilities
[sonarbugslogo]: https://sonarcloud.io/api/project_badges/measure?project=eduherminio_SheepTools&metric=bugs
[sonarcodesmellslogo]: https://sonarcloud.io/api/project_badges/measure?project=eduherminio_SheepTools&metric=code_smells
