using HospitalLibrary.Core.Dto;
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
        Payment UpdateStatusVoid(string id);
        Payment UpdateStatusCaptured(string id);

        IEnumerable<ShowCapturedPayments> GetAllCaptured(int page, int pageSize);
        List<ShowCapturedPayments> GetCaptured();

    }
}
