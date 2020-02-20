First of all, thank you for contributing to this small project.

The idea of this, is to implement all the different implementations needed at any .NET Core project, that are not in the framework itself.
With this purpose, the main library is fully free of any dependencies, that is one of the most important rules for this library.
In case of need any kind of implementation that will need third party libraries, please contact with the project administration, of course it will have a place inside the project, but outside the main NuGet package

Finally, the technical points to follo are the following:
1. Create a fork for the project

2. Make the implementation in the wright folder:
- Utilities: Main objects
- Helpers: Any extension method or objects with bussiness implementations will be allowed here, logic must be tested, ideally by TDD principes

2. Generate a PullRequest to the master branch
  This will launch a MS Azure DevOps build checking if it compiles, launching tests and collecting Code Coverage
  
  
X. For any doubt or further information, plase do not hesitate to contact with us by the following email:
  chustasoft@gmail.com
