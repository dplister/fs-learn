# F# In Action

## Preamble

F# goals is to be "highly succinct and "highly safe".

_Imperative_: the low level how:
```
    IEnumerable<int> GetEvenNumbers(IEnumerable<int> numbers)
    {
        var output = new List<int>();
        foreach (var number in numbers) {
            if (number % 2 == 0)
                output.Add(number);
        }
        return output;
    }
```

_Declarative_: _what_ you want to achieve (defer low level details to compiler)
```
    let getEvenNumbers =
        Seq.filter (fun number -> number % 2 = 0)
```

Composition rather than inheritance to achieve reuse.\
Functions are the main component of reuse rather than classes.\
Small functions that "plug together" to create powerful abstractions.

```
    let squareNumbers = Seq.map (fun x -> x * x)
    let getEvenNumbersThenSquare = getEvenNumbers >> squareNumbers
```

F# encourages separation of data and behaviour; design code with simple data types with modules of functions that act on those types.

Don't think of scripts as linear, non-interactive programs. Think of them as a living document that you're building up piece by piece in what you can inspect data at any point in time.

## Basic Syntax

`let` binds values to symbols.
- Functions and simple values are both considered values.
- Creates an _immutable reference_ to a value.

Mutation occurs via declaring the variable `mutable`, and using `<-` to assign.
```
    let mutable age = 42
    age <- 43
```
Encapsulation is no longer as important as immutability protects from your data being changed from under you.

### Scopes

Nested scope is 4 spaces by common convention.
- Scoping is important as the larger the scope of something, the more likely it will be involved in a bug.
```
  let greetingText = 
    let fullName =
        let fname = "Mr"
        let sname = "Test"
        $"{fname} {sname}"
    $"Greetings, {fullName}"
```

Separating out nested scopes into expression functions is valuable.

### Unit

All functions return a value; if there is no value to return, Unit is returned (C# functions that return `void` will return unit).\ 
Can use unit as a parameter.

```
let getCurrentTime () = System.DateTime.Now
let x = getCurrentTime ()
let y = getCurrentTime ()
```

## Data Types

### Tuples

`tuples` are useful for grouping data without overhead of defining a class or type for one specific situation.
- F# tuples are passed by reference (stored on heap, garbage collected), C# use ValueTuple, which is pass by value (stored on stack).
- Elements are unnamed.
- Extraction of values is solely by deconstruction; boilerplate to update a single field.
- Type signature complexity for larger tuples.
- Use when few elements (2-3), and short lived (a function or two).

```
let name = "isaac", "abraham"
let firstName, secondName = name
let justFirst, _ = name
```

Type annotation for function: `let makeDoctor (name: string * string) = ...`
Inline deconstruction: `let makeDoctor (_, sname) = ...`

C# out parameters are converted to part of tuple:
```
open System
let parsed, theDate = DateTime.TryParse "03 Dec 2020"
if parsed then printf $"Day of week is {theDate.DayOfWeek}!"
```