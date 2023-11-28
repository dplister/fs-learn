+ 2
System.DateTime.Now

let version = 6
$"F# {version} is cool!"

let greetPerson name age =
    $"Hello, {name}. You are {age} years old"
greetPerson "test" 1

let getCurrentTime () = System.DateTime.Now
let x = getCurrentTime ()
let y = getCurrentTime ()

let drive gas distance =
    if distance = "far" then gas / 2.0
    elif distance = "medium" then gas - 10.0
    else gas - 1.0

let gas = 100.0
let firstState = drive gas "far"
let secondState = drive firstState "medium"
let finalState = drive secondState "short"

// exercise 4.3
let drive2 gas distance =
    if distance > 50 then gas / 2.0
    elif distance > 25 then gas - 10.0
    elif distance > 0 then gas - 1.0
    else gas

// exercise 5.1
let buildPerson (forename : string) (surname: string) (age: int) =
    (forename, surname), age

let name, age = buildPerson "a" "b" 10
let (fname, lname), ag = buildPerson "a" "b" 10