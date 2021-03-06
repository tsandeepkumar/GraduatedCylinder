using System;

namespace GraduatedCylinder
{
    public class ElectricPotential : Dimension,
                                     IEquatable<ElectricPotential>,
                                     IComparable<ElectricPotential>
    {
        public static readonly ElectricPotential Zero = new ElectricPotential(0, ElectricPotentialUnit.Volt);

        public ElectricPotential(double value, ElectricPotentialUnit units)
            : base(value, units) { }

        public ElectricPotential(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.ElectricPotential);
        }

        internal ElectricPotential(double valueInBaseUnits)
            : base(valueInBaseUnits, ElectricPotentialUnit.BaseUnit) { }

        public int CompareTo(ElectricPotential other) {
            return base.CompareTo(other);
        }

        public bool Equals(ElectricPotential other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(ElectricPotential)) {
                return false;
            }
            return Equals((ElectricPotential)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(ElectricPotentialUnit units) {
            return base.In(units);
        }

        public string ToString(ElectricPotentialUnit units) {
            return base.ToString(units);
        }

        public string ToString(ElectricPotentialUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static ElectricPotential operator +(ElectricPotential voltage1, ElectricPotential voltage2) {
            Guard.NotNull(voltage1, "voltage1");
            Guard.NotNull(voltage2, "voltage2");
            return new ElectricPotential(voltage1.ValueInBaseUnits + voltage2.ValueInBaseUnits) {
                Units = voltage1.Units
            };
        }

        public static ElectricPotential operator /(ElectricPotential electricPotential, double scaler) {
            Guard.NotNull(electricPotential, "electricPotential");
            return new ElectricPotential(electricPotential.ValueInBaseUnits / scaler) {
                Units = electricPotential.Units
            };
        }

        public static ElectricCurrent operator /(ElectricPotential electricPotential, ElectricResistance resistance) {
            Guard.NotNull(electricPotential, "electricPotential");
            Guard.NotNull(resistance, "resistance");
            double electricCurrentValue = electricPotential.In(ElectricPotentialUnit.Volt) / resistance.In(ElectricResistanceUnit.Ohm);
            return new ElectricCurrent(electricCurrentValue, ElectricCurrentUnit.Ampere);
        }

        public static ElectricResistance operator /(ElectricPotential electricPotential, ElectricCurrent current) {
            Guard.NotNull(electricPotential, "electricPotential");
            Guard.NotNull(current, "current");
            double electricResistance = electricPotential.In(ElectricPotentialUnit.Volt) / current.In(ElectricCurrentUnit.Ampere);
            return new ElectricResistance(electricResistance, ElectricResistanceUnit.Ohm);
        }

        public static double operator /(ElectricPotential numerator, ElectricPotential denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(ElectricPotential left, ElectricPotential right) {
            return Equals(left, right);
        }

        public static bool operator >(ElectricPotential left, ElectricPotential right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(ElectricPotential left, ElectricPotential right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(ElectricPotential left, ElectricPotential right) {
            return !Equals(left, right);
        }

        public static bool operator <(ElectricPotential left, ElectricPotential right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(ElectricPotential left, ElectricPotential right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static ElectricPotential operator *(ElectricPotential electricPotential, double scaler) {
            Guard.NotNull(electricPotential, "electricPotential");
            return new ElectricPotential(electricPotential.ValueInBaseUnits * scaler) {
                Units = electricPotential.Units
            };
        }

        public static ElectricPotential operator *(double scaler, ElectricPotential electricPotential) {
            Guard.NotNull(electricPotential, "electricPotential");
            return new ElectricPotential(electricPotential.ValueInBaseUnits * scaler) {
                Units = electricPotential.Units
            };
        }

        public static Power operator *(ElectricPotential electricPotential, ElectricCurrent current) {
            Guard.NotNull(current, "current");
            Guard.NotNull(electricPotential, "electricPotential");
            double powerValue = electricPotential.In(ElectricPotentialUnit.Volt) * current.In(ElectricCurrentUnit.Ampere);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static ElectricPotential operator -(ElectricPotential voltage1, ElectricPotential voltage2) {
            Guard.NotNull(voltage1, "voltage1");
            Guard.NotNull(voltage2, "voltage2");
            return new ElectricPotential(voltage1.ValueInBaseUnits - voltage2.ValueInBaseUnits) {
                Units = voltage1.Units
            };
        }
    }
}