using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents a one dimensional length. SI refers to this as
    ///     position, but we do not want to confuse this with geolocation.
    /// </summary>
    public class Length : Dimension,
                          IEquatable<Length>,
                          IComparable<Length>
    {
        public Length(double value, LengthUnit units)
            : base(value, units) { }

        public Length(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            DimensionType.ShouldBe(DimensionType.Length);
        }

        internal Length(double value)
            : base(value, LengthUnit.BaseUnit) { }

        public int CompareTo(Length other) {
            return base.CompareTo(other);
        }

        public bool Equals(Length other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Length)) {
                return false;
            }
            return Equals((Length)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(LengthUnit units) {
            return base.In(units);
        }

        public string ToString(LengthUnit units) {
            return base.ToString(units);
        }

        public string ToString(LengthUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Length operator +(Length left, Length right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Length(left.ValueInBaseUnits + right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static Length operator /(Length length, double scaler) {
            Guard.NotNull(length, "length");
            return new Length(length.ValueInBaseUnits / scaler) {
                Units = length.Units
            };
        }

        public static Speed operator /(Length length, Time time) {
            Guard.NotNull(length, "length");
            Guard.NotNull(time, "time");
            double speed = length.In(LengthUnit.Meter) / time.In(TimeUnit.Second);
            return new Speed(speed, SpeedUnit.MeterPerSecond);
        }

        public static Time operator /(Length length, Speed speed) {
            Guard.NotNull(speed, "speed");
            Guard.NotNull(length, "length");
            double timeValue = length.In(LengthUnit.Meter) / speed.In(SpeedUnit.MeterPerSecond);
            return new Time(timeValue, TimeUnit.Second);
        }

        public static double operator /(Length numerator, Length denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator >(Length left, Length right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Length left, Length right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(Length left, Length right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Length left, Length right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) <= 0;
        }

        public static Length operator *(Length length, double scaler) {
            Guard.NotNull(length, "length");
            return new Length(length.ValueInBaseUnits * scaler) {
                Units = length.Units
            };
        }

        public static Length operator *(double scaler, Length length) {
            Guard.NotNull(length, "length");
            return new Length(length.ValueInBaseUnits * scaler) {
                Units = length.Units
            };
        }

        public static Area operator *(Length left, Length right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            double area = left.In(LengthUnit.Meter) * right.In(LengthUnit.Meter);
            return new Area(area, AreaUnit.MeterSquared);
        }

        public static Energy operator *(Length length, Force force) {
            Guard.NotNull(length, "length");
            Guard.NotNull(force, "force");
            double energyValue = length.In(LengthUnit.Meter) * force.In(ForceUnit.Newtons);
            return new Energy(energyValue, EnergyUnit.NewtonMeters);
        }

        public static Volume operator *(Length length, Area area) {
            Guard.NotNull(length, "length");
            Guard.NotNull(area, "area");
            double volumeValue = length.In(LengthUnit.Meter) * area.In(AreaUnit.MeterSquared);
            return new Volume(volumeValue, VolumeUnit.CubicMeters);
        }

        public static Length operator -(Length left, Length right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Length(left.ValueInBaseUnits - right.ValueInBaseUnits) {
                Units = left.Units
            };
        }
    }
}