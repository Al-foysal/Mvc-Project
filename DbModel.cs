using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace M7_Project_05.Models
{
	public class Catagory
	{
		public Catagory() { this.ProductTypes = new HashSet<ProductType>(); }
		public int CatagoryId { get; set; }
		[Required, StringLength(40)]
		public string Name { get; set; }
		public virtual ICollection<ProductType>ProductTypes { get; set; }
	}
	public class ProductType
	{
		public ProductType() { this.Products = new HashSet<Product>(); }
		public int ProductTypeId { get; set; }
		[Required, StringLength(40), Display(Name ="Type")]
		public string Name { get; set; }
		[Required, ForeignKey("Catagory")]
		public int CatagoryId { get; set; }
		public virtual Catagory Catagory { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
	public class Product
	{
		public int ProductId { get; set; }
		[Required, StringLength(40)]
		public string ProductName { get; set; }
		[Required, Column(TypeName = "money")]
		public decimal Price { get; set; }
		[Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime PurchaseDate { get; set; }
		public int Stock { get; set; }
		[Required, ForeignKey("ProductType")]
		public int ProductTypeId { get; set; }
		public virtual ProductType ProductType { get; set; }
	}
	public class bpDbContext : DbContext
	{
		public bpDbContext()
		{
			Database.SetInitializer(new DbInitializer());
		}
		public DbSet<Catagory> Catagories { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }
		public DbSet<Product> Products { get; set; }
	}
	public class DbInitializer : DropCreateDatabaseIfModelChanges<bpDbContext>
	{

	}
}