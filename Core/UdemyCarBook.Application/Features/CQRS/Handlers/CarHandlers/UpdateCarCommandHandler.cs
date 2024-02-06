using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarId);
            values.Fuel = command.Fuel;
            values.Transmission = command.Transmission;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Km = command.Km;
            values.Seat = command.Seat;
            values.Model = command.Model;
            values.Luggage = command.Luggage;
            values.BrandId = command.BrandId;
            await _repository.UpdateAsync(values);
        }
    }
}
