# CommonNET Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.9.0] - 2024-02-21
### Added
- Support for .NET 8.0

## [2.8.0] - 2022-12-20
### Added
- Support for .NET 7.0
### Removed
- Unsupported SDK's (.NET Core 2.1, 3.1 and .NET 5.0)

## [2.7.1] - 2022-04-27
### Changed
- Changed release notes reference link to new changelog file

## [2.7.0] - 2022-03-20
### Added
- Added ModelMappingException

## [2.6.0] - 2022-02-25
### Added
- Stream Helper new methods (GetEmbeddedResource, AsString)

## [2.5.0] - 2022-01-29
### Added
- Stream Helper with the follwing functionalities:  (compression, decompression, comparison)
- String bridge to Stream compression

## [2.4.0] - 2021-12-25
### Added
- Added GetPropertyValue extension method in ReflectionHelper

## [2.2.0] - 2021-10-27
### Added
- Support for .NET 6.0
- Support for .NET Framework 4.8

## [2.1.0] - 2021-10-27
### Added
- New implementation done for Paginate IEnumerables

## [2.0.4] - 2021-10-22
### Added
- DateTimeHelper added with the following features (GetLastWeekDate, GetFirstWeekDate)

## [2.0.3] - 2021-06-01
### Added
- ToEnum method created from string as Extension method

## [2.0.2] - 2021-06-01
### Changed
- Restored support in .NET Core 2.1

## [2.0.1] - 2021-05-25
### Changed
- Restored support in .NET Framework 4.7.1

## [2.0.0] - 2021-03-31
### Added
- Enhaced maintenance being compatible in .NET Standard 2.1
- Enhaced maintenance being compatible in .NET 5.0
### Changed
- ITrackableBuilder added extending / splittig previous IBuilder contract
### Removed
- Removed deprecated implementation of IBuilder
- Removed deprecated IMapper contract
- Removed deprecated whole feature realted to SelectablePropertiesBuilder
- Removed support for other targets

## [1.3.2] - 2020-08-09
### Changed
- - IAuditable LastModificationDate nullable

## [1.3.1] - 2020-07-14
### Fixed
- Added public visibility to IAuditable

## [1.3.0] - 2020-07-14
### Added
- New IKeyable interface added
- New IAuditable interface added

## [1.2.2] - 2020-05-14
### Fixed
- Fixed multi-targed issues

## [1.2.0] - 2020-02-05
### Added
- Documentation added
- .NET Framework support for 4.7, 4.7.1 and 4.7.2

## [1.1.5] - 2020-01-03
### Added
- Implemented multiple key configurations for Encrypt and Decrypt operations

## [1.1.4] - 2019-11-27
### Added
- Added documentation to EncryptionHelper
- Added GetAttirubtes to EnumsHelper

## [1.1.3] - 2019-10-23
### Fixed
- Allowed to clear objects by reflection even if they have Indexer

## [1.1.1] - 2019-09-22
### Added
- Allowed to encrypt and decrypt JSON objects

## [1.1.0] - 2020-08-14
### Changed
- Added Builders namespace
- Added Contracts namespace

## [1.0.22] - 2019-05-14
### Added
- Added encrypt/decrypt methods to EncryptationHelper

## [1.0.21] - 2019-03-07
### Added
- Added IBuilder added

## [1.0.20] - 2019-02-05
### Added
- Added SetStatus by boolean to ActionResponseBuilder

## [1.0.19] - 2019-02-05
### Added
- ObjectHelper new method (GetDescription)

## [1.0.18] - 2019-01-14
### Added
- Added EncryptationHelper for hash creation

## [1.0.16] - 2018-12-09
### Added
- Added IMapper interface
- Added GetSelection method for SelectablePropertiesBuilder
- Added ThenSelectFromProperty method to SelectablePropertiesBuilderHelper

## [1.0.15] - 2018-12-02
### Added
- Added SelectablePropertiesBuilder for nested collections

## [1.0.14] - 2018-11-27
### Added
- Fix concept error for SelectablePropertiesBuilder initialization and use

## [1.0.13] - 2018-11-26
### Added
- New functionalities for SelectableProperties

## [1.0.12] - 2018-11-17
### Added
- Added EnumsHelper new methods (GetByString, GetEnumList, GetEnumDictionary)

## [1.0.11] - 2018-11-17
### Added
- Added StringExtensions new methods (FirstToUpper, FirstToLower, ToUpperCamelCase)

## [1.0.10] - 2018-10-15
### Added
- Added new functionality for allowing add elements in ActionResponseBuilder

## [1.0.9] - 2018-10-13
### Fixed
- Fixed bug with UriBuilder when base path already contains a slash

## [1.0.8] - 2018-10-13
### Fixed
- Fixed bug with UriBuilder AddPathPart

## [1.0.7] - 2018-10-13
### Added
- Added new method for add partial URLs to URI

## [1.0.6] - 2018-10-13
### Added
- BusinessException parameterless constructor

## [1.0.5] - 2018-10-10
### Added
- Added AddData method for ActionResponseBuilder

## [1.0.4] - 2018-10-08
### Added
- ActionResponse and Builder

## [1.0.0] - 2018-08-10
### Added
- Created initial package with main helpers utilities for Enums and Strings