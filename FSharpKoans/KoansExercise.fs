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


    type BinaryTree<'a> =
    | Node of BinaryTree<'a> * BinaryTree<'a>
    | Leaf of 'a

    [<Koan>]
    let CountTheNodesOnABinaryTree() =
        let rec countNodes t =
            match t with
            | Node(left, right) -> countNodes(left) + countNodes(right) + 1
            | _ -> 1

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
            | Node(left, right) -> sumNodes(left) + sumNodes(right)
            | Leaf value -> value

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
            | OperationNode(x, Addition, y) -> eval x + eval y
            | OperationNode(x, Subtraction, y) -> eval x - eval y
            | OperationNode(x, Multiplication, y) -> eval x * eval y
            | OperationNode(x, Division, y) -> eval x / eval y
            | Value(v) -> v


        let op1 = !! 4. <+> !! 6.
        let op2 = !! 11. <-> !! 4.
        let op3 = !! 16. </> !! 4.
        let op4 = !! 4. <*> !! 5.
        let op5 = (!! 4. <*> !! 5.) </> !! 2.
        let op6 = !! 4. <*> (!! 5. </> !! 2.)
        let op7 = !! 8. </> (!! 4. </> !! 2.)
        let op8 = (!! 8. </> !! 4.) </> !! 2.

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
        let top = [" _ ";"   ";" _ ";" _ ";"   ";" _ ";" _ ";" _ ";" _ ";" _ "]
        let mid = ["| |";"  |";" _|";" _|";"|_|";"|_ ";"|_ ";"  |";"|_|";"|_|"]
        let bot = ["|_|";"  |";"|_ ";" _|";"  |";" _|";"|_|";"  |";"|_|";"  |"]

        let convert n =
            let rec digittostring d (l:list<string>) =
                match d%10 with
                | x when d < 10 -> l.[x]
                | x -> (digittostring (d / 10) l) + " " + l.[x]
            digittostring n top + nl + digittostring n mid + nl + digittostring n bot + nl 

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

        //printf "%s" (convert 910)

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
