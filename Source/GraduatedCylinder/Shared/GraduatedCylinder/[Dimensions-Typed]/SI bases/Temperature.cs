using System;

namespace GraduatedCylinder
{
    public class Temperature : Dimension,
                               IEquatable<Temperature>,
                               IComparable<Temperature>
    {
        public static readonly Temperature WaterBoilsAt = new Temperature(100, TemperatureUnit.Celsius);

        public static readonly Temperature WaterFreezesAt = new Temperature(0, TemperatureUnit.Celsius);

        public Temperature(double value, TemperatureUnit units)
            : base(value, units) { }

        public Temperature(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Temperature);
        }

        internal Temperature(double valueInBaseUnits)
            : base(valueInBaseUnits, TemperatureUnit.BaseUnit) { }

        public int CompareTo(Temperature other) {
            return base.CompareTo(other);
        }

        public bool Equals(Temperature other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Temperature)) {
                return false;
            }
            return Equals((Temperature)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(TemperatureUnit units) {
            return base.In(units);
        }

        public string ToString(TemperatureUnit units) {
            return base.ToString(units);
        }

        public string ToString(TemperatureUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Temperature operator +(Temperature temperature1, Temperature temperature2) {
            Guard.NotNull(temperature1, "temperature1");
            Guard.NotNull(temperature2, "temperature2");
            return new Temperature(temperature1.ValueInBaseUnits + temperature2.ValueInBaseUnits) {
                Units = temperature1.Units
            };
        }

        public static Temperature operator /(Temperature temperature, double scaler) {
            Guard.NotNull(temperature, "temperature");
            return new Temperature(temperature.ValueInBaseUnits / scaler) {
                Units = temperature.Units
            };
        }

        public static double operator /(Temperature numerator, Temperature denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Temperature left, Temperature right) {
            return Equals(left, right);
        }

        public static bool operator >(Temperature left, Temperature right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Temperature left, Temperature right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Temperature left, Temperature right) {
            return !Equals(left, right);
        }

        public static bool operator <(Temperature left, Temperature right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Temperature left, Temperature right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Temperature operator *(Temperature temperature, double scaler) {
            Guard.NotNull(temperature, "temperature");
            return new Temperature(temperature.ValueInBaseUnits * scaler) {
                Units = temperature.Units
            };
        }

        public static Temperature operator *(double scaler, Temperature temperature) {
            Guard.NotNull(temperature, "temperature");
            return new Temperature(temperature.ValueInBaseUnits * scaler) {
                Units = temperature.Units
            };
        }

        public static Temperature operator -(Temperature temperature1, Temperature temperature2) {
            Guard.NotNull(temperature1, "temperature1");
            Guard.NotNull(temperature2, "temperature2");
            return new Temperature(temperature1.ValueInBaseUnits - temperature2.ValueInBaseUnits) {
                Units = temperature1.Units
            };
        }
    }
}