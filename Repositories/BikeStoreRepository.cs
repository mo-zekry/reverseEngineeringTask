using App.Data;
using App.Models;

namespace App.Repositories;

public class BikeStoreRepository(AppDbContext dbContext)
{
  private readonly AppDbContext _dbContext = dbContext;

    #region Products

    // Retrieves all categories from the database.
    public IQueryable<Category> GetAllCategories()
  {
    return _dbContext.Categories;
  }

  // Retrieves the first product from the database.
  public Product? GetFirstProduct()
  {
    var firstProduct = _dbContext.Products.FirstOrDefault();

    // Handle the null case
    if (firstProduct != null)
    {
      return firstProduct;
    }
    else
    {
      return null;
    }

  }

  // Retrieve a specific product by ID
  public Product? GetProductById(int productId)
  {
    var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);

    // Handle the null case
    if (product != null)
    {
      return product;
    }
    else
    {
      return null;
    }
  }

  // Retrieve all products with a certain model year
  public IQueryable<Product> GetProductsByModelYear(int modelYear)
  {
    return _dbContext.Products.Where(p => p.ModelYear == modelYear);
  }

  #endregion

  #region Customers

  // Retrieve a specific customer by ID
  public Customer? GetCustomerById(int customerId)
  {
    var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);

    // Handle the null case
    if (customer != null)
    {
      return customer;
    }
    else
    {
      return null;
    }
  }

  #endregion

  #region Querying

  // Retrieve product names and their corresponding brand names
  public IQueryable<object> GetProductsWithBrandNames()
  {
    return _dbContext.Products.Select(p => new { p.ProductName, p.Brand.BrandName });
  }

  // Count the number of products in a specific category
  public int CountProductsInCategory(int categoryId)
  {
    return _dbContext.Products.Count(p => p.CategoryId == categoryId);
  }

  // Calculate the total list price of all products in a specific category
  public decimal CalculateTotalListPriceInCategory(int categoryId)
  {
    return _dbContext.Products.Where(p => p.CategoryId == categoryId).Sum(p => p.ListPrice);
  }

  // Calculate the average list price of products
  public decimal CalculateAverageListPrice()
  {
    return _dbContext.Products.Average(p => p.ListPrice);
  }

  #endregion

  #region Orders

  // Retrieve orders that are completed
  public IQueryable<Order> GetCompletedOrders()
  {
    return _dbContext.Orders.Where(o => o.OrderStatus == 4);
  }

  #endregion
}

