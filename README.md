# Stock value

> A minimal, non-synthetic, clean architecture, modern C# 10.0 syntax, feature rich demo application for checking stock prices.

## Features

* Clean architecture
* Clean code (WIP)
* **Records**
* C# 10.0 syntax
* Factory design pattern without violation of the Inversion of Control principle
* Dependency injection
* Proper use of nested classes
* Nullable annotation for custom functions

## FAQ

### Why there is the cross concern section in the architecture?

To solve circular dependency problem. The infrastructure logic could be either in the application layer or in the separate layer with abstractions from the application layer.

The first solution violates the Separation of Concerns principle (application is directly depended on the infrastructure). The latter produce the circular dependency problem.

To overcome this problem, the cross concerns layer is introduced. The presentation layer has to link two layers: the application & the cross concerns layer.

### Why there are nested classed in service objects?

These classes represents API-provider contract. This is an implementation detail of API providers. The services provides their own DTOs. Hence, they are not used anywhere else outside the scope of service methods. The only reason why they are not private is to facilitate null flow and API consistency checks. The generic contract check methods are introduced. They have to have an access to these nested classes. The contract check methods provides a systematic approach to 3rd party contract control.

### Why the factory method use string rather then enum?

The use of enum is a violation of Inversion of Control principle. You can't deploy the presentation layer without redeploying the application layer. To fulfil this principle, one must pass an abstract object (e.g. `string`). Yes, this is a violation of type safety but this trade off could be compensate by unit testing.

## Planned features

* Proper secret management
* Persistent layer implementation
* Unit tests
