using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class JerkOperators
    {
        [Fact]
        public void OpAddition() {
            var jerk1 = new Jerk(1000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(1, JerkUnit.KiloMetersPerSecondCubed);
            var expected = new Jerk(2000, JerkUnit.MetersPerSecondCubed);
            (jerk1 + jerk2).ShouldEqual(expected);
            (jerk2 + jerk1).ShouldEqual(expected);
        }

        [Fact]
        public void OpDivision() {
            var jerk1 = new Jerk(1000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(1, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 / jerk2).ShouldBeWithinEpsilonOf(1);
            (jerk2 / jerk1).ShouldBeWithinEpsilonOf(1);

            (jerk1 / 2).ShouldEqual(new Jerk(500, JerkUnit.MetersPerSecondCubed));
            (jerk2 / 2).ShouldEqual(new Jerk(.5, JerkUnit.KiloMetersPerSecondCubed));
        }

        [Fact]
        public void OpEquals() {
            var jerk1 = new Jerk(3000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(3, JerkUnit.KiloMetersPerSecondCubed);
            var jerk3 = new Jerk(4, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 == jerk2).ShouldBeTrue();
            (jerk2 == jerk1).ShouldBeTrue();
            (jerk1 == jerk3).ShouldBeFalse();
            (jerk3 == jerk1).ShouldBeFalse();
            jerk1.Equals(jerk2)
                 .ShouldBeTrue();
            jerk1.Equals((object)jerk2)
                 .ShouldBeTrue();
            jerk2.Equals(jerk1)
                 .ShouldBeTrue();
            jerk2.Equals((object)jerk1)
                 .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var jerk1 = new Jerk(3000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(3, JerkUnit.KiloMetersPerSecondCubed);
            var jerk3 = new Jerk(4, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 > jerk3).ShouldBeFalse();
            (jerk3 > jerk1).ShouldBeTrue();
            (jerk1 > jerk2).ShouldBeFalse();
            (jerk2 > jerk1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var jerk1 = new Jerk(3000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(3, JerkUnit.KiloMetersPerSecondCubed);
            var jerk3 = new Jerk(4, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 >= jerk3).ShouldBeFalse();
            (jerk3 >= jerk1).ShouldBeTrue();
            (jerk1 >= jerk2).ShouldBeTrue();
            (jerk2 >= jerk1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var jerk1 = new Jerk(3000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(3, JerkUnit.KiloMetersPerSecondCubed);
            var jerk3 = new Jerk(4, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 != jerk2).ShouldBeFalse();
            (jerk2 != jerk1).ShouldBeFalse();
            (jerk1 != jerk3).ShouldBeTrue();
            (jerk3 != jerk1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var jerk1 = new Jerk(3000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(3, JerkUnit.KiloMetersPerSecondCubed);
            var jerk3 = new Jerk(4, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 < jerk3).ShouldBeTrue();
            (jerk3 < jerk1).ShouldBeFalse();
            (jerk1 < jerk2).ShouldBeFalse();
            (jerk2 < jerk1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var jerk1 = new Jerk(3000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(3, JerkUnit.KiloMetersPerSecondCubed);
            var jerk3 = new Jerk(4, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 <= jerk3).ShouldBeTrue();
            (jerk3 <= jerk1).ShouldBeFalse();
            (jerk1 <= jerk2).ShouldBeTrue();
            (jerk2 <= jerk1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var jerk = new Jerk(1, JerkUnit.KiloMetersPerSecondCubed);
            var expected = new Jerk(2, JerkUnit.KiloMetersPerSecondCubed);
            (jerk * 2).ShouldEqual(expected);
            (2 * jerk).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var jerk1 = new Jerk(2000, JerkUnit.MetersPerSecondCubed);
            var jerk2 = new Jerk(1, JerkUnit.KiloMetersPerSecondCubed);
            (jerk1 - jerk2).ShouldEqual(new Jerk(1000, JerkUnit.MetersPerSecondCubed));
            (jerk2 - jerk1).ShouldEqual(new Jerk(-1, JerkUnit.KiloMetersPerSecondCubed));
        }
    }
}