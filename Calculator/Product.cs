namespace Calculator
{
    public class Product

    {

        public float price;
        public int discountPercent { get; set; }
        public string itemName;

        //crear el constructor, si no se pasa el descuento, se le asigna 5
        public Product(string name, float price, int discountPercent = 5)
        {
            this.itemName = name;
            this.price = price;
            this.discountPercent = discountPercent;
        }

        //valida que el descuento sea mayor a 10 o menor a 60 o igual a 5. si no cumple mostar mensaje de erorr
        public string CheckDiscount()
        {
            if (discountPercent == 5 || (discountPercent >= 10 && discountPercent <= 60))
            {
                return "El descuento es correcto";
            }
            else
            {
                return "Error: El descuento debe ser mayor a 10 o menor a 60 o igual a 5";

            }
        }

        public float ApplyDiscount()
        {            
            return this.price * discountPercent/100;
        }

    }
}