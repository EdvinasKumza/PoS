using WebApplication1.Models;

namespace PoS.Repositories.DiscountRepository
{
    public interface IDiscountRepository
    {
        Discount GetById(string discountId);
        IEnumerable<Discount> GetAll();
        void Create(Discount discount);
        void Update(Discount discount);
        void Delete(string discountId);
    }
}