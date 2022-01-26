using FluentAssertions;
using ModelsConverter.Core.Converters;
using ModelsConverter.Core.Converters.Typescript;
using ModelsConverter.Core.Tests.TestModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsConverter.Core.Tests.Converters
{
    [TestFixture]
    public class TypescriptConverterTests
    {
        [Test]
        [TestCase(typeof(StringClass), "string")]
        [TestCase(typeof(LongClass), "number")]
        [TestCase(typeof(UlongClass), "number")]
        [TestCase(typeof(IntClass), "number")]
        [TestCase(typeof(UintClass), "number")]
        [TestCase(typeof(ShortClass), "number")]
        [TestCase(typeof(UshortClass), "number")]
        [TestCase(typeof(FloatClass), "number")]
        [TestCase(typeof(DoubleClass), "number")]
        [TestCase(typeof(DecimalClass), "number")]
        [TestCase(typeof(BoolClass), "boolean")]
        [TestCase(typeof(StringClassInClass), "StringClass")]
        [TestCase(typeof(BoolClassInClass), "BoolClass")]
        public void Convert_ShouldConvertPropertiesToModel(Type type, string expectedTypeName)
        {
            //Arrange
            var converter = new TypescriptConverter();
            var configuration = new TypescriptConfiguration();

            //Act
            var model = converter.Convert(type, configuration);

            //Assert
            model.Properties.Should().HaveCount(1);
            model.Properties.Single().TypeName.Should().BeEquivalentTo(expectedTypeName);
            model.Properties.Single().PropertyName.Should().Be("A");
        }

        [Test]
        [TestCase("string", "test", "test: string;")]
        [TestCase("number", "AA", "AA: number;")]
        public void Render_ShouldRenderBasicModel(string typeName, string propertyName, string excepted)
        {
            //Arrange
            var converter = new TypescriptConverter();
            var name = "TestClass";
            var convertedProperties = new[] { new TypescriptProperty(typeName, propertyName) };
            var model = new TypescriptModel(name, null, convertedProperties);
            var config = new TypescriptConfiguration { SpacesBeforeProperties = 2 };

            //Act
            var result = model.Render(config);

            //Assert
            result.Should().Be(
$@"export class TestClass {{
  {excepted}
}}".Trim(" \r\n".ToCharArray()));
        }
    }
}
