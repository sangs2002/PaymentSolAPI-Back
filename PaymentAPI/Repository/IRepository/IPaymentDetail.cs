using PaymentAPI.Model;

namespace PaymentAPI.Repository.IRepository
{
    public interface IPaymentDetail
    {
        //object PaymentDetails { get; set; }

        Task<List<PaymentDetail>>GetAll();

        Task<PaymentDetail> GetById(int id);

        Task Update(PaymentDetail enity);

        Task Create(PaymentDetail entity);

        Task Delete(PaymentDetail entity);


        Task Save();
    }
}
