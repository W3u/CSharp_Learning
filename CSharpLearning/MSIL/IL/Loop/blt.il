.assembly extern mscorlib {}
.assembly LoopApp
{
    .ver 1:0:0:0
}

.module LoopApp.exe

.method static void Main() cil managed
{
    .entrypoint
    .maxstack 2

    .locals init (int32 i, int32 len)

    // i = 0
    ldc.i4 0
    stloc i
    // len = 5
    ldc.i4 5
    stloc len

Start:
    ldloc i
    ldloc len
    blt LoopBody
    br End

LoopBody:
    ldstr "current item = "
    call void [mscorlib]System.Console::Write(string)
    ldloc i
    call void [mscorlib]System.Console::WriteLine(int32)

    // i++
    ldloc i
    ldc.i4 1
    add
    stloc i
    br Start

End:
    ret
}