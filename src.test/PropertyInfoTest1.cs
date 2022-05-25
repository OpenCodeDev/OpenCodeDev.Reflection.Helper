namespace OpenCodeDev.Reflection.Helper.Test
{
    public class MyTypeTester
    {
        public bool BoolType { get; set; }
        public string StringType { get; set; }
        public long LongType { get; set; }
        public static double DoubleType { get; set; }
        private static float FloatType { get; set; }
        public short ShortType { get; set; }
        public decimal DecimalType { get; set; }
        public object ObjectType { get; set; }
        public DateTime TimeOfTheYear { get; set; }
    }
    [TestClass]
    public class PropertyInfoTest1
    {
        [TestMethod("PropertyInfo Test Correct Types")]
        public void Test1()
        {
            MyTypeTester myObj = new MyTypeTester();
            var runtimeObj = myObj.GetType();

            Assert.IsTrue(runtimeObj?.GetPropertyPublic("BoolType")?.IsBool());
            Assert.IsTrue(runtimeObj?.GetPropertyPublic("StringType")?.IsString());
            Assert.IsTrue(runtimeObj?.GetPropertyUnrest("LongType")?.IsLong());

            Assert.IsTrue(runtimeObj?.GetPropertyStaticPublic("DoubleType")?.IsDouble());
            Assert.IsTrue(runtimeObj?.GetPropertyStatic("DoubleType")?.IsDouble());

            Assert.IsTrue(runtimeObj?.GetPropertyStaticPrivate("FloatType")?.IsFloat());
            Assert.IsTrue(runtimeObj?.GetPropertyStatic("FloatType")?.IsFloat());

            Assert.IsTrue(runtimeObj?.GetPropertyPublic("ShortType")?.IsShort());
            Assert.IsTrue(runtimeObj?.GetPropertyPublic("DecimalType")?.IsDecimal());
            Assert.IsTrue(runtimeObj?.GetPropertyPublic("ObjectType")?.IsObject());

            Assert.IsTrue(runtimeObj?.GetPropertyPublic("TimeOfTheYear")?.IsDateTime());

        }

        [TestMethod("PropertyInfo Test Mix Types")]
        public void Test2()
        {
            MyTypeTester myObj = new MyTypeTester();
            var runtimeObj = myObj.GetType();

            Assert.IsFalse(runtimeObj?.GetPropertyPublic("BoolType")?.IsInt());
            Assert.IsFalse(runtimeObj?.GetPropertyPublic("StringType")?.IsBool());
            Assert.IsFalse(runtimeObj?.GetPropertyUnrest("LongType")?.Is<Int16>());

            Assert.IsFalse(runtimeObj?.GetPropertyStaticPublic("DoubleType")?.IsFloat());

            Assert.IsFalse(runtimeObj?.GetPropertyStaticPrivate("FloatType")?.IsDecimal());

            Assert.IsFalse(runtimeObj?.GetPropertyPublic("ShortType")?.IsInt());
            Assert.IsFalse(runtimeObj?.GetPropertyPublic("DecimalType")?.IsFloat());
            Assert.IsFalse(runtimeObj?.GetPropertyPublic("ObjectType")?.IsBool());

            Assert.IsFalse(runtimeObj?.GetPropertyPublic("TimeOfTheYear")?.IsDecimal());

        }

        [TestMethod("PropertyInfo Test Struct Types")]
        public void Test3()
        {
            MyTypeTester myObj = new MyTypeTester();
            var runtimeObj = myObj.GetType();

            Assert.IsTrue(runtimeObj?.GetPropertyPublic("BoolType")?.Is<Boolean>());
            Assert.IsTrue(runtimeObj?.GetPropertyPublic("StringType")?.Is<String>());
            Assert.IsTrue(runtimeObj?.GetPropertyUnrest("LongType")?.Is<Int64>());

            Assert.IsTrue(runtimeObj?.GetPropertyStaticPublic("DoubleType")?.Is<Double>());

            Assert.IsTrue(runtimeObj?.GetPropertyStaticPrivate("FloatType")?.Is<Single>());

            Assert.IsTrue(runtimeObj?.GetPropertyPublic("ShortType")?.Is<Int16>());
            Assert.IsTrue(runtimeObj?.GetPropertyPublic("DecimalType")?.Is<Decimal>());
            Assert.IsTrue(runtimeObj?.GetPropertyPublic("ObjectType")?.Is<Object>());
            Assert.IsTrue(runtimeObj?.GetPropertyPublic("TimeOfTheYear")?.Is<DateTime>());
        }
    }
}