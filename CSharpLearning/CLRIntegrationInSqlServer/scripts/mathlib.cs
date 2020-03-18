using System;  
using System.Data;  
using Microsoft.SqlServer.Server;  
using System.Data.SqlTypes;  
 
namespace MathLib
{
	public class Calculator  
	{  
		[Microsoft.SqlServer.Server.SqlProcedure]  
		public static void Add(int a, int b, out string text)  
		{
			int result = a + b;
			SqlContext.Pipe.Send(String.Format("{0} + {1} = {2}",
												a, 
												b, 
												Environment.NewLine));  
			text = result.ToString();  
		}


		[Microsoft.SqlServer.Server.SqlProcedure]  
		public static void Mul(int a, int b, out string text)  
		{
			int result = a * b;
			SqlContext.Pipe.Send(String.Format("{0} * {1} = {2}",
												a, 
												b, 
												Environment.NewLine));  
			text = result.ToString();   
		}		
	}	
}
