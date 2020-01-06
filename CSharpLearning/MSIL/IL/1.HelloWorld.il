.assembly extern mscorlib{}

.assembly HelloWorld
{
	.ver 1:0:0:0
}

.module HelloWorld.exe

.method static void W3u() cil managed
{
	.entrypoint
	.maxstack 1

	ldstr "Hello, World! --- via MSIL"
	call void [mscorlib]System.Console::WriteLine(string)

	ret
}