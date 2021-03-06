using System;
using System.Collections.Generic;

namespace GraduatedCylinder
{
    public class UnitPreferences
    {
        private static readonly Dictionary<string, Func<UnitPreferences>> CultureUnitGenerators;
        private readonly SafeDictionary<DimensionType, UnitOfMeasure> _unitPreferences = new SafeDictionary<DimensionType, UnitOfMeasure>();

        static UnitPreferences() {
            CultureUnitGenerators = new Dictionary<string, Func<UnitPreferences>> {
                {
                    "es", () => GetMetricUnits()
                }, {
                    "es-mx", () => GetMetricUnits()
                }, {
                    "en", () => GetAmericanEnglishUnits()
                }, {
                    "en-gb", () => GetBritishEnglishUnits()
                }, {
                    "en-us", () => GetAmericanEnglishUnits()
                }, {
                    "fr", () => GetMetricUnits()
                }, {
                    "fr-ca", () => GetMetricUnits()
                }
            };
        }

        public UnitPreferences() {
            _unitPreferences.Add(DimensionType.Acceleration, AccelerationUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Angle, AngleUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.AngularAcceleration, AngularAccelerationUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Area, AreaUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.ElectricCurrent, ElectricCurrentUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.ElectricPotential, ElectricPotentialUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.ElectricResistance, ElectricResistanceUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Energy, EnergyUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Force, ForceUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Frequency, FrequencyUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Jerk, JerkUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Length, LengthUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.MassFlowRate, MassFlowRateUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Mass, MassUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.MassDensity, MassDensityUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Momentum, MomentumUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Numeric, NumericUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Power, PowerUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Pressure, PressureUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Speed, SpeedUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Temperature, TemperatureUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Time, TimeUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Torque, TorqueUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.Volume, VolumeUnit.BaseUnit);
            _unitPreferences.Add(DimensionType.VolumetricFlowRate, VolumetricFlowRateUnit.BaseUnit);
        }

        public UnitOfMeasure this[DimensionType dimensionType] {
            get { return _unitPreferences[dimensionType]; }
        }

        public UnitOfMeasure AccelerationUnits {
            get { return _unitPreferences[DimensionType.Acceleration]; }
            set { _unitPreferences[DimensionType.Acceleration] = value; }
        }

        public UnitOfMeasure AngleUnits {
            get { return _unitPreferences[DimensionType.Angle]; }
            set { _unitPreferences[DimensionType.Angle] = value; }
        }

        public UnitOfMeasure AngularAccelerationUnits {
            get { return _unitPreferences[DimensionType.AngularAcceleration]; }
            set { _unitPreferences[DimensionType.AngularAcceleration] = value; }
        }

        public UnitOfMeasure AreaUnits {
            get { return _unitPreferences[DimensionType.Area]; }
            set { _unitPreferences[DimensionType.Area] = value; }
        }

        public UnitOfMeasure CurrentUnits {
            get { return _unitPreferences[DimensionType.ElectricCurrent]; }
            set { _unitPreferences[DimensionType.ElectricCurrent] = value; }
        }

        public UnitOfMeasure ElectricPotentialUnits {
            get { return _unitPreferences[DimensionType.ElectricPotential]; }
            set { _unitPreferences[DimensionType.ElectricPotential] = value; }
        }

        public UnitOfMeasure ElectricResistanceUnits {
            get { return _unitPreferences[DimensionType.ElectricResistance]; }
            set { _unitPreferences[DimensionType.ElectricResistance] = value; }
        }

        public UnitOfMeasure EnergyUnits {
            get { return _unitPreferences[DimensionType.Energy]; }
            set { _unitPreferences[DimensionType.Energy] = value; }
        }

        public UnitOfMeasure ForceUnits {
            get { return _unitPreferences[DimensionType.Force]; }
            set { _unitPreferences[DimensionType.Force] = value; }
        }

        public UnitOfMeasure FrequencyUnits {
            get { return _unitPreferences[DimensionType.Frequency]; }
            set { _unitPreferences[DimensionType.Frequency] = value; }
        }

        public UnitOfMeasure JerkUnits {
            get { return _unitPreferences[DimensionType.Jerk]; }
            set { _unitPreferences[DimensionType.Jerk] = value; }
        }

        public UnitOfMeasure LengthUnits {
            get { return _unitPreferences[DimensionType.Length]; }
            set { _unitPreferences[DimensionType.Length] = value; }
        }

        public UnitOfMeasure MassDensityUnits {
            get { return _unitPreferences[DimensionType.MassDensity]; }
            set { _unitPreferences[DimensionType.MassDensity] = value; }
        }

        public UnitOfMeasure MassFlowRateUnits {
            get { return _unitPreferences[DimensionType.MassFlowRate]; }
            set { _unitPreferences[DimensionType.MassFlowRate] = value; }
        }

        public UnitOfMeasure MassUnits {
            get { return _unitPreferences[DimensionType.Mass]; }
            set { _unitPreferences[DimensionType.Mass] = value; }
        }

        public UnitOfMeasure MomentumUnits {
            get { return _unitPreferences[DimensionType.Momentum]; }
            set { _unitPreferences[DimensionType.Momentum] = value; }
        }

        public UnitOfMeasure NumericUnits {
            get { return _unitPreferences[DimensionType.Numeric]; }
            set { _unitPreferences[DimensionType.Numeric] = value; }
        }

