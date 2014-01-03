﻿using System;
using System.Diagnostics;
using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GPRMC_Sentence
    {
        public static Decoded Parse(Sentence sentence) {
            // $GPRMC,<1>,<2>,<3>,<4>,<5>,<6>,<7>,<8>,<9>,<10>,<11>*<CS><CR><LF>
            // 0)  Sentence Id
            // 1)  UTC time of position fix, hhmmss.sss format.
            // 2)  Status, A = data valid, V = data not valid.
            // 3)  Latitude, ddmm.mmmm format.
            // 4)  Latitude hemisphere, N or S.
            // 5)  Longitude, dddmmm.mmmm format.
            // 6)  Longitude hemisphere, E or W.
            // 7)  Speed over ground, 0.0 to 1851.8 knots.
            // 8)  Course over ground, 000.0 to 359.9 degrees, true.
            // 9)  UTC Date, ddmmyy format.
            // 10) Magnetic variation, 000.0 to 180.O degrees
            // 11) Magnetic variation, E = East, W = West
            // *<CS>) Checksum.
            // <CR><LF>) Sentence terminator

            if (sentence.Id != "$GPRMC") {
                return null;
            }
            if (sentence.Parts.Length != 12) {
                Debug.Assert(sentence.Parts.Length != 13, "Need to support NMEA 2.3");
                return null;
            }
            if (sentence.Parts[2] != "A") {
                return null;
            }

            DateTime fixTime = SentenceHelper.ParseUtcDate(sentence.Parts[9]) + SentenceHelper.ParseUtcTime(sentence.Parts[1]);
            Latitude latitude = SentenceHelper.ParseLatitude(sentence.Parts[3], sentence.Parts[4]);
            Longitude longitude = SentenceHelper.ParseLongitude(sentence.Parts[5], sentence.Parts[6]);

            double speed,
                   heading;
            double.TryParse(sentence.Parts[7], out speed);
            double.TryParse(sentence.Parts[8], out heading);

            //todo: magnetic variation

            return new Decoded(new GeoPosition(latitude, longitude), fixTime, heading, new Speed(speed, SpeedUnit.NauticalMilesPerHour));
        }

        public class Decoded : IProvideGeoPosition,
                               IProvideTime,
                               IProvideTrajectory
        {
            public Decoded(GeoPosition currentLocation, DateTime currentTime, Heading currentHeading, Speed currentSpeed) {
                CurrentLocation = currentLocation;
                CurrentTime = currentTime;
                CurrentHeading = currentHeading;
                CurrentSpeed = currentSpeed;
            }

            public Heading CurrentHeading { get; private set; }

            public GeoPosition CurrentLocation { get; private set; }

            public Speed CurrentSpeed { get; private set; }

            public DateTime CurrentTime { get; private set; }
        }
    }
}