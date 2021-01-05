using M7_Project_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace M7_Project_05.Repository
{
	interface IProductTypeRepo
	{
		List<Catagory> GetAll();
		List<Product> GetProduct(int id);
		List<Catagory> GetTypesForDropDown();
		void InsertProductTypeWithProduct(ProductType pb);
	}
	public class ProductTypeRepo : IProductTypeRepo
	{
		bpDbContext db = new bpDbContext();
		public List<Catagory> GetAll()
		{
			return db.Catagories
		   .Include(t => t.ProductTypes.Select(eq => eq.Products)).ToList();

		}

		public List<Product> GetProduct(int id)
		{
			return db.Products.Where(x => x.ProductTypeId == id).ToList();
		}

		public List<Catagory> GetTypesForDropDown()
		{
			return db.Catagories.ToList();
		}

		public void InsertProductTypeWithProduct(ProductType pb)
		{
			db.ProductTypes.Add(pb);
			db.SaveChanges();
		}
	}
}
