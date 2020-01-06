.assembly extern mscorlib{}

.assembly DeclareVarWithoutName
{
	.ver 1:0:0:0
}

.module DeclareVarWithoutName.exe

.method static void Main() cil managed
{
	.entrypoint
	.maxstack 1

	.locals init (int32, string)

    ldc.i4 325
    stloc.0

    ldstr "Three-Two-Five"
    stloc.1

    ldloc.0
    call void [mscorlib]System.Console::WriteLine(int32)
    
    ldloc.1
    call void [mscorlib]System.Console::WriteLine(string)

	ret
}