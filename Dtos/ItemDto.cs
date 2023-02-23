namespace Catalog.Dtos
{
    public record ItemDto
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public Guid Id {get; init; }
        public string Name { get; init; }

        public decimal Price { get; init; }

        [System.Text.Json.Serialization.JsonIgnore]
        public DateTimeOffset CreatedDate {get; init; }

    }
}
