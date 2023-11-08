using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.payment
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetAll(); 
        void Create(Payment paymentDTO);
        void Update(Payment paymentDTO);
        Payment GetById(string id); 
        Payment UpdateStatusAuthorized(string id);
        Payment UpdateStatusCaptured(string id);

        IEnumerable<Payment> GetAllCaptured(int page, int pageSize);
        List<Payment> GetCaptured();

    }
}
