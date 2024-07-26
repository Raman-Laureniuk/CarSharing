namespace CarSharing.Domain.Mappers.Car.Request
{
    using System;
    using System.Linq.Expressions;
    using CarSharing.Domain.Entities;

    internal static class CarOrderByMapper
    {
        public static Expression<Func<Car, object>> ToSortKeySelector(this string key)
        {
            return key switch
            {
                nameof(Car.CarId) =>                x => x.CarId,
                nameof(Car.Model) =>                x => x.Model,
                nameof(Car.Year) =>                 x => x.Year,
                nameof(Car.Color) =>                x => x.Color,
                nameof(Car.PlateNumber) =>          x => x.PlateNumber,
                nameof(Car.Tariff.PricePerHour) =>  x => x.Tariff.PricePerHour,
                
                _ =>                                throw new ArgumentOutOfRangeException(nameof(key))
            };
        }
    }
}
