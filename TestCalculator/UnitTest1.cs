using Calculator;
using System.Net.Http.Headers;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1


    {
        [TestMethod]

        //Test para verificar que el descuento por defecto es igual a 5
        public void TestDefaultDiscountEquals5()
        {
            Purchase purch = new Purchase();
            Product product1 = new Product("Producto 1", 100, 0);
            Product product2 = new Product("Producto 2", 200, 0);
            purch.Add(product1);
            purch.Add(product2);
            // defaultDiscount: 5%, lowerDiscountLimit: 10%, upperrDiscountLimit: 60%,
            // productsForHigherDefaultDiscount: 4, higherDefaultDiscount: 7%,
            // generalDiscountCounter: 3, generalDiscountExtra: 10%
            float finalDiscount = purch.getDiscount(5, 10, 60, 4, 7, 3, 10);
            Assert.AreEqual(finalDiscount, 15.0);
            //Console.WriteLine("Completado test caso 1");

        }

        //[TestMethod]

        //// Test para verificar que retorne un error cuando el descuento está fuera de rango
        //public void TestDiscountOutOfLimits()
        //{

        //    Purchase purch = new Purchase();
                //Product product1 = new Product("Producto 1", 100, 61);
                //Product product2 = new Product("Producto 2", 200, 7);
                //purch.Add(product1);
                //purch.Add(product2);
        //      //// VERIFICAR ERROR CON EXCEPTION 

        //    Assert.AreEqual("Error: El descuento debe ser mayor a 10 o menor a 60 o igual a 5", product2.CheckDiscount());
        

        //}

        [TestMethod]

        //Test para validar el descuento default mas alto (7%)
        public void TestHigherDefaultDiscountEquals7()
        {
            Purchase purch = new Purchase();
            Product product1 = new Product("Producto 1", 100, 0); //7
            Product product2 = new Product("Producto 2", 200, 0); //14
            Product product3 = new Product("Producto 3", 300, 0); //21
            Product product4 = new Product("Producto 4", 400, 0); //28  
            Product product5 = new Product("Producto 5", 500, 0); //35 -> Total Default Discount:105
            purch.Add(product1);
            purch.Add(product2);
            purch.Add(product3);
            purch.Add(product4);
            purch.Add(product5);

            // defaultDiscount: 5%, lowerDiscountLimit: 10%, upperrDiscountLimit: 60%,
            // productsForHigherDefaultDiscount: 4, higherDefaultDiscount: 7%,
            // generalDiscountCounter: 5, generalDiscountExtra: 10%
            float finalDiscount = purch.getDiscount(5, 10, 60, 4, 7, 5, 10);

            //Discounts: def: 7%

            Assert.AreEqual(105, finalDiscount);
            //  Console.WriteLine("Completado test caso 3");

        }


        [TestMethod]
        //Test para validar el descuento general (10%)
        public void TestGeneralDiscountIfGreaterThan5()
        {
            Purchase purch = new Purchase();
            Product product1 = new Product("Producto 1", 100, 0); //7
            Product product2 = new Product("Producto 2", 200, 0); //14
            Product product3 = new Product("Producto 3", 300, 0); //21
            Product product4 = new Product("Producto 4", 400, 0); //28  
            Product product5 = new Product("Producto 5", 500, 0); //35 
            Product product6 = new Product("Producto 6", 600, 0); //42 -> Total Default Discount:147 // Total Price: 2100
            purch.Add(product1);
            purch.Add(product2);
            purch.Add(product3);
            purch.Add(product4);
            purch.Add(product5);
            purch.Add(product6);

            // defaultDiscount: 5%, lowerDiscountLimit: 10%, upperrDiscountLimit: 60%,
            // productsForHigherDefaultDiscount: 4, higherDefaultDiscount: 7%,
            // generalDiscountCounter: 5, generalDiscountExtra: 10%
            float finalDiscount = purch.getDiscount(5, 10, 60, 4, 7, 5, 10);

            //Discounts: def: 7% ->147, + generalDiscount: 10% -> 210 = 357

            Assert.AreEqual(357, finalDiscount);

        }
    }
        //  
}

