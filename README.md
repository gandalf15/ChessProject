#Notes

1. I followed the [instructions](INSTRUCTIONS.md) for the project. However, I changed the methods signatures and I had to write new unit tests.
1. For any new project I would always choose the latest long term support, if there is no valid reason/requirement to use older version. Upgraded to .Net 6.0 because it is latest long term support (LTS) release. It support ends on November 08, 2024. For more details see [this link](https://github.com/dotnet/core/blob/main/releases.md) and [release notes](https://devblogs.microsoft.com/dotnet/announcing-net-6/).
1. It is very important to use some code style. I decided to use [Google C# style guide](https://google.github.io/styleguide/csharp-style.html).
1. It was not specified, but I assumed the game should conform to the official chess rules from [FIDE](https://www.fide.com/FIDE/handbook/LawsOfChess.pdf).
1. Based on the FIDE rules a pawn can advance two squares in one move. See the section 3.7b. This can be only from the starting position and both squares need to be empty.
1. UML diagrams were drawn using [Dia](http://dia-installer.de/index.html.en).
1. 