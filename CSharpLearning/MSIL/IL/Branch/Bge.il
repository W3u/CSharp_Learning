.assembly extern mscorlib {}

.assembly BgeApp
{
    .ver 1:0:0:0
}

.module BgeApp.exe

.method static void Main() cil managed
{
    .entrypoint
    .maxstack 2

    .locals init (int32 a, int32 b)

    ldstr "Pls enter 2 numbers, we will return the larger one to you ..."
    call void [mscorlib]System.Console::WriteLine(string)  
    
    // read the 1st number
    ldstr "enter 1st number:"
    call void [mscorlib]System.Console::WriteLine(string)
    call string [mscorlib]System.Console::ReadLine()
    call int32 [mscorlib]System.Int32::Parse(string)
    stloc a
    
    // read the 2nd number
    ldstr "enter 2nd number:"
    call void [mscorlib]System.Console::WriteLine(string)
    call string [mscorlib]System.Console::ReadLine()
    call int32 [mscorlib]System.Int32::Parse(string)
    stloc b

    ldstr "the larger number is "
    call void [mscorlib]System.Console::Write(string)

    // Compare these 2 numbers
    ldloc a
    ldloc b
    bge geBranch
    // Case 1: [a < b], print b
    ldloc b
    call void [mscorlib]System.Console::WriteLine(int32)
    br Exit

    geBranch:
    // Case 2: [a >= b], print a
    ldloc a
    call void [mscorlib]System.Console::WriteLine(int32)
    br Exit

    Exit:
    ret
}