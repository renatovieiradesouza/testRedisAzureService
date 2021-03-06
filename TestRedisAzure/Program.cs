﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace TestRedisAzure
{
	class Program
	{
		static void Main(string[] args)
		{

			IDatabase database = lazyConnection.Value.GetDatabase();
			
			Console.WriteLine(database.StringGet("Empresa"));
			database.StringSet("Empresa", "Test Redis");
			Console.WriteLine(database.StringGet("Empresa"));

			Console.WriteLine(database.StringGet("Empresa2"));
			database.StringSet("Empresa2", "Test Redis2");
			Console.WriteLine(database.StringGet("Empresa2"));

			Console.ReadKey();

		}


		private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
		{
			//Adicione a string Primary connection string (StackExchange.Redis)
			//Encontra-se na sessão: Access Keys do Azure dentro do serviço Azure Redis Cache
			string connectionString = "";

			return ConnectionMultiplexer.Connect(connectionString);
		});

		public static ConnectionMultiplexer Connectio
		{
			get
			{
				return lazyConnection.Value;
			}
		}

		}
}
