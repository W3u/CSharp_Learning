# Nullable Value Types

### 1. 为什么C#要支持Nullable Value Types？

Case.1 如DB中的某表的某一列设置为int类型且同时可空。则C#无法将Null转为Int32类型。\
Case.2
兼容与其他编程语言之间的差异。如Java中的Date类型是可空的，如果Java发送了Null值给C# application，则C#是无发将Null转为Datetime类型的。\
**为了处理上述情况，所以C#引入了Nullable Value Types。**

### 2. 如何实现Nullable Value Types？

具体实现参见Nullable.cs\
简而言之，CLR定义了一个名为Nullable的泛型结构体，它拥有两个字段(分别为hasValue和value)。因为Nullbale<T>也是struct类型，所以它并不能为Null(并不是真正的支持Null值)。**它只是通过hasValue字段来“模拟”值为Null的情况，来达到逻辑意义上支持Null这一目的。**

```
// 当用null初始化Nullable<T>类型时，CLR实际上调用了struct无参默认构造函数来执行实例化过程。
int? i = null;	// 此时，hasValue=false; value=default(T);
// 等价于：
Nullable<Int32> i = new Nullable<Int32>();
// 上述语句对应的MSIL语句为：
initobj valuetype [mscorlib]System.Nullable`1<int32>
```

### 3. CLR对Nullable Value Types的特殊支持
CLR为了使Nullable Value Types表现的与其他primitive type一样，做了很多特殊的处理。让我们考虑以下场景：

##### 3.1 可空值类型的运算符
```
// Case 1:
int? i = 3;
i++;	// 一元运算符
bool b = i > 3;	// 关系运算符

// Case 2:
i = null;
i++;
b = i > 3;
```
1. 当i不为Null时，执行++与>后的结果是显然的 - 从Nullable<T>中获得value字段，并在该字段上执行/++与>运算符。
2. 但当i为Null时，CLR该如何处理呢？如果依旧从从Nullable<T>中获得value字段（此时value=0,hasValue=false），并在该字段上执行++与>运算符，这显然是不合理的。所以CLR会首先判断hasValue字段的值，如果hasValue为true，则正常处理；如果hasValue为false，则根据实际情况返回Null或抛出异常。

##### 3.2 可空值类型的装箱与拆箱：
```
void Main()
{
	// Case 1:
	int? i = 325;
	DisplayValue(i);
	
	// Case 2:
	int? j = null;
	DisplayValue(j);
}

void DisplayValue(object obj)
{
	int? i = (int32?)obj;
	Console.WriteLine(i);
}
```
1. 将i=325传入DisplayValue()方法时，因为该方法期望object类型的参数，因此i会被装箱(毫无疑问，CLR将读取value字段的值，并装箱)。
2. 将j作为参数传入DisplayValue()方法时，因为j只是逻辑意义上的null（此时value=0,hasValue=false），如果继续装箱value=0字段的值，显然不符合语义（拆箱后得到数值0）。所以CLR会首先判断hasValue字段的值，如果hasValue为true，则正常处理；如果hasValue为false，则传入Null值(此时不需要任何装箱操作)。

##### 3.3 通过可空值类型的接口调用方法
```
int? n = 5;
int result = ((IComparable) n).CompareTo(5);	// 简洁


int result = ((IComparable) (int) n).CompareTo(5);	// 繁琐
```
以上代码将Nullable<Int32>类型的变量n转型为接口类型IComparable<Int32>。Nullable<T>不像Int32类型那样实现了IComparable接口，但C# Compiler允许这样的代码通过编译，而且CLR的校验器也认为这样的代码可验证，从而使得语法更为简洁。

如果CLR不提供这一特殊支持，要在可空值类型上调用接口方法，则必须写更为繁琐的代码。首先要转型为Non-Nullable值类型，然后装箱，再通过接口调用接口方法。


**综上，CLR对Nullable Value Types的特殊支持，使其无缝的集成到CLR中，使得它具有更自然的行为，并表现得为“一等公民”一样。**




**References:**
<<CLR via C#>> Chapter 19
