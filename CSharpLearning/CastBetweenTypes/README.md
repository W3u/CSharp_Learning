# CastingBetweenType.md
# Casting Between Type

> **CLR只允许将对象转为其自身类型或者其基类型**(这里只关注对象Actual Type, 而非Declaring Type)

### 转换步骤
1. 获取对象的Actual Type(调用GetType()方法)
2. 遍历继承链(对象的Actual Type -> 对象的Base Type -> ... -> Object)
3. 遍历过程中,将继承链中每个类型与目标类型比较

### 转换规则
1. Cast an object to any of its base types, that is (Actual Type >= Target Type)
    1. 如Declaring Type < Target Type, 则必修指定显示转换; 否则引发Compile-time Error
    2. 如Declaring Type >= Target Type, 则无须显示转换
2. Case an object to any of its derived types, that is (Actual Type < Target Type)
    1. 如指定了显示转换, 则引发Run-time Error
    2. 如未指定显示转换, 则引发Compile-time Error

### Example
```
class Employee {}
class Manager : Employee {}

// Case 1:
Object obj = new Object();
{
  Object oo = obj;  // No Error
  Object oo2 = (Object)obj;  // No Error

  Employee ee = obj;  // Compile-time Error
  Employee ee2 = (Employee)obj;  // Run-time Error
  
  Manager mng = obj;  // Compile-time Error
  Manager mng2 = (Manager)obj;  // Run-time Error
}

// Case 2:
Employee employee = new Employee();
{
  Object oo = employee; // No Error
  Object oo2 = (Object)employee;  // No Error
  
  Employee ee = employee;  // No Error
  Employee ee2 = (Employee)employee;  // No Error
  
  Manager mng = employee;  // Compile-time Error
  Manager mng2 = (Manager)employee;  // Run-time Error
}

// Case 3:
Manager manager = new Manager();
{
  Object oo = manager;  // No Error
  Object oo2 = (Object)manager; // No Error
  
  Employee ee = manager;  // No Error
  Employee ee2 = (Manager)manager;  // No Error
  
  Manager mng = manager;  // No Error
  Manager mng2 = (Manager)manager;  // No Error
}
```
Action|Declaring Type= Object; Actual Type= Object;|Declaring Type= Object; Actual Type= Object;|Declaring Type= Object; Actual Type= Object;
-|-|-|-
Target Type= Object; Implicit|||
Target Type= Object; Explicit|||
Target Type= Employee; Implicit|||
Target Type= Employee; Explicit|||
Target Type= Manager; Implicit|||
Target Type= Manager; Explicit|||


