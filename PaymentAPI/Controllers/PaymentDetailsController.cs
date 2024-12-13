using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Model;
using PaymentAPI.Repository.IRepository;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly IPaymentDetail _context;

        public PaymentDetailsController(IPaymentDetail context)
        {
            _context = context;
        }

        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetails()
        {
            return await _context.GetAll();
        }

        // GET: api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.GetById(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // PUT: api/PaymentDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetail(int id, PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            //  _context.Entry(paymentDetail).State = EntityState.Modified;
            _context.Update(paymentDetail);

            try
            {
                // await _context.SaveChangesAsync();
                await _context.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return Ok(await _context.PaymentDetails.ToListAsync());
            return Ok( await _context.GetById(id));
        }

        // POST: api/PaymentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> PostPaymentDetail(PaymentDetail paymentDetail)
        {
            //_context.PaymentDetails.Add(paymentDetail);
            _context.Create(paymentDetail);

           // await _context.SaveChangesAsync();
            await _context.Save();

            // return Ok(await _context.PaymentDetails.ToListAsync());
            return Ok(await _context.GetAll());
        }

        // DELETE: api/PaymentDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetail(int id)
        {
            //var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            var paymentDetail = await _context.GetById(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            //_context.PaymentDetails.Remove(paymentDetail);
            _context.Delete(paymentDetail);
            await _context.Save();

           // return Ok(await _context.PaymentDetails.ToListAsync());
            return Ok(await _context.GetAll());
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentDetailId == id);
        }
    }
}
