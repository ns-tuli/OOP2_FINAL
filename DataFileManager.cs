using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OOP2_FINAL_PROJECT
{
    public class DataFileManager
    {
        List<Shop> shops;
        public static void SaveShopsToFile(List<Shop> shops)
        {
            try
            {
                string filePath = "C:\\OOP CODES\\OOP2 FINAL PROJECT\\Shop.txt";
                using (StreamWriter writer = new StreamWriter(filePath,true))
                {
                    foreach (Shop shop in shops)
                    {
                        // Write shop information
                        writer.WriteLine("ShopInfo");
                        writer.WriteLine($"ShopName: {shop.ShopName}");
                        writer.WriteLine($"ShopCode: {shop.ShopCode}");
                        writer.WriteLine($"ShopType: {shop.ShopType}");
                        writer.WriteLine($"ShopAddress: {shop.ShopAddress}");

                        // Write each product information
                        writer.WriteLine("Products");
                        foreach (Product product in shop.Products)
                        {
                            writer.WriteLine($"ProductId: {product.Id}");
                            writer.WriteLine($"ProductName: {product.ProductName}");
                            writer.WriteLine($"ProductType: {product.ProductType}");
                            writer.WriteLine($"Price: {product.Price}");
                            writer.WriteLine($"QuantityInStock: {product.QuantityInStock}");
                        }

                        // Write each sales transaction information
                        writer.WriteLine("Sales");
                        foreach (Transaction transaction in shop.Sales)
                        {
                            writer.WriteLine($"TransactionDate: {transaction.Date}");
                            writer.WriteLine($"TotalAmount: {transaction.TotalAmount}");

                            // Write each purchased product in the transaction
                            writer.WriteLine("PurchasedProducts");
                            foreach (Product purchasedProduct in transaction.PurchasedProducts)
                            {
                                writer.WriteLine($"PurchasedProductId: {purchasedProduct.Id}");
                                // Add other properties as needed
                            }
                        }

                        writer.WriteLine(); // Add a blank line to separate shop entries
                    }

                    //Console.WriteLine("Shops data saved to 'shop.txt' successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data to file: {ex.Message}");
            }
        }

        public static void ShowAllShops()
        {
            try
            {
                string filePath = "C:\\OOP CODES\\OOP2 FINAL PROJECT\\Shop.txt";
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string shopName = reader.ReadLine();

                        if (shopName != null && shopName.StartsWith("ShopName:"))
                        {
                            Console.WriteLine($"Shop Information:");

                            // Display shop information
                            Console.WriteLine(shopName);
                            Console.WriteLine(reader.ReadLine()); // ShopCode
                            Console.WriteLine(reader.ReadLine()); // ShopType
                            Console.WriteLine(reader.ReadLine()); // ShopAddress

                            // Display product information
                            string productLine;
                            while ((productLine = reader.ReadLine()) != null && !string.IsNullOrWhiteSpace(productLine) && productLine.StartsWith("ProductId:"))
                            {
                                Console.WriteLine("  Product Information:");
                                Console.WriteLine(productLine);
                                Console.WriteLine(reader.ReadLine()); // ProductName
                                Console.WriteLine(reader.ReadLine()); // ProductType
                                Console.WriteLine(reader.ReadLine()); // Price
                                Console.WriteLine(reader.ReadLine()); // QuantityInStock
                            }

                            // Display transaction information
                            string transactionLine;
                            while ((transactionLine = reader.ReadLine()) != null && !string.IsNullOrWhiteSpace(transactionLine) && transactionLine.StartsWith("TransactionDate:"))
                            {
                                Console.WriteLine("  Transaction Information:");
                                Console.WriteLine(transactionLine);
                                Console.WriteLine(reader.ReadLine()); // TotalAmount

                                // Display purchased products in the transaction
                                string purchasedProductLine;
                                while ((purchasedProductLine = reader.ReadLine()) != null && !string.IsNullOrWhiteSpace(purchasedProductLine) && purchasedProductLine.StartsWith("PurchasedProductId:"))
                                {
                                    Console.WriteLine("    Purchased Product Information:");
                                    Console.WriteLine(purchasedProductLine);
                                    // Add other properties as needed
                                }
                            }

                            Console.WriteLine(); // Add a line break between shops
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data from file: {ex.Message}");
            }
        
    }
}

    
}