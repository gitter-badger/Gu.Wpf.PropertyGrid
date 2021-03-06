﻿namespace Gu.Wpf.PropertyGrid.UnitRows.Tests
{
    using System.Threading;

    using Gu.Units;

    using NUnit.Framework;

    [Apartment(ApartmentState.STA)]
    public class LengthRowTests
    {
        [Test]
        public void IsDirty()
        {
            var control = new LengthRow();
            Assert.Null(control.IsDirty);

            control.Value = Length.FromMillimetres(1);
            Assert.Null(control.IsDirty);

            control.OldValue = Length.FromMillimetres(2);
            Assert.True(control.IsDirty);

            control.OldValue = Length.FromMillimetres(1);
            Assert.False(control.IsDirty);

            control.Value = Length.FromMillimetres(3);
            Assert.True(control.IsDirty);

            control.OldValue = Length.FromMillimetres(3);
            Assert.False(control.IsDirty);
        }

        [Test]
        public void UnitUpdatesSuffix()
        {
            var control = new LengthRow();
            Assert.AreEqual("m", control.Suffix);
            control.Unit = LengthUnit.Centimetres;
            Assert.AreEqual("cm", control.Suffix);
        }

        [Test]
        public void UnitUpdatesValueWhenMaxAndMinAreNull()
        {
            var control = new LengthRow { Value = Length.FromCentimetres(1.2) };
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(Length.FromMillimetres(12), control.Value);
            Assert.AreEqual(0.012, control.ScalarValue);
            Assert.AreEqual(null, control.ScalarMinValue);
            Assert.AreEqual(null, control.ScalarMaxValue);

            control.Unit = LengthUnit.Centimetres;
            Assert.AreEqual("cm", control.Suffix);
            Assert.AreEqual(Length.FromMillimetres(12), control.Value);
            Assert.AreEqual(1.2, control.ScalarValue);
            Assert.AreEqual(null, control.ScalarMinValue);
            Assert.AreEqual(null, control.ScalarMaxValue);
        }

        [Test]
        public void UnitUpdatesValueWhenMaxAndMinHaveValues()
        {
            var control = new LengthRow
            {
                Value = Length.FromCentimetres(1.2),
                MinValue = Length.FromCentimetres(-5),
                MaxValue = Length.FromCentimetres(5),
            };
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(Length.FromMillimetres(12), control.Value);
            Assert.AreEqual(0.012, control.ScalarValue);
            Assert.AreEqual(-0.050, control.ScalarMinValue);
            Assert.AreEqual(0.050, control.ScalarMaxValue);

            control.Unit = LengthUnit.Centimetres;
            Assert.AreEqual("cm", control.Suffix);
            Assert.AreEqual(Length.FromCentimetres(1.2), control.Value);
            Assert.AreEqual(Length.FromCentimetres(-5), control.MinValue);
            Assert.AreEqual(Length.FromCentimetres(5), control.MaxValue);
            Assert.AreEqual(1.2, control.ScalarValue);
            Assert.AreEqual(-5, control.ScalarMinValue);
            Assert.AreEqual(5, control.ScalarMaxValue);
        }

        [Test]
        public void ChangeScalarValuesUpdatesQuantityValues()
        {
            var control = new LengthRow
            {
                Value = Length.FromCentimetres(1.2),
                MinValue = Length.FromCentimetres(-5),
                MaxValue = Length.FromCentimetres(5),
            };
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(Length.FromMillimetres(12), control.Value);
            Assert.AreEqual(0.012, control.ScalarValue);
            Assert.AreEqual(-0.050, control.ScalarMinValue);
            Assert.AreEqual(0.050, control.ScalarMaxValue);

            control.ScalarValue = 0.8;
            control.ScalarMinValue = -1.2;
            control.ScalarMaxValue = 2.3;
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(Length.FromMetres(0.8), control.Value);
            Assert.AreEqual(Length.FromMetres(-1.2), control.MinValue);
            Assert.AreEqual(Length.FromMetres(2.3), control.MaxValue);
            Assert.AreEqual(0.8, control.ScalarValue);
            Assert.AreEqual(-1.2, control.ScalarMinValue);
            Assert.AreEqual(2.3, control.ScalarMaxValue);

            control.ScalarValue = null;
            control.ScalarMinValue = null;
            control.ScalarMaxValue = null;
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(null, control.Value);
            Assert.AreEqual(null, control.MinValue);
            Assert.AreEqual(null, control.MaxValue);
            Assert.AreEqual(null, control.ScalarValue);
            Assert.AreEqual(null, control.ScalarMinValue);
            Assert.AreEqual(null, control.ScalarMaxValue);
        }

        [Test]
        public void ChangeQuantityValuesUpdatesScalarValues()
        {
            var control = new LengthRow
            {
                Value = Length.FromCentimetres(1.2),
                MinValue = Length.FromCentimetres(-5),
                MaxValue = Length.FromCentimetres(5),
            };
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(Length.FromMillimetres(12), control.Value);
            Assert.AreEqual(Length.FromMillimetres(-50), control.MinValue);
            Assert.AreEqual(Length.FromMillimetres(50), control.MaxValue);
            Assert.AreEqual(0.012, control.ScalarValue);
            Assert.AreEqual(-0.05, control.ScalarMinValue);
            Assert.AreEqual(0.05, control.ScalarMaxValue);

            control.Value = Length.FromMillimetres(0.8);
            control.MinValue = Length.FromMillimetres(-1.2);
            control.MaxValue = Length.FromMillimetres(2.3);
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(Length.FromMillimetres(0.8), control.Value);
            Assert.AreEqual(Length.FromMillimetres(-1.2), control.MinValue);
            Assert.AreEqual(Length.FromMillimetres(2.3), control.MaxValue);
            Assert.AreEqual(0.0008, control.ScalarValue);
            Assert.AreEqual(-0.0012, control.ScalarMinValue);
            Assert.AreEqual(0.0023, control.ScalarMaxValue);

            control.Value = null;
            control.MinValue = null;
            control.MaxValue = null;
            Assert.AreEqual("m", control.Suffix);
            Assert.AreEqual(null, control.Value);
            Assert.AreEqual(null, control.MinValue);
            Assert.AreEqual(null, control.MaxValue);
            Assert.AreEqual(null, control.ScalarValue);
            Assert.AreEqual(null, control.ScalarMinValue);
            Assert.AreEqual(null, control.ScalarMaxValue);
        }
    }
}
