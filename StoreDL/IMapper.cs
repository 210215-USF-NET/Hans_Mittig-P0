using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    public interface IMapper
    {
         Model.Customer ParseCustomer(Entity.Customer customer);
         Entity.Customer ParseCustomer(Model.Customer customer);

         Model.Location ParseLocation(Entity.Location location);
         Entity.Location ParseLocation(Model.Location location);

         Model.Inventory ParseInventory(Entity.Inventory inventory);
         Entity.Inventory ParseInventory(Model.Inventory inventory);

         Model.Product ParseProducts(Entity.Product products);

         Entity.Product ParseProducts(Model.Product products);

         Model.Orders ParseOrder(Entity.Order order);

         Entity.Order ParseOrder(Model.Orders order);

         Model.Manager ParseManager(Entity.Manager manager);
         Entity.Manager ParseManager(Model.Manager manager);
    }
}