namespace SurfsUpWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Thickness { get; set; }
        public double Volume { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public List<string> Equipment { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Length: {Length}, Width: {Width}, Thickness: {Thickness}, Volume: {Volume}, Type: {Type}, Price: {Price}";
        }
    }
}
        