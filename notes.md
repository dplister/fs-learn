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

## Basic Syntax

`let` binds values to symbols.
- Functions and simple values are both considered values.
- Creates an _immutable reference_ to a value.

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

