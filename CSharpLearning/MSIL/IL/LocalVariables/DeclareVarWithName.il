.assembly extern mscorlib{}

.assembly DeclareVarWithName
{
	.ver 1:0:0:0
}

.module DeclareVarWithName.exe

.method static void Main() cil managed
{
	.entrypoint
	.maxstack 1

	.locals init (int32 i, string str)

    ldc.i4 325
    stloc i

    ldstr "Three-Two-Five"
    stloc str

    ldloc i
    call void [mscorlib]System.Console::WriteLine(int32)
    
    ldloc str
    call void [mscorlib]System.Console::WriteLine(string)

	ret
}