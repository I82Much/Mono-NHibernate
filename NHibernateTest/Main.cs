using System;
using System.Collections.Generic;
using NHibernate;
using NHibernateTest.Domain;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IList<Product> products; 
			
			// Don't need to use schema export because of the hbm2dll property.
			var cfg = new NHibernate.Cfg.Configuration();
		    cfg.Configure();
			// ensure that mapping hbm.xml file is loaded
			cfg.AddAssembly(typeof(MainClass).Assembly);
			
			Product p = new Product() {Name="Captains of Crush Gripper #1", Category="fitness" };
			
			ISessionFactory factory = 
				cfg.BuildSessionFactory();
			
			using (ISession session = factory.OpenSession()) 
			{ 
				session.Save(p);
				session.Flush();
				
			  	ICriteria sc = session.CreateCriteria<Product>(); 
			  	products = sc.List<Product>();
				Console.WriteLine(products[0].Name);
			  	session.Close(); 
			} 
			factory.Close(); 
			
			Console.WriteLine( products.Count );
			
			Console.WriteLine ("Hello World!");
		}
	}
}

