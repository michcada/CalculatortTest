using Calculator;
using System.Net.Http.Headers;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1

    {
        [TestMethod]

        //1. Test para verificar que el descuento por defecto es igual a 5
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
            //Setting up discount values.
            purch.discount.defaultDiscount = 5;
            purch.discount.lowerDiscountLimit = 0;
            purch.discount.upperDiscountLimit = 60;
            purch.discount.productCountLimitToDefaultDiscount = 4;
            purch.discount.higherDiscount = 7;
            purch.discount.productCountLimitToHigherDiscount = 3;
            purch.discount.generalDiscount = 10;
            double finalDiscount = purch.getDiscount();
            Assert.AreEqual(finalDiscount, 15.0);
        }

        //[TestMethod]

        ////2. Test para verificar que retorne un error cuando el descuento est� fuera de rango
        //public void TestErrorThrowIfDiscountOutOfLimits()
        //{

        //    Purchase purch = new Purchase();
        //Product product1 = new Product("Producto 1", 100, 61);
        //Product product2 = new Product("Producto 2", 200, 7);
        //purch.Add(product1);
        //purch.Add(product2);
        //      //// VERIFICAR ERROR CON EXCEPTION 

        //    Must do an Assert that comparates an ERROR
        //}

        //        [TestMethod]

        //        //3. Test para validar el descuento default mas alto (7%)
        //        public void TestHigherDefaultDiscountEquals7()
        //        {
        //            Purchase purch = new Purchase();
        //            Product product1 = new Product("Producto 1", 100, 0); //7
        //            Product product2 = new Product("Producto 2", 200, 0); //14
        //            Product product3 = new Product("Producto 3", 300, 0); //21
        //            Product product4 = new Product("Producto 4", 400, 0); //28  
        //            Product product5 = new Product("Producto 5", 500, 0); //35 -> Total Default Discount:105
        //            purch.Add(product1);
        //            purch.Add(product2);
        //            purch.Add(product3);
        //            purch.Add(product4);
        //            purch.Add(product5);
        //            // ---- Refactor: Parameters to Prop or Atributes of the Class------------//
        //            // defaultDiscount: 5%, lowerDiscountLimit: 10%, upperrDiscountLimit: 60%,
        //            // productsForHigherDefaultDiscount: 4, higherDefaultDiscount: 7%,
        //            // generalDiscountCounter: 5, generalDiscountExtra: 10%
        //            double finalDiscount = purch.getDiscount(5, 10, 60, 4, 7, 5, 10);

        //            //Discounts: def: 7%

        //            Assert.AreEqual(105, finalDiscount);
        //        }


        //        [TestMethod]
        //        //4. Test para validar el descuento general (10%)
        //        public void TestGeneralDiscountIfGreaterThan5()
        //        {
        //            Purchase purch = new Purchase();
        //            Product product1 = new Product("Producto 1", 100, 0); //7
        //            Product product2 = new Product("Producto 2", 200, 0); //14
        //            Product product3 = new Product("Producto 3", 300, 0); //21
        //            Product product4 = new Product("Producto 4", 400, 0); //28  
        //            Product product5 = new Product("Producto 5", 500, 0); //35 
        //            Product product6 = new Product("Producto 6", 600, 0); //42 -> Total Default Discount:147 // Total Price: 2100
        //            purch.Add(product1);
        //            purch.Add(product2);
        //            purch.Add(product3);
        //            purch.Add(product4);
        //            purch.Add(product5);
        //            purch.Add(product6);

        //            // defaultDiscount: 5%, lowerDiscountLimit: 10%, upperrDiscountLimit: 60%,
        //            // productsForHigherDefaultDiscount: 4, higherDefaultDiscount: 7%,
        //            // generalDiscountCounter: 5, generalDiscountExtra: 10%
        //            double finalDiscount = purch.getDiscount(5, 10, 60, 4, 7, 5, 10);

        //            //Discounts: def: 7% ->147, + generalDiscount: 10% -> 210 = 357

        //            Assert.AreEqual(357, finalDiscount);

        //        }
        //        [TestMethod]
        //        //5. test para chequear si son mas decimales
        //        public void Test_Discount_Handle_Decimals()
        //        {
        //            Purchase purch = new Purchase();
        //            Product product1 = new Product("Producto 1", 45.23, 18); //8.1414
        //            Product product2 = new Product("Producto 2", 170, 23); //39.1
        //            purch.Add(product1);
        //            purch.Add(product2);
        //            double finalDiscount = purch.getDiscount(5, 10, 60, 4, 7, 5, 10);
        //            Assert.AreEqual(47.2414, finalDiscount);
        //        }

        //        [TestMethod]
        //        //6. HappyPath
        //        public void TestMultipleDiscounts()
        //        {
        //            Purchase purch = new Purchase();
        //            Product product1 = new Product("Producto 1", 100, 18); //5
        //            Product product2 = new Product("Producto 2", 200, 23); //10
        //            Product product3 = new Product("Producto 3", 200, 23); //10
        //            Product product4 = new Product("Producto 4", 200, 23); //10
        //            Product product5 = new Product("Producto 5", 200, 23); //10
        //            Product product6 = new Product("Producto 6", 200, 23); //10 
        //            Product product7 = new Product("Producto 7", 200, 23); //10
        //            purch.Add(product1);
        //            purch.Add(product2);
        //            double finalDiscount = purch.getDiscount(5, 10, 60, 4, 7, 5, 10);
        //            //Assertion
        //        }

    }
}
