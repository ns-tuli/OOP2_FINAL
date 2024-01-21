using OOP2_FINAL_PROJECT;
using System;


public class UserInterface
{
    static List<Shop> shops = new List<Shop>();

    static void Main()
    {
       

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Shop");
            Console.WriteLine("2. Remove Shop");
            Console.WriteLine("3. Add Product to Shop");
            Console.WriteLine("4. View Shop Products");
            Console.WriteLine("5. Make Transaction");
            Console.WriteLine("6. View Shop Sales Report");
            Console.WriteLine("7. Check Shop Existence");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateShop();
                    break;
                case "2":
                    RemoveShop();
                    break;
                case "3":
                    AddProductToShop();
                    break;
                case "4":
                    ViewShopProducts();
                    break;
                case "5":
                    MakeTransaction();
                    break;
                case "6":
                    ViewShopSalesReport();
                    break;
                case "7":
                    CheckShopExistence();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    break;
            }
        }
    }



    static void CreateShop()
    {
        Console.WriteLine();
        Console.WriteLine("Current shops available ^ ^ : ");
       
        Console.WriteLine();

        foreach (var shop in shops)
        {
            Console.WriteLine($"Shop: {shop.ShopName}, Code: {shop.ShopCode}, Type: {shop.ShopType}");
        }

        Console.WriteLine("\nCreating a new shop:");

        Shop newShop = new Shop
        {
            ShopName = GetUserInput("Enter Shop Name: "),
            ShopCode = int.Parse(GetUserInput("Enter Shop Code: ")),
            ShopType = GetUserInput("Enter Shop Type: "),
            ShopAddress = GetUserInput("Enter Shop Address: ")
        };

        if (Validation.IsShopValid(newShop))
        {
            shops.Add(newShop);

            Console.WriteLine($"Shop '{newShop.ShopName}' created successfully!");

            // Save the data to the file after adding the new shop
            DataFileManager.SaveShopsToFile(shops);
        }
        else
        {
            Console.WriteLine("Error: Invalid shop details. Shop not created.");
        }
    }

    static void RemoveShop()
    {
        

        Console.WriteLine("\nRemoving a shop:");

        // Print existing shop codes for debugging
        Console.Write("Existing shop codes: ");
        foreach (var shop in shops)
        {
            Console.Write($"{shop.ShopCode} ");
        }
        Console.WriteLine();

        int shopCodeToRemove = int.Parse(GetUserInput("Enter Shop Code to remove: ").Trim());

        // Print entered shop code for debugging
        Console.WriteLine($"Entered shop code to remove: {shopCodeToRemove}");

        Shop shopToRemove = shops.Find(shop => shop.ShopCode == shopCodeToRemove);

        if (shopToRemove != null)
        {
            shops.Remove(shopToRemove);
            Console.WriteLine($"Shop '{shopToRemove.ShopName}' removed successfully!");

            // Save the data to the file after removing the shop
            DataFileManager.SaveShopsToFile(shops);
        }
        else
        {
            Console.WriteLine($"Error: Shop with Code {shopCodeToRemove} not found.");
        }
    }
    static void AddProductToShop()
    {
        Console.Write("Existing shop codes: ");
        foreach (var shop in shops)
        {
            Console.Write($"{shop.ShopCode} ");
        }
        Console.WriteLine();

        Console.WriteLine("\nAdding a product to a shop:");

        if (shops.Count == 0)
        {
            Console.WriteLine("Error: No shops available. Create a shop first.");
            return;
        }

        int shopCode = int.Parse(GetUserInput("Enter Shop Code: "));

        Shop selectedShop = shops.Find(shop => shop.ShopCode == shopCode);

        if (selectedShop != null)
        {
            Product newProduct = new Product
            {
                Id = int.Parse(GetUserInput("Enter Product ID: ")),
                ProductName = GetUserInput("Enter Product Name: "),
                ProductType = GetUserInput("Enter Product Type: "),
                Price = double.Parse(GetUserInput("Enter Product Price: ")),
                QuantityInStock = int.Parse(GetUserInput("Enter Product Quantity: "))
            };

            selectedShop.Products.Add(newProduct);
            selectedShop.ShopInventory.AddProduct(newProduct, newProduct.QuantityInStock);

            Console.WriteLine($"Product '{newProduct.ProductName}' added to '{selectedShop.ShopName}' successfully!");
        }
        else
        {
            Console.WriteLine($"Error: Shop with Code {shopCode} not found.");
        }
    }

    static void ViewShopProducts()
    {
        Console.Write("Existing shop codes: ");
        foreach (var shop in shops)
        {
            Console.Write($"{shop.ShopCode} ");
        }
        Console.WriteLine();

        Console.WriteLine("\nViewing products in a shop:");

        if (shops.Count == 0)
        {
            Console.WriteLine("Error: No shops available. Create a shop first.");
            return;
        }

        int shopCode = int.Parse(GetUserInput("Enter Shop Code: "));

        Shop selectedShop = shops.Find(shop => shop.ShopCode == shopCode);

        if (selectedShop != null)
        {
            Console.WriteLine($"Products in '{selectedShop.ShopName}':");

            foreach (var product in selectedShop.Products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Product Name: {product.ProductName}, Type: {product.ProductType}, Price: {product.Price}, Quantity: {product.QuantityInStock}");
            }
        }
        else
        {
            Console.WriteLine($"Error: Shop with Code {shopCode} not found.");
        }
    }

    static void ViewShopSalesReport()
    {
        Console.Write("Existing shop codes: ");
        foreach (var shop in shops)
        {
            Console.Write($"{shop.ShopCode} ");
        }
        Console.WriteLine();

        Console.WriteLine("\nViewing shop sales report:");

        if (shops.Count == 0)
        {
            Console.WriteLine("Error: No shops available. Create a shop first.");
            return;
        }

        int shopCode = int.Parse(GetUserInput("Enter Shop Code: "));

        Shop selectedShop = shops.Find(shop => shop.ShopCode == shopCode);

        if (selectedShop != null)
        {
            ShopSalesReport salesReport = new ShopSalesReport();
            salesReport.ViewShopDetails(selectedShop);
        }
        else
        {
            Console.WriteLine($"Error: Shop with Code {shopCode} not found.");
        }



    }

    static string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    // ... (existing code)

    static void MakeTransaction()
    {
        Console.Write("Existing shop codes: ");
        foreach (var shop in shops)
        {
            Console.Write($"{shop.ShopCode} ");
        }
        Console.WriteLine();

        Console.WriteLine("\nMaking a transaction:");

        if (shops.Count == 0)
        {
            Console.WriteLine("Error: No shops available. Create a shop first.");
            return;
        }

        int shopCode = int.Parse(GetUserInput("Enter Shop Code: "));

        Shop selectedShop = shops.Find(shop => shop.ShopCode == shopCode);

        if (selectedShop != null)
        {
            Transaction newTransaction = new Transaction
            {
                Date = DateTime.Now,
                TotalAmount = 0,
                PurchasedProducts = new List<Product>()
            };

            Console.WriteLine($"Making a transaction in '{selectedShop.ShopName}':");

            while (true)
            {
                int productId = int.Parse(GetUserInput("Enter Product ID to purchase (0 to finish): "));

                if (productId == 0)
                    break;

                Product selectedProduct = selectedShop.Products.Find(product => product.Id == productId);

                if (selectedProduct != null)
                {
                    int quantity = int.Parse(GetUserInput($"Enter quantity for '{selectedProduct.ProductName}': "));

                    if (quantity <= selectedProduct.QuantityInStock)
                    {
                        double productCost = quantity * selectedProduct.Price;

                        newTransaction.TotalAmount += productCost;
                        newTransaction.PurchasedProducts.Add(selectedProduct);

                        // Deduct the purchased quantity from the shop's inventory
                        selectedShop.ShopInventory.RemoveProduct(selectedProduct, quantity);

                        Console.WriteLine($"Product '{selectedProduct.ProductName}' (ID: {selectedProduct.Id}) added to the transaction.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Insufficient stock for '{selectedProduct.ProductName}'. Available quantity: {selectedProduct.QuantityInStock}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Product with ID {productId} not found in '{selectedShop.ShopName}'.");
                }
            }

            Console.WriteLine($"Transaction completed. Total Amount: {newTransaction.TotalAmount}");
            selectedShop.Sales.Add(newTransaction);
        }
        else
        {
            Console.WriteLine($"Error: Shop with Code {shopCode} not found.");
        }

        DataFileManager.SaveShopsToFile(shops);
    }

    static void CheckShopExistence()
    {
        int shopCodeToCheck = int.Parse(GetUserInput("Enter Shop Code to check existence: "));

        if (ShopExists(shopCodeToCheck))
        {
            Console.WriteLine($"Shop with Code {shopCodeToCheck} exists.");
        }
        else
        {
            Console.WriteLine($"Shop with Code {shopCodeToCheck} does not exist.");
        }
    }

    static bool ShopExists(int shopCode)
    {
        // Check if a shop with the given shop code exists
        return shops.Any(shop => shop.ShopCode == shopCode && Validation.IsShopValid(shop));
    }

   



}
