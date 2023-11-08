using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service.dailyMeasurements
{
    public interface IDailyMeasurementsService
    {
        IEnumerable<DailyMeasurements> GetAll();
        DailyMeasurements GetById(string id);
        void Create(DailyMeasurements dailyMeasurements);
        void Update(DailyMeasurements dailyMeasurements);
        void Delete(DailyMeasurements dailyMeasurements);
    }
}
