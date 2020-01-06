# MSIL

**This project covers:**


**References:**
1. [Introduction-to-IL-Assembly-Language](https://www.codeproject.com/Articles/3778/Introduction-to-IL-Assembly-Language)
2. [IL Instructions](https://en.wikipedia.org/wiki/List_of_CIL_instructions)


**Data types for IL**\
IL Name	.NET Base Type	Meaning	CLS Compliant\
Void	 	no data, only used as return type	No\
Bool	System.Boolean	Boolean Value	No\
Char	System.Char	Character Value (16 bit unicode)	No\
int8	System.SByte	Single Byte Integer (signed)	No\
int16	System.Int16	Two Byte Integer(signed)	No\
int32	System.Int32	Four Byte Integer(signed)	Yes\
int64	System.64	8 Byte Integer(signed)	Yes\
native int	System.IntPtr	Signed Integer	Yes\
unsigned int8	System.Byte	One byte integer (unsigned)	No\
unsigned int16	System.UInt16	Two byte integer (unsigned)	No\
unsigned int32	System.UInt32	Four byte integer (unsigned)	No\
unsigned int64	System.UInt64	Eight byte integer (unsigned)	Yes\
native unsigned int	System.UIntPtr	Unsigned Integer	Yes\
Float32	System.Single	Four byte Floating Point	No\
Float64	System.Double	Eight byte Floating Point	No\
object	System.Object	Object type value	Yes\
\&	 	Managed Pointer	Yes\
\*	System.IntPtr	Unmanaged Pointer	Yes\
typedef	System.Typed Reference	Special type that holds data and explicitly indicates the type of data.	Yes\
Array	System.Array	Array	Yes\
string	System.String	String type	Yes


