.assembly extern mscorlib {}

.assembly AddOvf
{
    .ver 1:0:0:0
}

.module AddOvf.exe

.method static void AddOvf() cil managed
{
    .entrypoint
    .maxstack 2

    ldstr "The sum of 3 and 25 is "
    call void [mscorlib]System.Console::WriteLine(string)

    ldc.i4.s 3
    ldc.i4.s 255
    add.ovf
    
    call void [mscorlib]System.Console::WriteLine(int32)
    ret
}