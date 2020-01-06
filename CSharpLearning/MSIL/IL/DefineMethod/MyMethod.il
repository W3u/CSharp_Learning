.assembly extern mscorlib {}

.assembly DefineMethod
{
    .ver 1:0:0:0
}

.module DefineMethod.exe

.method static void Main() cil managed
{
    .entrypoint
    .maxstack 2

    .locals init (int32 sum)

    ldstr "3 + 25"
    call void [mscorlib]System.Console::Write(string)

    ldc.i4 3
    ldc.i4 25

    call int32 DoSum(int32, int32)
    stloc sum

    ldloc sum
    call void PrintSum(int32)

    ret
}

.method public static int32 DoSum(int32, int32) cil managed
{
    ldarg.0
    ldarg.1
    add

    ret
}

.method public static void PrintSum(int32) cil managed
{
    ldstr " = "
    call void [mscorlib]System.Console::Write(string)
    
    ldarg.0
    call void [mscorlib]System.Console::WriteLine(int32)

    ret
}