namespace Web_project01.Models
{
    public class ProductInfo
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ImageUrl { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public int ProductId { get; set; }
    }
}
