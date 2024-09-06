using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces;

public interface ICarServices
{
    ValueTask<Car> Create(Car car);
}
