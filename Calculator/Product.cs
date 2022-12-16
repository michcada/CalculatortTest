namespace Calculator
{
    public class Product

    {

        public float price;
        public int discountPercent { get; set; }


        public Product(float myPrice, int myPercent)
        {
            this.price = myPrice;
            this.discountPercent = myPercent;
            //SetDiscount();
        }

        public void SetDiscount()
        {
            int myPercent = this.discountPercent;
            int LowerLimit = 5;
            int UpperLimit = 60;

            if (myPercent < LowerLimit || myPercent > UpperLimit)
            {
                Console.WriteLine("This product has a not valid discount\nPlease enter a valid value");
               // myPercent= int.Parse(Console.ReadLine());
               if (myPercent < LowerLimit) { myPercent = 5; }
                else
                {
                    myPercent = 60;
                }
            }
        }
        /*
        public Product(float myPrice)
        {
            this.price = myPrice;
            this.discountPercent = 5; //cuando solo se pasa el precio, el descuento por defecto es 5
        }*/



    }
}