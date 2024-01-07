
using PoS.Data;
using WebApplication1.Models;

namespace PoS.Repositories.DiscountRepository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DiscountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Discount GetById(string discountId)
        {
            return _dbContext.Discounts.FirstOrDefault(d => d.DiscountId == discountId);
        }

        public IEnumerable<Discount> GetAll()
        {
            return _dbContext.Discounts.ToList();
        }

        public void Create(Discount discount)
        {
            _dbContext.Discounts.Add(discount);
            _dbContext.SaveChanges();
        }

        public void Update(Discount discount)
        {
            var existingDiscount = _dbContext.Discounts.Find(discount.DiscountId);

            if (existingDiscount != null)
            {
                _dbContext.Entry(existingDiscount).CurrentValues.SetValues(discount);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Discount not found.");
            }
        }

        public void Delete(string discountId)
        {
            var discount = _dbContext.Discounts.Find(discountId);

            if (discount != null)
            {
                _dbContext.Discounts.Remove(discount);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Discount not found.");
            }
        }
    }
}
