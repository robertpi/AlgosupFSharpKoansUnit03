namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// Getting Started
//
// The F# Koans are a set of exercises designed to get you familiar
// with F#. By the time you're done, you'll have a basic
// understanding of the syntax of F# and learn a little more
// about functional programming in general.
//
// Answering Problems
//
// This is where the fun begins! Each Koan method contains
// an example designed to teach you a lesson about the F# language.
// If you execute the program defined in this project, you will get
// a message that the AssertEquality koan below has failed. Your
// job is to fill in the blank (the __ symbol) to make it pass. Once
// you make the change, re-run the program to make sure the koan
// passes, and continue on to the next failing koan.  With each
// passing koan, you'll learn more about F#, and add another
// weapon to your F# programming arsenal.
//---------------------------------------------------------------
[<Koan(Sort = 1)>]
module KoansExercise =

    [<Koan>]
    let LetInfersTheTypesOfValuesWherePossible() =
        let x = 50
        let typeOfX = x.GetType()

        let y = "a string"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<FILL_ME_IN>
        AssertEquality typeOfY typeof<FILL_ME_IN>

    [<Koan>]
    let YouCanMakeTypesExplicit() =
        // the only difference from the previous test is the type annotations
        // which can sometimes be useful
        let (x:int) = 42
        let typeOfX = x.GetType()

        let y:string = "forty two"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<FILL_ME_IN>
        AssertEquality typeOfY typeof<FILL_ME_IN>

    [<Koan>]
    let FloatsAndInts() =
        let x = 20
        let typeOfX = x.GetType()

        let y = 20.0
        let typeOfY = y.GetType()

        //you don't need to modify these
        AssertEquality typeOfX typeof<FILL_ME_IN>
        AssertEquality typeOfY typeof<FILL_ME_IN>

    type MyTypeAlias = FILL_ME_IN

    [<Koan>]
    let TypeAliasInAction() =
        let t = typeof<MyTypeAlias>

        //you don't need to modify these
        AssertEquality t typeof<obj>

    [<Koan>]
    let CreatingTuples() =
        let actualValue = (__, 2)

        AssertEquality ("one", 2) actualValue

    [<Koan>]
    let CreatingTuplesMoreTuples() =
        let actualValue = (__, 2, __, __)

        AssertEquality ("one", 2, 3., 4) actualValue

    [<Koan>]
    let AccessingTupleElements() =
        let items = ("apple", "dog")

        // fst and snd are definited in the F# standard library, can you guess what they mean?

        let fruit = fst items
        let animal = snd items

        AssertEquality fruit __
        AssertEquality animal __

    [<Koan>]
    let AccessingTupleElementsWithPatternMatching() =

        let items = ("apple", "dog", "Mustang")

        let fruit, animal, car = items

        AssertEquality fruit __
        AssertEquality animal __
        AssertEquality car __


    [<Koan>]
    let ReturningMultipleValuesFromAFunction() =
        let squareAndCube x =
            (x ** 2.0, x ** 3.0)

        let squared, cubed = squareAndCube 3.0


        AssertEquality squared __
        AssertEquality cubed __

    [<Koan>]
    let SwappingTuples() =
        let swap tuple = __

        AssertEquality ('b', 'a') (swap ('a', 'b'))
        AssertEquality (2, 1) (swap (1, 2))
        AssertEquality (2., 1.) (swap (1., 2.))
        AssertEquality ("two", "one") (swap ("one", "two"))

    [<Koan>]
    let PrettyPrintingTuples() =
        let input = (__, __, __)

        let actualValue = __

        AssertEquality "(6, seven, 8)" actualValue

    type Person =
        { FirstName: string;
          LastName: string; }

    [<Koan>]
    let AccessingMembers() =
        let input =
            { FirstName = "Robert";
              LastName = "Pickering" }

        let actualValue1 = __
        let actualValue2 = __

        AssertEquality "Pickering" actualValue1
        AssertEquality "Robert" actualValue2

    [<Koan>]
    let UpdatingRecords() =
        let input =
            { FirstName = "Robert";
              LastName = "Pickering" }

        let actualValue1 = __
        let actualValue2 = __
        let actualValue3 = __

        AssertEquality { FirstName = "Fred"; LastName = "Pickering" } actualValue1
        AssertEquality { FirstName = "Fran"; LastName = "Pickering" } actualValue2
        AssertEquality { FirstName = "Robert"; LastName = "Zimmerman" } actualValue3

    [<Koan>]
    let SomeSimplePatternMatching() =

        let numberConverter x =
            match x with
            // add other cases here!
            | _ -> "unintresting"

        AssertEquality "the first number" (numberConverter 1)
        AssertEquality "lucky" (numberConverter 7)
        AssertEquality "baker's dozen" (numberConverter 13)

    type Condiment =
        | Mustard
        | Ketchup
        | Relish
        | Vinegar

    [<Koan>]
    let DiscriminatedUnionsCaptureASetOfOptions() =

        let toColor condiment =
            match condiment with
            | Mustard -> "yellow"
            | Ketchup -> "red"
            | Relish -> "green"
            | Vinegar -> "brownish?"

        let choice = Mustard

        AssertEquality (toColor choice) __

    [<Koan>]
    let OptionTypesMightContainAValue() =
        let someValue = Some 10

        AssertEquality someValue.IsSome __
        AssertEquality someValue.IsNone __
        AssertEquality someValue.Value __

    [<Koan>]
    let OrTheyMightNot() =
        let noValue = None

        AssertEquality noValue.IsSome __
        AssertEquality noValue.IsNone __
        AssertThrows<FILL_IN_THE_EXCEPTION> (fun () -> noValue.Value)

    type Game =
        { Name: string
          Platform: string
          Score: int option }

    [<Koan>]
    let UsingOptionTypesWithPatternMatching() =
        let chronoTrigger = { Name = "Chrono Trigger"; Platform = "SNES"; Score = Some 5 }
        let halo = { Name = "Halo"; Platform = "Xbox"; Score = None }

        let translate score =
            match score with
            | 5 -> "Great"
            | 4 -> "Good"
            | 3 -> "Decent"
            | 2 -> "Bad"
            | 1 -> "Awful"
            | _ -> "Unknown"

        let getScore game =
            match game.Score with
            | Some score -> translate score
            | None -> "Unknown"

        AssertEquality (getScore chronoTrigger) __
        AssertEquality (getScore halo) __

    [<Koan>]
    let FindingJustOneOrZeroItem() =
        let names = [ "Alice"; "Bob"; "Eve"; ]

        // tryFind returns an option so you can handle 0 rows returned
        let eve =
            names
            |> List.tryFind (fun name -> name = "Eve" )
        let zelda =
            names
            |> List.tryFind (fun name -> name = "Zelda" )

        AssertEquality eve __
        AssertEquality zelda __

    [<Koan>]
    let ComputingFactorial() =
        // for an explaination of factorial see https://en.wikipedia.org/wiki/Factorial
        let rec fac n = __

        AssertEquality 6 (fac 3)
        AssertEquality 120 (fac 5)
        AssertEquality 362880 (fac 9)

    type BinaryTree<'a> =
    | Node of BinaryTree<'a> * BinaryTree<'a>
    | Leaf of 'a

    [<Koan>]
    let CountTheNodesOnABinaryTree() =
        let rec countNodes t =
            match t with
            | _ -> __

        let tree1 =
            Node(
                Node(Leaf 'a', Leaf 'b'),
                Node(Leaf 'd', Leaf 'c'))

        let tree2 =
            Node(
                Node(Leaf true, Node(Node(Leaf true, Leaf false), Leaf true)),
                Node(Leaf true, Leaf false))

        let tree3 =
            Node(
                Node(Leaf "this", Node(Node(Leaf "is", Leaf "a"), Leaf "message")),
                Node(Node(Leaf "in", Node(Leaf "a", Leaf "bottle")), Leaf "!"))

        AssertEquality 7 (countNodes tree1)
        AssertEquality 11 (countNodes tree2)
        AssertEquality 15 (countNodes tree3)

    [<Koan>]
    let SumTheLeavesOnABinaryTree() =
        let rec sumNodes t =
            match t with
            | _ -> __

        let tree1 =
            Node(
                Node(Leaf 1, Leaf 2),
                Node(Leaf 3, Leaf 4))

        let tree2 =
            Node(
                Node(Leaf 1, Node(Node(Leaf 1, Leaf 2), Leaf 2)),
                Node(Leaf 3, Leaf 4))

        let tree3 =
            Node(
                Node(Leaf 1, Node(Node(Leaf 1, Leaf 2), Leaf 2)),
                Node(Node(Leaf 3, Node(Leaf 3, Leaf 4)), Leaf 4))

        AssertEquality 10 (sumNodes tree1)
        AssertEquality 13 (sumNodes tree2)
        AssertEquality 20 (sumNodes tree3)

    type Operation =
    | Addition
    | Subtraction
    | Multiplication
    | Division

    type ArithmeticTree =
    | OperationNode of ArithmeticTree * Operation * ArithmeticTree
    | Value of float

    let (!!) x = Value x
    let (<+>) x y = OperationNode (x, Addition, y)
    let (<->) x y = OperationNode (x, Subtraction, y)
    let (<*>) x y = OperationNode (x, Multiplication, y)
    let (</>) x y = OperationNode (x, Division, y)



    [<Koan>]
    let EvaluateTreeOperations() =
        let rec eval aTree =
            match aTree with
            | _ -> __

        let op1 = !! 4. <+> !! 6.
        let op2 = !! 11. <-> !! 4.
        let op3 = !! 16 </> !! 4.
        let op4 = !! 4. <*> !! 5.
        let op5 = (!! 4. <*> !! 5.) </> !! 2
        let op6 = !! 4. <*> (!! 5. </> !! 2)
        let op7 = !! 8. </> (!! 4. </> !! 2)
        let op8 = (!! 8. </> !! 4.) </> !! 2

        AssertEquality 10. (eval op1)
        AssertEquality 7. (eval op2)
        AssertEquality 4. (eval op3)
        AssertEquality 20. (eval op4)
        AssertEquality 10. (eval op5)
        AssertEquality 10. (eval op6)
        AssertEquality 4. (eval op7)
        AssertEquality 1. (eval op8)

    let nl = System.Environment.NewLine

    [<Koan>]
    let LcdDigits() =
        // Your task is to create an LCD string representation of an
        // integer value using a 3x3 grid of space, underscore, and
        // pipe characters for each digit. Each digit is shown below
        //  _           _     _           _     _     _     _     _
        // | |     |    _|    _|   |_|   |_    |_      |   |_|   |_|
        // |_|     |   |_     _|     |    _|   |_|     |   |_|     |
        // Example: 910
        //  _       _
        // |_|   | | |
        //   |   | |_|

        let convert n = __

        let example2 =
            " _ " + nl +
            " _|" + nl +
            "|_ " + nl

        let example910 =
            " _       _ " + nl +
            "|_|   | | |" + nl +
            "  |   | |_|" + nl

        let example45 =
            "     _ " + nl +
            "|_| |_ " + nl +
            "  |  _|" + nl

        let example7836 =
            " _   _   _   _ " + nl +
            "  | |_|  _| |_ " + nl +
            "  | |_|  _| |_|" + nl


        AssertEquality example2 (convert 2)
        AssertEquality example910 (convert 910)
        AssertEquality example45 (convert 45)
        AssertEquality example7836 (convert 7836)

    open System.IO

    [<Koan>]
    let FindAnagrams() =
        // From the word file find:
        // - the number groups of anagrams
        // - the largest group of anagrams
        let words = File.ReadAllLines(Path.Combine(__SOURCE_DIRECTORY__, "wordlist.txt")) |> List.ofArray

        let caseSenativeAnagramsCount = __
        let caseSenativeLargestGroup = __
        let caseInsenativeAnagramsCount = __
        let caseInsenativeLargestGroup = __

        AssertEquality 20683 caseSenativeAnagramsCount
        AssertEquality
            ["alerts"; "alters"; "artels"; "estral"; "laster"; "rastle"; "ratels"; "salter"; "slater"; "staler"; "stelar"; "talers"; "tarsel"]
            caseSenativeLargestGroup
        AssertEquality 30404 caseInsenativeAnagramsCount
        AssertEquality
            ["alerts"; "alters"; "artels"; "estral"; "laster"; "rastle"; "ratels"; "salter"; "slater"; "staler"; "stelar"; "talers"; "tarsel"]
            caseInsenativeLargestGroup
