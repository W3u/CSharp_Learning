.assembly extern mscorlib {}

.assembly BrApp
{
    .ver 1:0:0:0
}

.module BrApp.exe

.method static void Main() cil managed
{
    .entrypoint
    .maxstack 1

    ldstr "WILL NOT print number 325"
    call void [mscorlib]System.Console::WriteLine(string)  
    
    br SkipBelow
    // skip below 2 lines
    ldc.i4 325
    call void [mscorlib]System.Console::WriteLine(int32)

    SkipBelow:
    ldstr "Skipped..."
    call void [mscorlib]System.Console::WriteLine(string)

    ret
}