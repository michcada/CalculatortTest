using Calculator;
using System.Net.Http.Headers;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //test para validar el total del descuento
        public void TestDiscountTotal()
        {
            Purchase purchase = new Purchase();
            Product product1 = new Product("Producto 1", 1000, 5);  //50  950
            Product product2 = new Product("Producto 2", 1000, 10); //100 900
            Product product3 = new Product("Producto 5", 1000);    //50  950

            purchase.Add(product1);
            purchase.Add(product2);
            purchase.Add(product3);

            Assert.AreEqual(20, purchase.UpdateDiscount());
            
        }

        [TestMethod]
        //test para validar que el descuento adicional se aplique si la cantidad de productos es mayor a 3
        public void TestDiscountAdditional()
        {
            Purchase purchase = new Purchase();
            Product product1 = new Product("Producto 1", 1000, 5);  //50  950
            Product product2 = new Product("Producto 2", 1000, 10); //100 900
            Product product3 = new Product("Producto 3", 1000, 15); //150 850
            Product product4 = new Product("Producto 4", 1000, 20); //200 800

            purchase.Add(product1);
            purchase.Add(product2);
            purchase.Add(product3);
            purchase.Add(product4);

            Assert.AreEqual(5, purchase.UpdateDiscountAdditional()); //descuento adicional
            Assert.AreEqual(55, purchase.UpdateDiscount()); //descuento total

        }

        [TestMethod]
        //test para validar que el descuento adicional se aplique si la cantidad de productos es mayor a 6
        public void TestDiscountAdditional2()
        {
            Purchase purchase = new Purchase();
            Product product1 = new Product("Producto 1", 1000, 5);  //50  950
            Product product2 = new Product("Producto 2", 1000, 10); //100 900
            Product product3 = new Product("Producto 3", 1000, 15); //150 850
            Product product4 = new Product("Producto 4", 1000, 20); //200 800
            Product product5 = new Product("Producto 5", 1000, 25); //250 750
            Product product6 = new Product("Producto 6", 1000, 30); //300 700
            Product product7 = new Product("Producto 7", 1000, 35); //350 650

            purchase.Add(product1);
            purchase.Add(product2);
            purchase.Add(product3);
            purchase.Add(product4);
            purchase.Add(product5);
            purchase.Add(product6);
            purchase.Add(product7);

            Assert.AreEqual(7, purchase.UpdateDiscountAdditional()); //descuento adicional
            Assert.AreEqual(147, purchase.UpdateDiscount()); //descuento total

        }

        
    }
}

