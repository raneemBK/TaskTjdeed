namespace TaskTjdeed.DTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public List<OrderProductDto> Products { get; set; } = new List<OrderProductDto>();
    }
}
