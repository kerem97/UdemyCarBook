using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.StatisticsRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }
        public string BlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }
        public string BrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }
        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgDailyCarPriceAmount()
        {
            int id = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgMonthlyCarPriceAmount()
        {
            int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgWeeklyCarPriceAmount()
        {
            int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            throw new NotImplementedException();
        }
        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountBySmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
