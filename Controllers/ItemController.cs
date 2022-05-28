using Microsoft.AspNetCore.Mvc;
using backendShopApp.DataContext;
using backendShopApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace backendShopApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly BackendShopAppDbContext _db;
    private readonly IConfiguration _config;

    public ItemController(BackendShopAppDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    //[Authorize(Roles="Admin,Client")]
    [HttpGet("GetAllItems")]
    public ActionResult<List<ItemDto>> GetAllItems()
    {
        var allItems = new List<ItemDto>();

        foreach (var item in _db.Items.ToList())
        {   
            // getting images for this especific item
            var images = (from i in _db.Images.ToList()
                        where i.ItemId == item.Id select i).ToList();
            
            var imageDtos = new List<ImageDto>();
            foreach (var img in images)
            {
                imageDtos.Add(new ImageDto
                {
                    Id= img.Id,
                    Path= img.Path,
                });
            }

            // getting subitems for this especific item
            var subitems = (from s in _db.SubItems.ToList()
                            where s.ItemId == item.Id select s).ToList();

            var subItemDtos = new List<SubItemDto>();
            foreach (var sub in subitems)
            {
                subItemDtos.Add(new SubItemDto
                {
                    Id= sub.Id,
                    Price= sub.Price,
                    Descount= sub.Descount,
                    Stock= sub.Stock,
                    State= sub.State,
                    Color= sub.Color,
                    Capacity= sub.Capacity,
                    Size= sub.Size,
                });
            }
            
            // filling allItems variable with all items
            allItems.Add(new ItemDto
            {
                Id= item.Id,
                Title= item.Title,
                Description= item.Description,
                Brand= "brand",
                Category= "category",
                Quality= item.Quality,

                ImageDtos= imageDtos.ToArray(),
                SubItemDtos= subItemDtos.ToArray(),
            });
        }

        return allItems;

    }

    //[Authorize(Roles="Client")]
    [HttpGet("GetAll")]
    public ActionResult<List<ItemDto>> GetAll()
    {
        var allItems = new List<ItemDto>();

        foreach (var item in _db.Items.ToList())
        {   
            // getting images for this specific item
            var images = (from i in _db.Images.ToList()
                        where i.ItemId == item.Id select i).ToList();
            
            var imageDtos = new List<ImageDto>();
            foreach (var img in images)
            {
                imageDtos.Add(new ImageDto
                {
                    Id= img.Id,
                    Path= img.Path,

                    ItemId= item.Id
                });
            }

            // getting subitems for this specific item
            var subitems = (from s in _db.SubItems.ToList()
                            where s.ItemId == item.Id select s).ToList();

            var subItemDtos = new List<SubItemDto>();
            foreach (var sub in subitems)
            {
                subItemDtos.Add(new SubItemDto
                {
                    Id= sub.Id,
                    Price= sub.Price,
                    Descount= sub.Descount,
                    Stock= sub.Stock,
                    State= sub.State,
                    Color= sub.Color,
                    Capacity= sub.Capacity,
                    Size= sub.Size,

                    ItemId= item.Id
                });
            }

            // getting comments for this specific item
            var comments = (from c in _db.Comments.ToList()
                            where c.Id == item.CommentId select c).ToList();

            var commentDtos = new List<CommentDto>();
            foreach (var c in comments)
            {   
                commentDtos.Add(new CommentDto
                {
                    Id= c.Id,
                    Text= c.Text,
                    Date= c.Date,
                    State= c.State,

                    ItemId= item.Id
                });
            }

            // storing 'the' brand of this specific item
            var brand = (from c in _db.Brands.ToList()
                            where c.Id == item.BrandId select c).FirstOrDefault();

            // storing 'the' category of this specific item
            var category = (from c in _db.Categories.ToList()
                            where c.Id == item.CategoryId select c).FirstOrDefault();
            
            // filling the ItemDto list that will be giving to the front-end
            allItems.Add(new ItemDto
            {
                Id= item.Id,
                Title= item.Title,
                Description= item.Description,
                Brand= brand.Name,
                Category= category.Name,
                Quality= item.Quality,

                ImageDtos= imageDtos.ToArray(),
                SubItemDtos= subItemDtos.ToArray(),
                CommentDtos= commentDtos.ToArray()
            });
        }

        return allItems;
    }

}