        public UnitOfMeasure PowerUnits {
            get { return _unitPreferences[DimensionType.Power]; }
            set { _unitPreferences[DimensionType.Power] = value; }
        }

        public UnitOfMeasure PressureUnits {
            get { return _unitPreferences[DimensionType.Pressure]; }
            set { _unitPreferences[DimensionType.Pressure] = value; }
        }

        public UnitOfMeasure SpeedUnits {
            get { return _unitPreferences[DimensionType.Speed]; }
            set { _unitPreferences[DimensionType.Speed] = value; }
        }

        public UnitOfMeasure TemperatureUnits {
            get { return _unitPreferences[DimensionType.Temperature]; }
            set { _unitPreferences[DimensionType.Temperature] = value; }
        }

        public UnitOfMeasure TimeUnits {
            get { return _unitPreferences[DimensionType.Time]; }
            set { _unitPreferences[DimensionType.Time] = value; }
        }

        public UnitOfMeasure TorqueUnits {
            get { return _unitPreferences[DimensionType.Torque]; }
            set { _unitPreferences[DimensionType.Torque] = value; }
        }

        public UnitOfMeasure VolumetricFlowRateUnits {
            get { return _unitPreferences[DimensionType.VolumetricFlowRate]; }
            set { _unitPreferences[DimensionType.VolumetricFlowRate] = value; }
        }

        public UnitOfMeasure VolumeUnits {
            get { return _unitPreferences[DimensionType.Volume]; }
            set { _unitPreferences[DimensionType.Volume] = value; }
        }

        public void Fix(ISupportUnitOfMeasure dimension) {
            dimension.Units = _unitPreferences[dimension.Units.DimensionType];
        }

        public static UnitPreferences GetAmericanEnglishUnits() {
            return new UnitPreferences {
                AccelerationUnits = AccelerationUnit.MilePerHourPerSecond,
                AngleUnits = AngleUnit.Degree,
                AreaUnits = AreaUnit.SquareMiles,
                EnergyUnits = EnergyUnit.KiloCalories,
                ForceUnits = ForceUnit.PoundForce,
                JerkUnits = JerkUnit.MilesPerSecondCubed,
                LengthUnits = LengthUnit.Mile,
                MassUnits = MassUnit.Pounds,
                MassDensityUnits = MassDensityUnit.PoundsPerCubicFeet,
                MassFlowRateUnits = MassFlowRateUnit.PoundsPerSecond,
                MomentumUnits = MomentumUnit.PoundsMilesPerHour,
                PowerUnits = PowerUnit.Horsepower,
                PressureUnits = PressureUnit.PoundsPerSquareInch,
                SpeedUnits = SpeedUnit.MilesPerHour,
                TemperatureUnits = TemperatureUnit.Fahrenheit,
                TimeUnits = TimeUnit.Hours,
                TorqueUnits = TorqueUnit.FootPounds,
                VolumeUnits = VolumeUnit.GallonsUSLiquid,
                VolumetricFlowRateUnits = VolumetricFlowRateUnit.GallonsUsPerHour
            };
        }

        public static UnitPreferences GetBritishEnglishUnits() {
            return new UnitPreferences {
                AccelerationUnits = AccelerationUnit.MilePerHourPerSecond,
                AngleUnits = AngleUnit.Degree,
                AreaUnits = AreaUnit.SquareMiles,
                EnergyUnits = EnergyUnit.KiloCalories,
                ForceUnits = ForceUnit.PoundForce,
                JerkUnits = JerkUnit.MilesPerSecondCubed,
                LengthUnits = LengthUnit.Mile,
                MassUnits = MassUnit.Pounds,
                MassDensityUnits = MassDensityUnit.PoundsPerCubicFeet,
                MassFlowRateUnits = MassFlowRateUnit.PoundsPerSecond,
                MomentumUnits = MomentumUnit.PoundsMilesPerHour,
                PowerUnits = PowerUnit.Horsepower,
                PressureUnits = PressureUnit.PoundsPerSquareInch,
                SpeedUnits = SpeedUnit.MilesPerHour,
                TemperatureUnits = TemperatureUnit.Fahrenheit,
                TorqueUnits = TorqueUnit.FootPounds,
                VolumeUnits = VolumeUnit.GallonsUK,
                VolumetricFlowRateUnits = VolumetricFlowRateUnit.GallonsUsPerSecond
            };
        }

        public static UnitPreferences GetCultureUnits(string cultureCode) {
            cultureCode = cultureCode.ToLowerInvariant();
            return CultureUnitGenerators.ContainsKey(cultureCode) ? CultureUnitGenerators[cultureCode]() : GetMetricUnits();
        }

        public static UnitPreferences GetMetricUnits() {
            return new UnitPreferences {
                AccelerationUnits = AccelerationUnit.KilometerPerHourPerSecond,
                AreaUnits = AreaUnit.KilometerSquared,
                EnergyUnits = EnergyUnit.NewtonMeters,
                JerkUnits = JerkUnit.KiloMetersPerSecondCubed,
                LengthUnits = LengthUnit.Kilometer,
                PowerUnits = PowerUnit.Kilowatts,
                SpeedUnits = SpeedUnit.KilometersPerHour,
                VolumeUnits = VolumeUnit.Liters
            };
        }
    }
}