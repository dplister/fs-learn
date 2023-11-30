open System
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

// records

type Person = {
    FirstName : string
    LastName : string
    Age : int
}

let me = { 
    FirstName = "Mr"
    LastName = "Test"
    Age = 42
}
let fullName = $"{me.FirstName} {me.LastName}"

// exercise 5.2
let buildPersonRecord (forename : string) (surname: string) (age: int) =
    { 
        FirstName = forename
        LastName = surname
        Age = age
    }

// copy and update
let newMe = {
    me with
        Age = me.Age + 1
}

// exercise 5.3

type Name = {
    FirstName : string
    LastName : string
}

// shortened for brevity
type Address = {
    Line1 : string
    Line2 : string
}

type Customer = {
    Name : Name
    Address : Address
    CreditRating: int
}

type Supplier = {
    Name : Name
    Address : Address
    OutstandingBalance : decimal
    NextPaymentDue : DateTime
}

// anonymous record example
type SupplierAlt = {
    Name : {| FirstName: string; LastName: string |}
    Address : Address
    OutstandingBalance : decimal
    NextPaymentDue : System.DateTime
}
let supp = { 
    Name = {| FirstName = "A"; LastName = "B" |}
    Address = { Line1 = "1"; Line2 = "2" }
    OutstandingBalance = 0.0m
    NextPaymentDue = System.DateTime.Now
}