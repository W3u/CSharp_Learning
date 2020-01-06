.assembly extern mscorlib {}

.assembly Neg 
{
    .ver 1:0:0:0
}

.module Neg.exe

.method static void Neg() cil managed
{
    .entrypoint
    .maxstack 1

    ldstr "the result of Neg(325) is "
    call void [mscorlib]System.Console::Write(string)

    ldc.i4 325
    neg

    call void [mscorlib]System.Console::WriteLine(int32)
    ret
}