using Shopify.Views;
namespace Shopify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            //Shopify shopify = new Shopify();
            ProductsList p = new ProductsList(["aa"], "Smartfony");
            p.InitView();
        }
    }
}
