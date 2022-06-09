using backendShopApp.Models;

namespace backendShopApp.Services;

public interface IServiceItem
{
    public List<ItemDto> GetAll();

    public string Update(ItemDto obj);

    public string Create(ItemDto obj);

    public string Delete(string id);

}