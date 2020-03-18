--1. compile the C# code
--csc /target:library helloworld.cs



--2. enable CLR 
EXEC sp_configure 'clr enabled', 1;  
RECONFIGURE;  
GO  
--disable CLR integration by setting the clr enabled option to 0



--3. create assembly
CREATE ASSEMBLY mathlib from 'D:\00.Projects\mathlib.dll' WITH PERMISSION_SET = SAFE
go



--4. create sp
CREATE PROCEDURE MyCalc_Add  
@a int, @b int,@result nvarchar(50) OUTPUT  
AS  
EXTERNAL NAME mathlib.[MathLib.Calculator].[Add]

CREATE PROCEDURE MyCalc_Mul  
@a int, @b int,@result nvarchar(50) OUTPUT  
AS  
EXTERNAL NAME mathlib.[MathLib.Calculator].Mul
-- if the HelloWorldProc class is inside a namespace (called MyNS),  
-- the last line in the create procedure statement would be  
-- EXTERNAL NAME helloworld.[MyNS.HelloWorldProc].HelloWorld  



--5. involve the sp
declare @a int, @b int ,@result nvarchar(25)
set @a = 3
set @b = 25
EXEC MyCalc_Add @a, @b, @result out  
PRINT @result
EXEC MyCalc_Mul @a, @b, @result out  
PRINT @result



--6. remove the sp
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'MyCalc_Add')  
   drop procedure MyCalc_Add  
go

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'MyCalc_Mul')  
   drop procedure MyCalc_Mul  
go



--7. remove assembly
IF EXISTS (SELECT name FROM sys.assemblies WHERE name = 'mathlib')  
   drop assembly mathlib  