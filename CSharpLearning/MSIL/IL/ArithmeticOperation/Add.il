.assembly extern mscorlib {}

.assembly Add
{
    .ver 1:0:0:0
}

.module Add.exe

.method static void Add() cil managed
{
    .entrypoint
    .maxstack 2

    ldstr "The sum of 3 and 25 is "
    call void [mscorlib]System.Console::WriteLine(string)

    ldc.i4 3
    ldc.i4 25
    add
    
    call void [mscorlib]System.Console::WriteLine(int32)
    ret
}