using App.Data;
using App.Repositories;

namespace App
{
  public class Program
  {
    private static void Main(string[] args)
    {
      var repository = new BikeStoreRepository(new AppDbContext());

      // ============================================
      // some test cases of the repository methods ||
      // ============================================

      // Display all categories
      var categories = repository.GetAllCategories().ToList();
      Console.WriteLine("|{0,-25}|{1,-25}|", "Category ID", "Category Name");
      Console.WriteLine("|{0,-25}|{1,-25}|", "-----------------", "-----------------");
      foreach (var category in categories)
      {
        Console.WriteLine("|{0,-25}|{1,-25}|", category.CategoryId, category.CategoryName);
      }

      // Display first product
      Console.WriteLine("\nFirst Product");
      Console.WriteLine("-----------------");
      var firstProduct = repository.GetFirstProduct();
      if (firstProduct != null)
      {
        Console.WriteLine("|{0,-25}|{1,-25}|", "Product ID", "Product Name");
        Console.WriteLine("|{0,-25}|{1,-25}|", "-----------------", "-----------------");
        Console.WriteLine("|{0,-25}|{1,-25}|", firstProduct.ProductId, firstProduct.ProductName);
      }

      // Test GetProductById Method
      Console.WriteLine("\nTesting GetProductById Method");
      Console.WriteLine("-----------------------------------");
      var product = repository.GetProductById(100);
      if (product != null)
      {
        Console.WriteLine("|{0,-25}|{1,-25}|", "Product ID", "Product Name");
        Console.WriteLine("|{0,-25}|{1,-25}|", "-----------------", "-----------------");
        Console.WriteLine("|{0,-25}|{1,-25}|", product.ProductId, product.ProductName);
      }
      else
      {
        Console.WriteLine("Product not found.");
      }

      // Test GetProductsByModelYear Method
      Console.WriteLine("\nTesting GetProductsByModelYear Method");
      Console.WriteLine("-----------------------------------------");
      var modelYearProducts = repository.GetProductsByModelYear(2018).ToList();
      if (modelYearProducts.Count > 0)
      {
        Console.WriteLine("|{0,-25}|{1,-25}|", "Product ID", "Product Name");
        Console.WriteLine("|{0,-25}|{1,-25}|", "-----------------", "-----------------");
        foreach (var pro in modelYearProducts)
        {
          Console.WriteLine("|{0,-25}|{1,-25}|", pro.ProductId, pro.ProductName.Split(' ')[2]);
        }
      }
      else
      {
        Console.WriteLine("No products found with model year 2022.");
      }

      // Test CountProductsInCategory Method
      Console.WriteLine("\nTesting CountProductsInCategory Method");
      Console.WriteLine("-----------------------------------------");
      Console.WriteLine("Number of products in category with ID 3 is: {0}", repository.CountProductsInCategory(3));

      // Test CalculateAverageListPrice Method
      Console.WriteLine("\nTesting CalculateAverageListPrice Method");
      Console.WriteLine("-----------------------------------------");
      Console.WriteLine("Average List Price of all products is: {0}", repository.CalculateAverageListPrice());

      // Test GetCompletedOrders Method
      Console.WriteLine("\nTesting GetCompletedOrders Method");
      Console.WriteLine("-----------------------------------------");
      var completedOrders = repository.GetCompletedOrders().ToList();
      if (completedOrders.Count > 0)
      {
        Console.WriteLine("|{0,-25}|{1,-25}|{2,-25}|", "Order ID", "Customer ID", "Order Date");
        Console.WriteLine("|{0,-25}|{1,-25}|{2,-25}|", "-----------------", "-----------------", "-----------------");
        foreach (var order in completedOrders)
        {
          Console.WriteLine("|{0,-25}|{1,-25}|{2,-25}|", order.OrderId, order.CustomerId, order.OrderDate);
        }
      }
      else
      {
        Console.WriteLine("No completed orders found.");
      }
    }
  }
}
