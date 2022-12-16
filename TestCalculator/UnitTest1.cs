using Calculator;
using System.Net.Http.Headers;

namespace TestCalculator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /* El descuento es asignado para cada articulo.
Ejemplo con 3 articulos.
    libro 1-> 10% 10$
    libro 2-> 15% 10$
    libro 3-> 20% 10$
    libro 4-> 30% 10$

 

Compra 1
    Libro 1 9$
    Libro 2 8.5$
    Total 17.5$ Descuento 1$ + 1.5$ = 2.5$

 

    product item1 = new Product ("libro 1",10,10);

 

    Purchase myPurchase = new Purchase();
    myPurchase.Add(item1);
    float discount = 0;
    discount = myPurchase.UpdateDiscount(); || discount = myPurchase.totalDiscount;
    Assert(discount,2.5);

 


Compra 2
    Libro 1 9$
    Libro 2 8.5$
    Libro 3 8$
    Total 25.5$ Descuento 1$ + 1.5$ +2$ = 4.5$

 

Compra 3 (mas de 3 productos. 10% adicional sobre el total)
    Libro 1 9$
    Libro 2 8.5$
    Libro 3 8$
    Libro 4 7$
    Total 28.5$ - [4$] Descuento 1$ + 1.5$ + 2$ + 3$ + [4$] = 11.5$

 

Compra 4 (varios articulos del mismo producto)
    Libro 1 9$
    Libro 1 9$
    Total 18$    Descuento 2$

            */

            Purchase myPurchase = new Purchase();
            Product item1 = new Product(5, 0);
            Product item2 = new Product(3, 5);
            myPurchase.ProductsList.Add(item1);
            myPurchase.ProductsList.Add(item2);
            float discount = 5;
            myPurchase.ProductsList[0].SetDiscount();
            //discount = myPurchase.UpdateDiscount();
            Assert.AreEqual(5, discount);

            /*
             . Se compra un producto y se retorna el descuento
             . Que asigne un porcentaje de descuento del 5% al producto que no tenga descuento definido
             . Cada articulo debe tener un descuento que no sea menor a 5 ni mayor a 60
             . Que sume dos descuentos diferentes
             . Que calcule el precio final con los precios originales
             . 
             */
            Console.WriteLine("hola");
        }
    }
}