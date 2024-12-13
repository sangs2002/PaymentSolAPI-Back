using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Model
{
    public class PaymentDetailDBContext: DbContext
    {
        public PaymentDetailDBContext(DbContextOptions<PaymentDetailDBContext> options):base(options) { 
        }


      public DbSet<PaymentDetail> PaymentDetails {  get; set; }
        
        
        


    }
}
