using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Catalogs.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        //Determina que quando alguem utilizar a rota \items da API com um método Http do tipo Get, o resultado apresentado será trazido por este método
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select( item => item.AsDto());
            return items;
        }

        [HttpGet("{Id}")]
        public ActionResult<ItemDto> GetItem(Guid Id)
        {
            var item = repository.GetItem(Id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        //Post/items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto createItemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {Id = item.Id}, item.AsDto());
        }

        [HttpPut("{Id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null){
                return NotFound();
            }
            
            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }
    }
}