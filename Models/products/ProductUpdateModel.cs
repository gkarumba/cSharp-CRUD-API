namespace WebApi.Models.Products
{
    public class ProductUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int User { get; set; }
        public int Price { get; set; }

    }
}