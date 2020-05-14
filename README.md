#CommonNET

##Description
Common utilities and features for any .NET application. This library acts like a complement of the SDK, giving more functionalities without having external dependencies.
The tool is divided in three different NuGet Packages:

- *CommonNET Base library:* Base library, without dependencies, useful for any kind of .NET Project
  - [![Build Status](https://dev.azure.com/chustasoft/BaseProfiler/_apis/build/status/Release/RELEASE%20-%20NuGet%20-%20ChustaSoft%20Common?branchName=master)](https://dev.azure.com/chustasoft/BaseProfiler/_build/latest?definitionId=5&branchName=master)
  - [![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/ChustaSoft.Common)

- *CommonNET AspNet library:* Library with Base and utilities for an AspNetCore project
[![Build Status](https://dev.azure.com/chustasoft/BaseProfiler/_apis/build/status/Release/RELEASE%20-%20NuGet%20-%20ChustaSoft%20Common%20AspNet?branchName=master)](https://dev.azure.com/chustasoft/BaseProfiler/_build/latest?definitionId=13&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/ChustaSoft.Common.AspNet)

- *CommonNET WPF library:* Controls, Models and Utitilities for a WPF .NET Core project. It has additionally the functionalities from CommonNET base library
[![Build Status](https://dev.azure.com/chustasoft/BaseProfiler/_apis/build/status/Release/RELEASE%20-%20NuGet%20-%20ChustaSoft%20Common%20WPF?branchName=master)](https://dev.azure.com/chustasoft/BaseProfiler/_build/latest?definitionId=20&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/nlog.svg)](https://www.nuget.org/packages/ChustaSoft.Common.Wpf)


##Getting started

There are no requirements, library has not any dependencies in order to make architectural implementation as decoupled as possible. Just install in the project to use and it will be ready, depending on your project type


Target frameworks are

- *CommonNET* 
- .Net Core: 2.1, 2.2, 3.0, 3.1
- .NET Framework 4.7, 4.7.1, 4.7.2

###Installation
Install-Package ChustaSoft.Common -Version

###Use

Tool is mainly divided in:
- Builders: Builders for different complex object creation such as ActionResponse or SelectableProperties
- Contracts: Generic contracts definition such as IBuilder or IMapper
- Enums: Needed types for the assembly and for its use
- Models: Common POCO models
- Exceptions: Extended Exceptions for general purpose
- Helpers: Helper classes, Static and Extension methods to ease common technical requirements
- Utilities: Objects to simplify certain operations.


- *CommonNET.AspNet* 
- .Net Core: 2.1, 2.2, 3.0, 3.1

###Installation
Install-Package ChustaSoft.Common.AspNet

###Use

Tool is mainly divided in:
- Base: ApiControllerBase is a rich controller with the main functionalities, and forces the inherited Controllers to inject an ILogger defined in the client project


- *CommonNET.Wpf* 
- .Net Core: 3.1

###Installation
Install-Package ChustaSoft.Common.Wpf

###Use

Tool is mainly divided in:
- Base: ViewModelBase and TraceableModelBase to inherit from them
- Controls: Generic WPF UserControls are placed here
- Helpers: Converters, Commands and Extension methods are there
- Models: Models required for the library or potentially reusable are there


Specific documentation of any class and general methods could be found inside classes and exposed methods


Thanks for using and contributing
[![Twitter Follow](https://img.shields.io/twitter/follow/ChustaSoft?label=Follow%20us&style=social)](https://twitter.com/ChustaSoft)