using Calculator;
using System.Net.Http.Headers;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        //Test para validar que el descuento sea mayor a 10 o menor a 60 o igual a 5
        public void TestDiscount()
        {
            Product product = new Product("Producto 1", 100, 5);
            product.SetDiscount();
            Assert.AreEqual(5, product.discountPercent);
            Assert.AreEqual(10, product.discountPercent);
            Assert.AreEqual(60, product.discountPercent);

            Assert.AreEqual("Error: El descuento debe ser mayor a 10 o menor a 60 o igual a 5", product.SetDiscount());
            Assert.AreEqual("El descuento es correcto", product.SetDiscount());

        }

        //Test para validar que el precio final sea correcto
        public void TestFinalAmmount()
        {
            Purchase purchase = new Purchase();
            Product product1 = new Product("Producto 1", 1000, 5);

            purchase.Add(product1);
            purchase.UpdateFinalAmmount();

            Assert.AreEqual(950, purchase.finalAmmount);

            Product product2 = new Product("Producto 2", 1000, 10);

            purchase.Add(product2);
            purchase.UpdateFinalAmmount();

            Assert.AreEqual(1900, purchase.finalAmmount);

        }

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
            purchase.UpdateFinalAmmount();

            Assert.AreEqual(1800, purchase.finalAmmount);

        }

        //test para validar el total del descuento
        public void TestDiscountTotal()
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
            purchase.UpdateFinalAmmount();

            Assert.AreEqual(500, purchase.UpdateDiscount());

        }
    }
}

