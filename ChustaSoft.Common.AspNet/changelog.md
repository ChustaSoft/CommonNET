# CommonNET AspNet Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


## [2.7.0] - 2022-04-27
### Added
- Added more cases for in ControllerBase extension method GetRequestUserEmail
- Allowed to write custom exception handling for ErrorHandling Middleware
- Added bypass methods for GetRequestUserId and GetRequestUserEmail in ApiControllerBase and MvcControllerBase, avoiding usage of 'this'

## [2.6.0] - 2022-04-27
### Changed
- Changed namespace for ControllerBase Extension methods, now custom namespace can be avoided
- Changed release notes reference link to new changelog file

## [2.5.0] - 2022-04-06
### Added
- GetRequestUserId method as Extension Method for ControllerBase
- GetRequestUserEmail method as Extension Method for ControllerBase
- Added ErrorHandlingMiddleware for controlling errors withoug try catch blocks in controller actions, simple scenario
- Extension method for configuring ErrorHandlingMiddleware

## [2.4.0] - 2021-12-25
### Added
- RequiredOneOrAnotherAttribute added for MVC purposes

## [2.3.0] - 2021-11-15
### Changed
- CommonNET core reference updated to latest version

## [2.2.0] - 2021-11-14
### Added
- Added .NET 6.0 support

## [2.1.0] - 2021-10-27
### Changed
- CommonNET core reference updated to latest version

## [2.0.5] - 2021-10-22
### Changed
- CommonNET core reference updated to latest version

## [2.0.4] - 2021-09-30
### Added
- Adding HttpContextLoggingMiddleware for logging incoming request and responses
- Extendion method for configuring HttpContextLoggingMiddleware

## [2.0.3] - 2021-09-19
### Added
- Adding MvcController to AspNet package

## [2.0.2] - 2021-06-01
### Added
- Restored .NET Core 2.1 support

## [2.0.1] - 2021-06-01
### Changed
- CommonNET core reference updated to 2.0.1

## [2.0.0] - 2021-03-31
### Added
- Added compatibility with .NET5
### Changed
- CommonNET core reference updated to 2.0.0
### Removed
- Removed support for .NET Core previous than 3.1

## [1.1.0] - 2020-02-26
### Added
- - .NET Core 3.x suport

## [1.0.1] - 2019-09-21
### Fixed
- Fixed problem in CommonNET ActionResponseBuilder, new reference with the fix updated

## [1.0.0] - 2019-09-21
### Added
- ApiControllerBase added