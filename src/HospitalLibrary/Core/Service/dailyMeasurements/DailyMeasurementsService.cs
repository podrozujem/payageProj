using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository.dailyMeasurement;
using HospitalLibrary.Core.Repository.doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.dailyMeasurements
{
    public class DailyMeasurementsService: IDailyMeasurementsService
    {
        private readonly IDailyMeasurementsRepository _dailyMeasurementsRepository;

        public DailyMeasurementsService(IDailyMeasurementsRepository dailyMeasurementsRepository)
        {
            _dailyMeasurementsRepository = dailyMeasurementsRepository;
        }
        public IEnumerable<DailyMeasurements> GetAll()
        {
            return _dailyMeasurementsRepository.GetAll();
        }
        public DailyMeasurements GetById(string id)
        {
            return _dailyMeasurementsRepository.GetById(id);
        }
        public void Create(DailyMeasurements dailyMeasurements)
        {
            _dailyMeasurementsRepository.Create(dailyMeasurements);
        }

        public void Delete(DailyMeasurements dailyMeasurements)
        {
            _dailyMeasurementsRepository.Delete(dailyMeasurements);
        }
        public void Update(DailyMeasurements dailyMeasurements)
        {
            _dailyMeasurementsRepository.Update(dailyMeasurements);
        }
        //public DailyMeasurements CheckLoginCredentials(string email, string password)
        //{
        //    return _doctorRepository.CheckLoginCredentials(email, password);
        //}
    }
}
