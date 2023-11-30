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

### Records

- In language since initial release, defacto way of modelling structured data, compared to C#'s classes.
- Able to specify names for each value, called _fields_.
- Shorthand: `type Address = { Line1 : string; Line2 : string }`.
- Must set all fields on a record when creating them.
- Records are cheap; if you only have some part of the data in a context, create a different type that better fits the use case.
- Type inference works on records, but if two are very similar, compiler will default inference to the _most recently defined_ type.
- In performance critical areas, `mutable` can be declared on a field.
- Records and Tuples support _structural equality_ by default (compare by contents, not reference).
- Records are _reference types_, to pass by value add `[<Struct>]` to top of record definition.

*Copy and Update* is used to update a record:
```
let me = {
    FirstName = "Mr"
    LastName = "Test"
    Age = 42
}
let newMe = {
    me with
        Age = 43
}
```

#### Anonymous Records

- Skips the formal definition.
- Compiler doesn't support type inference when used as inputs to functions.
- No attributes.
- Difficult to pattern match.
- Useful for exploration before formal definition.
- Can inline an anonymous record inside a record definition.
- Great fit for serialization and deserialization (JSON).
  - Instead of decorating your types with custom attributes for your serialization framework, simply map your domain types into a structure that maps 1:1 with the target JSON.

```
let company = {|
    Name = "My Company"
    Country = "Aus"
|}
```

Can update _and_ add new fields to an anonymous record.
```
let companyWithBank = {|
    company with
        AccountNumber = 1
|}
```
