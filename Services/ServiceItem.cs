using backendShopApp.Repositories;
using backendShopApp.Models;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace backendShopApp.Services;

public class ServiceItem : IServiceItem
{
    private readonly IConfiguration _config;
    private readonly IRepositoryItem _repositoryItem;
    private readonly IRepositoryCategory _repositoryCategory;
    private readonly IRepositorySubitems _repositorySubitems;
    private readonly IRepositoryImage _repositoryImage;
    private readonly IRepositoryBrand _repositoryBrand;
    private readonly IRepositoryComment _repositoryComment;
    private readonly IMapper _mapper;

    public ServiceItem(
        IRepositoryItem repositoryItem, IRepositoryCategory repositoryCategory,
        IRepositorySubitems repositorySubitems, IConfiguration config,
        IRepositoryImage repositoryImage, IRepositoryBrand repositoryBrand,
        IRepositoryComment repositoryComment, IMapper mapper)
    {
        _repositoryItem = repositoryItem;
        _repositoryCategory = repositoryCategory;
        _repositoryImage = repositoryImage;
        _repositorySubitems = repositorySubitems;
        _repositoryBrand = repositoryBrand;
        _repositoryComment = repositoryComment;
        _config = config;
        _mapper = mapper;
    }

    // DONE
    public List<ItemDto> GetAll()
    {
        try
        {
            var items = _repositoryItem.GetAll();

            if (items is null)
                return new List<ItemDto>();


            var itemDtos = new List<ItemDto>();
            foreach (var itm in items)
            {
                var cat = _repositoryCategory.GetById(itm.CategoryId);
                var bra = _repositoryBrand.GetById(itm.BrandId);

                // watchout this code
                var imgs = (from i in _repositoryImage.GetAll()
                            where i.ItemId == itm.Id select i).ToList();

                var subitems = (from i in _repositorySubitems.GetAll()
                            where i.ItemId == itm.Id select i).ToList();
                
                var comments = (from i in _repositoryComment.GetAll()
                            where i.Id == itm.CommentId select i).ToList();

                var itemdto = _mapper.Map<ItemDto>(itm);
                itemdto.ImageDtos = _mapper.Map<List<ImageDto>>(imgs).ToArray();
                itemdto.SubItemDtos = _mapper.Map<List<SubItemDto>>(subitems).ToArray();
                itemdto.CommentDtos= _mapper.Map<List<CommentDto>>(comments).ToArray();
                itemdto.Category = cat.Name;
                itemdto.Brand = bra.Name;

                itemDtos.Add(itemdto);
            }

            return itemDtos;
        }
        catch (Exception)
        {
            return new List<ItemDto>();
        }

    }

    // DONE
    public string Update(ItemDto itemdto)
    {
        try
        {
            var item = _repositoryItem.GetById(itemdto.Id);

            if(item is null)
                return "No exist!";
            
            if(!itemdto.Title.IsNullOrEmpty())
                item.Title= itemdto.Title;
            
            if(!itemdto.Description.IsNullOrEmpty())
                item.Description= itemdto.Description;

            if(itemdto.Quality >= 1 && itemdto.Quality <= 5)
                item.Quality= itemdto.Quality;

            if(!itemdto.State.IsNullOrEmpty())
                item.State= itemdto.State;    

            if(!itemdto.Category.IsNullOrEmpty())
                item.CategoryId= _repositoryCategory.GetByName(itemdto.Category).Id;

            if(!itemdto.Brand.IsNullOrEmpty())
                item.BrandId= _repositoryBrand.GetByName(itemdto.Brand).Id;
            
            if(!itemdto.ImageDtos.IsNullOrEmpty())
                item.Images = _mapper.Map<List<Image>>(itemdto.ImageDtos);

            if(!itemdto.SubItemDtos.IsNullOrEmpty())
                item.SubItems = _mapper.Map<List<SubItem>>(itemdto.SubItemDtos);

            int affectedRows= _repositoryItem.Update(item);

            if(affectedRows > 0)
                return "Success!";

            return "No inserted!";

        }
        catch (Exception)
        {
            return "Database error!";
        }

    }

    // DONE
    public string Create(ItemDto itemdto)
    {

        if(itemdto.Title.IsNullOrEmpty() || itemdto.Description.IsNullOrEmpty() ||
            itemdto.Brand.IsNullOrEmpty() || itemdto.State.IsNullOrEmpty() || 
            itemdto.Category.IsNullOrEmpty() || itemdto.Quality < 0 || itemdto.Quality > 5 ||
            itemdto.ImageDtos.IsNullOrEmpty() || itemdto.SubItemDtos.IsNullOrEmpty())
        {
            return "No empty allow!";   
        }

        try
        {
            // creating an id to new ITEM
            var randomId = "ART-" + new Random().Next(1000, 9999);
            while (true)
            {
                if (_repositoryItem.GetById(randomId) is null)
                    break;

                randomId = "ART-" + new Random().Next(1000, 9999);
            }

            var cat =  _repositoryCategory.GetByName(itemdto.Category);
            var bra = _repositoryBrand.GetByName(itemdto.Brand);
            
            var item = _mapper.Map<Item>(itemdto);
            item.Id= randomId;
            
            item.Images = _mapper.Map<List<Image>>(itemdto.ImageDtos);
            item.SubItems = _mapper.Map<List<SubItem>>(itemdto.SubItemDtos);
            item.CategoryId= cat.Id;
            item.BrandId= bra.Id;

            System.Console.WriteLine(item);

            int affectedRows =  _repositoryItem.Create(item);

            if(affectedRows > 0)
                return "Success!";

            return "No inserted!";

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            return "Database error!";
        }

    }

    // DONE
    public string Delete(string id)
    {

        if(id.IsNullOrEmpty())
            return "No empty allow!";
        
        try
        {
            var item = _repositoryItem.GetById(id);

            if(item is null)
                return "No exist!";
            
            int affectedRows = _repositoryItem.Delete(item);

            if(affectedRows > 0)
                return "Success!";

            return "No inserted!";

        }
        catch (Exception)
        {
           return "Database error!";
        }

    }

}