.assembly extern mscorlib {}

.assembly Rem 
{
    .ver 1:0:0:0
}

.module Rem.exe

.method static void Rem() cil managed
{
    .entrypoint
    .maxstack 2

    ldstr "the result of 25 % 3 is "
    call void [mscorlib]System.Console::Write(string)

    ldc.i4 25
    ldc.i4 3
    rem

    call void [mscorlib]System.Console::WriteLine(int32)
    ret
}