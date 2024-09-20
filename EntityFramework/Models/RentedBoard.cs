namespace EntityFramework.Models 
{
    public class RentedBoard 
    {
        public int Id { get; set;}
        public int BoardId { get; set;}
        public Product Product { get; set;}
        public int UserId { get; set;}
    }
}