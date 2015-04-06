    
//    let add x y = 
//        x + y


















let add x = 
    let addInner y = 
        x + y

    addInner














let add2 x = 
    let addInner y =         
        let innerFn = (+) x
        innerFn y
    addInner


//(add2 1)(1)










printfn "%d" ((add 1)(1))













printfn "%d" ((add 1)(1))























// how do we handle n-parameter functions?
let complex (a:int) (b:bool) (c:float) (d:double) =
    ()


















// int -> (bool -> float -> double -> unit)
// bool -> (float -> double -> unit)
// float -> (double -> unit)
// double -> unit
























// reading error messages 
// expression has wrong return type, why?
    (printfn "test") 123








    (printfn "test %i %i") 123




// how might you implement printfn







// partially apply a function specialize a function
let add12 = add 12




printfn "%d" (add12 1)




// [take a look at the decompiled code for add for perspective on partial application]






// value is not a function and cannot be applied
//let add12result = add12 1 2









// use case
let numbers = [0 .. 10]




let resultOne = List.map (fun x -> x + 2) numbers






let resultTwo = List.map (add 2) numbers













