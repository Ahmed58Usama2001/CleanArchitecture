using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Services;

public class CarServices : ICarServices
{
    private readonly IRepository<Car> _repository;

    public CarServices(IRepository<Car> repository)
    {
        _repository = repository;
    }
    public async ValueTask<Car> Create(Car car)
    {
        return await _repository.AddAsync(car);
    }
}
