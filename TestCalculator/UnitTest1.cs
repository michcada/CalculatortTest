using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http.Headers;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1

    {
        [TestMethod]
        // Debe calcular y retornar el descuento total de la compra cuando
        // la informacion de descuento y producto son correctos.
        public void ShouldReturnTotalDiscountWhenTheInfoEnteredIsValid()
        {
            Discount discount = new()
            {
                DefaultDiscount = 5,
                LowerDiscountLimit = 0,
                UpperDiscountLimit = 60,
                HigherDiscount = 7,
                ProductCountLimitToDefaultDiscount = 4,
                ProductCountLimitToHigherDiscount = 3,
                GeneralDiscount = 10
            };

            Product product1 = new("Product1", 10, 10);
            Product product2 = new("Product2", 10, 15);

            Purchase purch = new();
            purch.LoadDiscount(discount);
            purch.Add(product1);
            purch.Add(product2);

            double finalDiscount = purch.getDiscount();
            Assert.AreEqual(finalDiscount, 2.5);
        }

        [TestMethod]
        // Debe calcular y retornar el descuento total de la compra cuando
        // el porcentaje de descuento SI esta en el rango de 10% y 60%.
        public void ShouldReturnTotalDiscountWhenThePercentEnteredIsValid()
        {
            Discount discount = new()
            {
                DefaultDiscount = 5,
                LowerDiscountLimit = 10,
                UpperDiscountLimit = 60,
                HigherDiscount = 7,
                ProductCountLimitToDefaultDiscount = 4,
                ProductCountLimitToHigherDiscount = 3,
                GeneralDiscount = 10
            };

            Product product1 = new("Product1", 10, 10);
            Product product2 = new("Product2", 10, 60);

            Purchase purch = new();
            purch.LoadDiscount(discount);
            purch.Add(product1);
            purch.Add(product2);

            var actual = purch.getDiscount();
            var expected = 7;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Debe retornar excepcion con un mensaje cuando
        // el porcentaje de descuento NO esta en el rango de 10% y 60%.
        public void ShouldReturnExceptionWhenThePercentEnteredIsInvalid()
        {
            Discount discount = new()
            {
                DefaultDiscount = 5,
                LowerDiscountLimit = 10,
                UpperDiscountLimit = 60,
                HigherDiscount = 7,
                ProductCountLimitToDefaultDiscount = 4,
                ProductCountLimitToHigherDiscount = 3,
                GeneralDiscount = 10
            };

            Product product1 = new("Product1", 10, 2);
            Product product2 = new("Product2", 10, 70);

            Purchase purch = new();
            purch.LoadDiscount(discount);
            purch.Add(product1);
            purch.Add(product2);

            var actual = Assert.ThrowsException<Exception>(() => purch.getDiscount()).Message;
            var expected = $"The discount percentage must be between " +
                $"{discount.LowerDiscountLimit}% and {discount.UpperDiscountLimit}%";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Debe calcular y retornar el descuento total de la compra aplicando el 5% cuando
        // los articulos NO tengan descuento.
        public void ShouldReturnTotalDiscountWhenItemNotHaveDiscount()
 
        {
            Discount discount = new()
            {
                DefaultDiscount = 5,
                LowerDiscountLimit = 10,
                UpperDiscountLimit = 60,
                HigherDiscount = 7,
                ProductCountLimitToDefaultDiscount = 4,
                ProductCountLimitToHigherDiscount = 3,
                GeneralDiscount = 10
            };

            Product product1 = new("Product1", 10, 0);
            Product product2 = new("Product2", 10, 0);

            Purchase purch = new();
            purch.LoadDiscount(discount);
            purch.Add(product1);
            purch.Add(product2);

            var actual = purch.getDiscount();
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }



        //[TestMethod]

        ////2. Test para verificar que retorne un error cuando el descuento está fuera de rango
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

        //3. Test to verify that the most higher default discount equals seven
        //        public void TestWhenThereAreMoreThanFourProductsDefaultDiscountShouldBeSeven()
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
        //        //4. Test to verify that the general discount applied to the purchase is 10
        //        public void TestWhenThereAreMoreThanFiveProductsPurchaseDiscountShouldBeTen()
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
        //        //5. Test to check if the program handles decimals
        //        public void TestWhenDiscountOrPriceHaveDecimalsTheProgramShouldHandleThem()
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
