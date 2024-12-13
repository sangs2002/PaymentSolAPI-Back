using Microsoft.EntityFrameworkCore;
using PaymentAPI.Model;
using PaymentAPI.Repository.IRepository;

namespace PaymentAPI.Repository
{
    public class PaymentDetailRepository : IPaymentDetail
    {

        private readonly PaymentDetailDBContext _dbContext;


        public PaymentDetailRepository(PaymentDetailDBContext dbContext)
        {
            _dbContext = dbContext;
        }

      //  public object PaymentDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task Create(PaymentDetail entity)
        {
           await _dbContext.PaymentDetails.AddAsync(entity);
            await Save();
        }

        public async Task Delete(PaymentDetail entity)
        {
             _dbContext.PaymentDetails.Remove(entity);
            await Save();
        }

        public async Task<List<PaymentDetail>> GetAll()
        {
           List<PaymentDetail> payment= await _dbContext.PaymentDetails.ToListAsync();
            return payment;
        }

        public async Task<PaymentDetail> GetById(int id)
        {
           PaymentDetail payment1= await _dbContext.PaymentDetails.FindAsync(id);
            return payment1;    

        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(PaymentDetail enity)
        {
             _dbContext.PaymentDetails.Update(enity);
            await Save();

        }
    }
}
