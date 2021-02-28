using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    public interface IMapper
    {
         Model.Customer ParseCustomer(Entity.Customer customer);
         Entity.Customer ParseCustomer(Model.Customer customer);
    }
}