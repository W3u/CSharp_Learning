.assembly extern mscorlib {}

.assembly DefineCtor
{
    .ver 1:0:0:0
}

.namespace DefineCtor
{
    .class public MathClass extends [mscorlib]System.ValueType
    {
        .field private int32 mValue

        .method public specialname rtspecialname instance void .ctor() cil managed
        {
            ldarg.0
            ldc.i4 325
            stfld int32 DefineCtor.MathClass::mValue
            ret
        }     

        .method public void ShowValue() cil managed
        {
            ldarg.0
            ldfld int32 DefineCtor.MathClass::mValue
            call void [mscorlib]System.Console::WriteLine(int32)
            ret
        }
    }

    .class public ansi auto Program extends [mscorlib]System.Object
    {
        .method static void main() cil managed
        {
            .entrypoint
            .maxstack 3

            .locals init (valuetype DefineCtor.MathClass mclass)

            ldloca mclass
            call instance void DefineCtor.MathClass::.ctor()

            ldloca mclass
            call instance void DefineCtor.MathClass::ShowValue()

            ret
        }
    }
}