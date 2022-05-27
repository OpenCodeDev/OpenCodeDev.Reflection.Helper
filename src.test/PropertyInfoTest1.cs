using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OpenCodeDev.Reflection.Helper.Test
{
    public class MyObjTester
    {

    }

    public class MyTypeTester
    {
        public bool BoolType { get; set; }

        [EmailAddress]
        public string StringType { get; set; }

        public long LongType { get; set; }
        public static double DoubleType { get; set; }
        private static float FloatType { get; set; }
        public short ShortType { get; set; }
        public decimal DecimalType { get; set; }
        public object ObjectType { get; set; }
        public DateTime TimeOfTheYear { get; set; }
        public Object BigObject { get; set; } = null;
        public String BigString { get; set; } 

        public MyObjTester SubObj { get; set; }

        public List<object> MyListObjects { get; set; } = new List<object>();
        public List<string> MyListString { get; set; } = new List<string>();
        public List<String> MyListBigString { get; set; } = new List<String>();
    }
    [TestClass]
    public class PropertyInfoTest1
    {
        Type myObj = typeof(MyTypeTester);

        [TestMethod("PropertyInfo::IsList()")]
        public void IsListTests()
        {
            PropertyInfo? bList = myObj?.GetPropertyPublic("MyListBigString");
            PropertyInfo? bList2 = myObj?.GetPropertyPublic("MyListString");
            // Pos Test
            Assert.IsTrue(bList?.IsList());
            Assert.IsTrue(bList2?.IsList(true));
        }

        [TestMethod("PropertyInfo::IsObject() [Generic:object]")]
        public void IsGenericObjectTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("ObjectType")?.IsObject());
            Assert.IsTrue(myObj?.GetPropertyPublic("ObjectType")?.IsObject(true));
            Assert.IsTrue(myObj?.GetPropertyPublic("ObjectType")?.Is<Object>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("ObjectType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("ObjectType")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("ObjectType")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("ObjectType")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyPublic("ObjectType")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyPublic("ObjectType")?.IsShort());
            Assert.IsFalse(myObj?.GetPropertyPublic("ObjectType")?.IsString());
        }

        [TestMethod("PropertyInfo::IsObject() [Generic:Object]")]
        public void IsObjectTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("BigObject")?.IsObject());
            Assert.IsTrue(myObj?.GetPropertyPublic("BigObject")?.IsObject(true));
            Assert.IsTrue(myObj?.GetPropertyPublic("BigObject")?.Is<object>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("BigObject")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigObject")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigObject")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigObject")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigObject")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigObject")?.IsShort());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigObject")?.IsString());
        }

        [TestMethod("PropertyInfo::IsObject() [Generic:Class]")]
        public void IsClassObjectTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("SubObj")?.IsObject());
            Assert.IsTrue(myObj?.GetPropertyPublic("SubObj")?.IsObject(true));
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.Is<object>());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.Is<Object>());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.IsShort());
            Assert.IsFalse(myObj?.GetPropertyPublic("SubObj")?.IsString());
        }

        [TestMethod("PropertyInfo::IsObject() [Generic:String]")]
        public void IsStringObjectTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("BigString")?.IsObject());

            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.Is<object>());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.Is<Object>());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyPublic("BigString")?.IsShort());
        }

        [TestMethod("PropertyInfo::IsString()")]
        public void IsStringTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("StringType")?.IsObject());
            Assert.IsTrue(myObj?.GetPropertyPublic("StringType")?.IsString());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.Is<object>());
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.Is<Object>());
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyPublic("StringType")?.IsShort());
        }

        [TestMethod("PropertyInfo::IsDecimal()")]
        public void IsDecimalTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("DecimalType")?.IsDecimal());
            Assert.IsTrue(myObj?.GetPropertyPublic("DecimalType")?.Is<decimal>());
            Assert.IsTrue(myObj?.GetPropertyPublic("DecimalType")?.Is<Decimal>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsShort());
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsObject());
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyPublic("DecimalType")?.IsArray());
        }

        [TestMethod("PropertyInfo::IsShort()")]
        public void IsShortTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("ShortType")?.IsShort());
            Assert.IsTrue(myObj?.GetPropertyPublic("ShortType")?.Is<short>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsObject());
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyPublic("ShortType")?.IsArray());
        }


        [TestMethod("PropertyInfo::IsBool()")]
        public void IsBoolTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("BoolType")?.IsBool());
            Assert.IsTrue(myObj?.GetPropertyPublic("BoolType")?.Is<Boolean>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("BoolType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("BoolType")?.IsObject());
            Assert.IsFalse(myObj?.GetPropertyPublic("BoolType")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyPublic("BoolType")?.IsArray());
        }

        [TestMethod("PropertyInfo::IsLong()")]
        public void IsLongTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyPublic("LongType")?.IsLong());
            Assert.IsTrue(myObj?.GetPropertyPublic("LongType")?.Is<long>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsShort());
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsObject());
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyPublic("LongType")?.IsArray());
        }

        [TestMethod("PropertyInfo::IsFloat()")]
        public void IsFloatTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyStatic("FloatType")?.IsFloat());
            Assert.IsTrue(myObj?.GetPropertyStatic("FloatType")?.Is<float>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsShort());
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsDouble());
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsObject());
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyStatic("FloatType")?.IsArray());
        }

        [TestMethod("PropertyInfo::IsDouble()")]
        public void IsDoubleTests()
        {
            // Pos Test
            Assert.IsTrue(myObj?.GetPropertyStaticPublic("DoubleType")?.IsDouble());
            Assert.IsTrue(myObj?.GetPropertyStaticPublic("DoubleType")?.Is<Double>());
            Assert.IsTrue(myObj?.GetPropertyStaticPublic("DoubleType")?.Is<double>());
            // Negative Test
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsInt());
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsShort());
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsFloat());
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsLong());
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsDecimal());
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsObject());
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsObject(true));
            Assert.IsFalse(myObj?.GetPropertyStaticPublic("DoubleType")?.IsArray());
        }



        [TestMethod("PropertyInfo::HasAttribute<>()")]
        public void HasAttributeTests()
        {
            PropertyInfo? prop = myObj?.GetPropertyPublic("StringType");
            Assert.IsTrue(prop?.HasAttribute<EmailAddressAttribute>());
        }
    }


    
}