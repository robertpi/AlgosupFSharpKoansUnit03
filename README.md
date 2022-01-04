# Functional Koans - F# - Algosup F# Unit 3

Inspired by EdgeCase's fantastic [Ruby koans](http://github.com/edgecase/ruby_koans),
the goal of the F# koans is to teach you F# through testing.

When you first run the koans, you'll be presented with a runtime error and a
stack trace indicating where the error occurred. Your goal is to make the
error go away. As you fix each error, you should learn something about
the F# language and functional programming in general.

Your journey towards F# enlightenment starts in the AboutAsserts.fs file. These
koans will be very simple, so don't overthink them! As you progress through
more koans, more and more F# syntax will be introduced which will allow
you to solve more complicated problems and use more advanced techniques.

### Prerequisites

The F# Koans needs [.Net 6.0](https://www.microsoft.com/net/download/core) to be built and run. Make sure that you have installed it before building the project. This is the current release of .NET Core that many modern F# and .NET applications use.

Additionally, the project provides [Visual Studio Code](https://code.visualstudio.com/) configuration for running.
To be able to run F# projects in Visual Studio Code, the
[Ionide plugin](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp) should be also installed.

### Using dotnet-watch

You can also use [dotnet-watch](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/tutorials/dotnet-watch.md) to have your changes reloaded automatically.
To do so, navigate into `FSharpKoans` directory and run `dotnet watch run`. Now, after you change the project code, it will be automatically reloaded and tests rerun.

### Running the Koans in Visual Studio Code

Open the project directory in Visual Studio Code with Ionide-fsharp plugin installed
and press F5 to build and launch the Koans (some time is needed to build the project before launch).