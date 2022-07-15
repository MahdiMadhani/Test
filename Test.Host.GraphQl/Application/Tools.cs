using System;
using System.Collections.Generic;

namespace Application
{
    public static class Tools
    {
        public static string NumberCounter(this long number)
        {
            number++;
            return number switch
            {
                < 10 => $"000{number}",
                < 100 => $"00{number}",
                < 1000 => $"0{number}",
                _ => $"{number}"
            };
        }

        public static string NumberCounter(this int number)
        {
            number++;
            return number switch
            {
                < 10 => $"000{number}",
                < 100 => $"00{number}",
                < 1000 => $"0{number}",
                _ => $"{number}"
            };
        }

        public static decimal FixDecimal(this decimal value)
        {
            var result = decimal.Round(value, 4, MidpointRounding.AwayFromZero);
            return result;
        }
    }
    public class GuidComparer : IEqualityComparer<Guid>
    {
        public static readonly GuidComparer Instance = new();
        
        public bool Equals(Guid x, Guid y)
        {
            return x == y;
        }

        public int GetHashCode(Guid obj)
        {
            return obj.GetHashCode();
        }
    }
    public class NullableGuidComparer : IEqualityComparer<Guid?>
    {
        public static readonly NullableGuidComparer Instance = new();

        public bool Equals(Guid? x, Guid? y)
        {
            return x == y;
        }

        public int GetHashCode(Guid? obj)
        {
            return obj.GetHashCode();
        }
    }
}
