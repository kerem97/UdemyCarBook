﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(u => u.PricingId == 2).ToList();
            return values;
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }
        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([1],[2],[3])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                    {
                        reader.IsDBNull(reader.GetOrdinal("1")) ? 0 : Convert.ToDecimal(reader["1"]),
                        reader.IsDBNull(reader.GetOrdinal("2")) ? 0 : Convert.ToDecimal(reader["2"]),
                        reader.IsDBNull(reader.GetOrdinal("3")) ? 0 : Convert.ToDecimal(reader["3"])
                    }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
        //public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        //{
        //    List<CarPricingViewModel> values = new List<CarPricingViewModel>();
        //    using (var command = _context.Database.GetDbConnection().CreateCommand())
        //    {
        //        command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
        //        command.CommandType = System.Data.CommandType.Text;
        //        _context.Database.OpenConnection();
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
        //                {
        //                    Brand = reader["Name"].ToString(),
        //                    Model = reader["Model"].ToString(),
        //                    CoverImageUrl = reader["CoverImageUrl"].ToString(),
        //                    Amounts = new List<decimal>
        //                    {
        //                        Convert.ToDecimal(reader["2"]),
        //                        Convert.ToDecimal(reader["3"]),
        //                        Convert.ToDecimal(reader["4"])
        //                    }
        //                };
        //                values.Add(carPricingViewModel);
        //            }
        //        }
        //        _context.Database.CloseConnection();
        //        return values;
        //    }
        //}
    }
}