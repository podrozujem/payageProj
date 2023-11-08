using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Core.Repository.payment
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAll();
        IEnumerable<Payment> GetAllCaptured();
        Payment GetById(string id);

        Payment Create(Payment payment);

        Payment Update(Payment payment);
    }
}
