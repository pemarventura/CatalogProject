using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions{
        public static ItemDto AsDto(this Item item){
            return new ItemDto
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price, 
                CreatedDate = DateTimeOffset.UtcNow
            };
        }

        public static Item AsNonDto(this ItemDto itemDto){
            return new Item
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
        }
    }
}