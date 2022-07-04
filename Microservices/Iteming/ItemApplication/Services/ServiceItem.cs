
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using backendShopApp.Microservices.Interfaces.Services;
using backendShopApp.Microservices.Iteming.ItemDomains.Dtos;
using backendShopApp.Microservices.Iteming.ItemDomains.Entities;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Commenting.CommentDomains.Dtos;

namespace backendShopApp.Microservices.Iteming.ItemApplication.Services;

public class ServiceItem : IServiceItem
{

    private readonly IMapper _mapper;
    private readonly IRepositoryItem _repoItem;

    public ServiceItem(
        IMapper mapper, 
        IRepositoryItem repoItem)
    {
        _mapper = mapper;
        _repoItem = repoItem;
    }

    public async Task<List<ItemDto>> GetAll()
    {
        try
        {
            var items = await _repoItem.GetAll();

            if (items is null)
                return new List<ItemDto>();


            var itemDtos = new List<ItemDto>();
            foreach (var itm in items)
            {
                var itemdto = _mapper.Map<ItemDto>(itm);
                itemdto.ImageDtos = _mapper.Map<List<ImageDto>>(itm.Images).ToArray();
                itemdto.SubItemDtos = _mapper.Map<List<SubItemDto>>(itm.SubItems).ToArray();
                itemdto.CommentDtos = _mapper.Map<List<CommentDto>>(itm.Comments).ToArray();

                itemDtos.Add(itemdto);
            }

            return itemDtos;
        }
        catch (Exception e)
        {
            System.Console.WriteLine("/******** "+e.StackTrace+" *******/");

            return new List<ItemDto>();
        }

    }

    public async Task<string> Create(ItemDto itemdto)
    {

        if (string.IsNullOrEmpty(itemdto.Title) || string.IsNullOrEmpty(itemdto.Description) ||
            string.IsNullOrEmpty(itemdto.Brand) || string.IsNullOrEmpty(itemdto.State) ||
            string.IsNullOrEmpty(itemdto.Category) || itemdto.Quality < 0 || itemdto.Quality > 5 ||
            itemdto.ImageDtos.IsNullOrEmpty() || itemdto.SubItemDtos.IsNullOrEmpty())
        {
            return "No empty allow!";
        }

        try
        {
            // creating an id to new ITEM
            var randomId = "ITM-" + new Random().Next(1000, 9999);
            while (true)
            {
                if (await _repoItem.GetById(randomId) is null)
                    break;

                randomId = "ITM-" + new Random().Next(1000, 9999);
            }

            //var cat = _repositoryCategory.GetByName(itemdto.Category);
            //var bra = _repositoryBrand.GetByName(itemdto.Brand);

            var item = _mapper.Map<Item>(itemdto);
            item.Id = randomId;
            item.Images = _mapper.Map<List<Image>>(itemdto.ImageDtos);
            item.SubItems = _mapper.Map<List<SubItem>>(itemdto.SubItemDtos);
            //item.CategoryId = cat.Id;
            //item.BrandId = bra.Id;

            _repoItem.Create(item);

            int affectedRows = await _repoItem.SaveAllChanges();

            if (affectedRows > 0)
                return "Success!";

            return "No action!";

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            return "Database error!";
        }

    }


    public async Task<string> Update(ItemDto itemdto)
    {
        try
        {
            var item = await _repoItem.GetById(itemdto.Id);

            if (item is null)
                return "No exist!";

            if (!string.IsNullOrEmpty(itemdto.Title))
                item.Title = itemdto.Title;

            if (!string.IsNullOrEmpty(itemdto.Description))
                item.Description = itemdto.Description;

            if (itemdto.Quality >= 1 && itemdto.Quality <= 5)
                item.Quality = itemdto.Quality;

            if (!string.IsNullOrEmpty(itemdto.State))
                item.State = itemdto.State;

            if (!string.IsNullOrEmpty(itemdto.Category))
                //item.CategoryId = _repositoryCategory.GetByName(itemdto.Category).Id;

            if (!string.IsNullOrEmpty(itemdto.Brand))
                //item.BrandId = _repositoryBrand.GetByName(itemdto.Brand).Id;

            if (!itemdto.ImageDtos.IsNullOrEmpty())
                item.Images = _mapper.Map<List<Image>>(itemdto.ImageDtos);

            if (!itemdto.SubItemDtos.IsNullOrEmpty())
                item.SubItems = _mapper.Map<List<SubItem>>(itemdto.SubItemDtos);

            _repoItem.Update(item);

            int affectedRows = await _repoItem.SaveAllChanges();

            if (affectedRows > 0)
                return "Success!";

            return "No action!";

        }
        catch (Exception)
        {
            return "Database error!";
        }

    }


    public async Task<string> Delete(string id)
    {

        if (id.IsNullOrEmpty())
            return "No empty allow!";

        try
        {
            var item = await _repoItem.GetById(id);

            if (item is null)
                return "No exist!";

            _repoItem.Delete(item);

            int affectedRows = await _repoItem.SaveAllChanges();

            if (affectedRows > 0)
                return "Success!";

            return "No action!";

        }
        catch (Exception)
        {
            return "Database error!";
        }

    }


}
