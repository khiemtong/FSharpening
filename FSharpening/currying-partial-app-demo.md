* Today I'm going to talk about currying and partial application.
* To do this, I'm going to just walk through a F# script file with examples.
* So let's jump right into it.

* Currying is the transformation of a multi parameter function into a one parameter function that returns a series of function that takes a single parameter

* So for example.

* Let's take a look at this function.
* This is a function called __add__ that takes _2 params x and y__, and returns _____.


* Here I've defined a function called add that takes one parameter x
* And it returns a subfunction called addInner that takes one parameter y
* AddInner takes the parameter y and returns the sum x + y

* So we've applied the curry explicitly here
* A question that might pop up is how about the + operator, is it also curried (this is technically it being partially applied)

* So here I've defined a function add2 that takes one parameter x and returns a subfunction that takes y
* The + operator is also curried
* You can use the + operator in prefix form with (+)
* Which takes one parameter x and returns a subfunction that takes the second
* The compiler will reorder and do this for you

* Here's an incorrect way to call print function, here's how currying helps you understand the error message
* This helps when you're using F# because it gives you a couple of ways to think about how you call a function
* You can call it and think about it as a two parameter function
* Or you can think about it as calling a one parameter function, and then calling the returned function with another parameter

* Let's extend this to more parameters 
* Here's a function called complex, it takes four parameters..
* It can be curried by following the pattern we saw before
* Here's how

* Here's a function complex2, takes takes one parameter...
* Thinking about how the functions are curried might help you with a read F# error messages
* How does printfn work?
* I don't know how it's actually implemented. But you can imagine it...

* Next let's talk about partial application
* Partial application is fixing a number of arguments in a function with multiple arguments and getting back a function with less arguments
* Let's fix the add function
* Here's a different perspective. 
* I have a console app, that I've decompiled.
* Fix the instance with a parameter

* Value is not a function and cannot be applied
* Explain using map, lighter syntax

