using Calculator;
using System.Net.Http.Headers;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        //Test para verificar que el descuento por defecto es igual a 5
        public void TestDefaultDiscount()
        {
            Product product = new Product("Producto 1", 100);
            Product product2 = new Product("Producto 2", 100, 100);
            /*        product.CheckDiscount();
                    Assert.AreEqual(5, product.discountPercent);
                    Assert.AreEqual(10, product.discountPercent);
                    Assert.AreEqual(60, product.discountPercent);*/

            Assert.AreEqual("El descuento es correcto", product.CheckDiscount());
            Console.WriteLine("Completado test caso 1");

        }

        [TestMethod]

        // Test para verificar que retorne un error cuando el descuento está fuera de rango
        public void TestDiscountOutOfLowerLimit()
        {

            Product product2 = new Product("Producto 2", 100, 100);
            Product product3 = new Product("Producto 2", 100, 4);
            /*        product.CheckDiscount();
                    Assert.AreEqual(5, product.discountPercent);
                    Assert.AreEqual(10, product.discountPercent);
                    Assert.AreEqual(60, product.discountPercent);*/

            Assert.AreEqual("Error: El descuento debe ser mayor a 10 o menor a 60 o igual a 5", product2.CheckDiscount());
            Assert.AreEqual("Error: El descuento debe ser mayor a 10 o menor a 60 o igual a 5", product3.CheckDiscount());
            Console.WriteLine("Completado test caso 2");

        }

        [TestMethod]

        //Test para validar que los descuentos se aplican correctamente
        public void TestFinalAmmount()
        {
            Purchase purchase = new Purchase();
            Product product1 = new Product("Producto 1", 1000);

            purchase.Add(product1);

            Product product2 = new Product("Producto 2", 1000, 10);

            purchase.Add(product2);
            purchase.UpdateFinalAmmount();

            Assert.AreEqual(1850, purchase.finalAmmount);
            Console.WriteLine("Completado test caso 3");

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
            purchase.UpdateFinalAmmount();

            Assert.AreEqual(3150, purchase.finalAmmount);
            Console.WriteLine("Completado test caso 4");

        }

        [TestMethod]
       
        //test para validar que si se hacen dos compras, a cada compra se le aplica un descuento del 10% adicional sin importar si el cliente es el mismo
        public void TestDiscountAdditional2()
        {
            Purchase purchase = new Purchase();
            Purchase purchase2 = new Purchase();
            Product product1 = new Product("Producto 1", 1000, 5);  //50  950
            Product product2 = new Product("Producto 2", 1000, 10); //100 900
            Product product3 = new Product("Producto 3", 1000, 15); //150 850
            Product product4 = new Product("Producto 4", 1000, 20); //200 800
            purchase.Add(product1);
            purchase.Add(product2);
            purchase.Add(product3);
            purchase.Add(product4);
            //añadir los mismos productos a la segunda compra
            purchase2.Add(product1);
            purchase2.Add(product2);
            purchase2.Add(product3);
            purchase2.Add(product4);

            purchase.UpdateFinalAmmount();

            Assert.AreEqual(3150, purchase.finalAmmount);

            purchase2.UpdateFinalAmmount();

            Assert.AreEqual(3150, purchase2.finalAmmount);

        }

    }
}

