# bam.base.services

Base attributes and test types for the BAM service proxy framework.

## Overview

`bam.base.services` provides foundational attributes and data types used to define and configure service proxy classes in the BAM framework. These attributes control how services are registered, how they handle encryption and HMAC authentication, and how they resolve to subdomains.

The library also includes the `Echo` class and its variants, which serve as canonical test services for validating service proxy invocation, encryption, and HMAC key requirements. These test services demonstrate how to use the framework's attributes in practice.

This is a low-level library with minimal dependencies (only `bam.base` and `bam.encryption`), making it suitable for inclusion in both client and server projects that need to reference service proxy metadata without pulling in heavier dependencies.

## Key Classes

| Class | Description |
|---|---|
| `AppServiceAttribute` | Marks a class as an application service, optionally associating it with an application name. |
| `SingletonAttribute` | Extends `AppServiceAttribute` to indicate a class should be registered as a singleton in a .NET service collection. |
| `ApiHmacKeyRequiredAttribute` | Marks a class or method as requiring HMAC signature validation on invocation; implicitly requires application-level encryption. |
| `ServiceSubdomainAttribute` | Specifies the subdomain a service class should be served from when resolving hostnames. |
| `Echo` | Test service that echoes back parameters; used for validating service proxy calls. |
| `EncryptedEcho` | Variant of `Echo` that requires encryption when used as a service. |
| `ApiKeyRequiredEcho` | Variant of `Echo` that requires an API HMAC key for invocation. |
| `ServiceSubdomainEcho` | Variant of `Echo` served from the "echo" subdomain. |
| `EchoData` | Simple DTO with string, bool, and int properties used for testing complex parameter passing. |
| `TestObject` / `SubObject` | Compound test objects for verifying nested parameter serialization. |

## Dependencies

### Project References
- `bam.base` -- core framework types, extension methods, and reflection utilities
- `bam.encryption` -- encryption attributes (`EncryptAttribute`, `ProxyAttribute`) and `HashAlgorithms`

### Package References
- None

## Target Framework
- `net10.0`

## Usage Examples

### Marking a class as an application service singleton
```csharp
[Singleton]
public class MyService
{
    public string DoWork(string input) => $"Processed: {input}";
}
```

### Requiring HMAC authentication on a service
```csharp
[ApiHmacKeyRequired]
public class SecureService
{
    public string GetSecret() => "sensitive-data";
}
```

### Specifying a service subdomain
```csharp
[ServiceSubdomain("api")]
public class ApiService
{
    public string Ping() => "pong";
}
```

### Using the Echo service for testing
```csharp
Echo echo = new Echo();
string result = echo.Send("hello");
// result == "hello"

EchoData data = echo.TestObjectOut("test", true, 42);
// data.StringProperty == "test", data.BoolProperty == true, data.IntProperty == 42
```

## Known Gaps / Not Yet Implemented

- No known gaps. This library is intentionally minimal, consisting only of attributes and test types.
