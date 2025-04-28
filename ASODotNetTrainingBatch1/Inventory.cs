using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ASODotNetTrainingBatch1
{
    internal class Inventory
    {
        public void CreateProduct()
        {
            Console.Write("Input the product name : ");
            string productName = Console.ReadLine()!;

            BeforeEnterPrice:
            Console.Write("Input the Product Price : ");
            string priceResult = Console.ReadLine()!;
            decimal price = 0;
            bool isDeciaml = decimal.TryParse(priceResult, out price); 
            if (!isDeciaml) 
            {
                Console.WriteLine("Invalid Price.");
                goto BeforeEnterPrice;
            }

        BeforeEnterQuantity:
            Console.Write("Enter the quantity : ");
            string quantityResult = Console.ReadLine()!;
            bool isInteger = int.TryParse(quantityResult, out int quantity);
            if (!isInteger)
            {
                Console.WriteLine("Something went Wrong! Try Again!");
                goto BeforeEnterQuantity;
            }
            //int no = Data.Products.Max(x => x.Id);
            //Data.ProductId = no;
            Data.ProductId++;
            string productCode = "P" + Data.ProductId.ToString().PadLeft(3, '0'); 

            Product product = new Product(Data.ProductId, productCode, productName, price, quantity, "Fruit");
            Data.Products.Add(product);
            Console.WriteLine("Product add successfully!");

            
        }

        public void ViewProduct()
        {
            foreach (var product in Data.Products)
            {
                Console.WriteLine($"Id : {product.Id} , Code : {product.Code} , Name : {product.Name} , Price : {product.Price} , Quantity : {product.Quantity} , Category : {product.Category}");
            }

        }

        public void UpdateProduct()
        {
            beforeProductCode:
            Console.Write("Input the Product Code : ");
            string inputCode = Console.ReadLine()!;
            var product = Data.Products.FirstOrDefault(x => x.Code == inputCode);
            if (product is null)
            {
                Console.WriteLine("Product doesn't found!");
                goto beforeProductCode;
            }
            Console.WriteLine("Product Found ");
            Console.WriteLine($"Code : {product.Code} , Name : {product.Name} , Quanitity : {product.Quantity}");
            beforeInputQuantity:
            Console.Write("Input the Quantity : ");
            string quantityResult = Console.ReadLine()!;
            bool isInteger = int.TryParse(quantityResult, out var inputQuantity);
            if (!isInteger)
            {
                Console.WriteLine("Something Went Wrong");
                goto beforeInputQuantity;
            }
            product.Quantity -= inputQuantity;
            Console.WriteLine("Update successfully");
        }
        public void DeleteProduct()
        {
            foreach (var product1 in Data.Products)
            {
                Console.WriteLine($"Code : {product1.Code} , Name : {product1.Name}");
            }
            beforeProductCode:
            Console.Write("Input the Code you wamt to delete : ");
            string inputCode = Console.ReadLine()!;
            var product = Data.Products.FirstOrDefault(x => x.Code == inputCode);

            if (product is null)
            {
                Console.WriteLine("Something went wrog !");
                goto beforeProductCode;
            }
            beforeCommand:
            Console.Write($"sure to delete {product.Code} , {product.Name} (Y/N) : ");
            string comfirm = Console.ReadLine()!;
            if (comfirm is null)
            {
                Console.WriteLine("Select the correct command");
                goto beforeCommand;
            }
            else if (comfirm.ToUpper() == "Y")
            {
                Data.Products.Remove(product);
                Console.WriteLine("Delete Successfully");
            }
            else if (comfirm.ToUpper() == "N")
            {
                Console.WriteLine("Data is not delete!");
            }
            else
            {
                Console.WriteLine("Select the correct command");
                goto beforeCommand;
            }

        }
    }
}