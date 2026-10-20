namespace Talabat.Application.Abstractions.DTOs.Basket
{
    public record BasketDto
    {
        public required string Id { get; set; }
        public IEnumerable<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}

