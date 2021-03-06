﻿using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GPVTG_Sentence
    {
        public static Decoded Parse(Sentence sentence) {
            // $GPVTG,<1>,T,<3>,M,<5>,N,<7>,K*<CS><CR><LF>
            // 0) Sentence Id
            // 1) True course over ground, 000 to 359 degrees.
            // 2) T for true course
            // 3) Magnetic course over ground, 000 to 359 degrees.
            // 4) M for magnetic course
            // 5) horizontal speed over ground, 00.0 to 999.9 knots.
            // 6) N for knots
            // 7) Speed over ground, 00.0 to 1851.8 ko/hr.
            // 8) K for km/p
            // *<CS>) Checksum.
            // <CR><LF>) Sentence terminator

            if (sentence.Id != "$GPVTG") {
                return null;
            }
            if (sentence.Parts.Length != 9) {
                return null;
            }

            double trueCourse;
            double.TryParse(sentence.Parts[1], out trueCourse);

            double magneticCourse;
            double.TryParse(sentence.Parts[3], out magneticCourse);

            double speedInKnots;
            double.TryParse(sentence.Parts[5], out speedInKnots);

            return new Decoded(trueCourse, magneticCourse, new Speed(speedInKnots, SpeedUnit.NauticalMilesPerHour));
        }

        public class Decoded
        {
            public Decoded(Heading trueCourse, Heading magneticCourse, Speed speed) {
                TrueCourse = trueCourse;
                MagneticCourse = magneticCourse;
                Speed = speed;
            }

            public Heading MagneticCourse { get; private set; }

            public Speed Speed { get; private set; }

            public Heading TrueCourse { get; private set; }
        }
    }
}