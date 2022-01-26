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
        [TestCase(typeof(IntClass), "number")]
        [TestCase(typeof(ShortClass), "number")]
        [TestCase(typeof(FloatClass), "number")]
        [TestCase(typeof(BoolClass), "boolean")]
        [TestCase(typeof(StringClassInClass), "StringClass")]
        [TestCase(typeof(BoolClassInClass), "BoolClass")]
        public void Convert_ShouldConvertPropertiesToModel(Type type, string expectedTypeName)
        {
            //Arrange
            var converter = new TypescriptConverter();

            //Act
            var model = converter.Convert(type);

            //Assert
            model.Properties.Should().HaveCount(1);
            model.Properties.Single().TypeName.Should().BeEquivalentTo(expectedTypeName);
            model.Properties.Single().Name.Should().Be("A");
        }

        [Test]
        [TestCase("string", "test", "test: string;")]
        [TestCase("number", "AA", "AA: number;")]
        public void Render_ShouldRenderBasicModel(string typeName, string propertyName, string excepted)
        {
            //Arrange
            var converter = new TypescriptConverter();
            var name = "TestClass";
            var convertedProperties = new[] { new ConvertedProperty(typeName, propertyName) };
            var model = new ConvertedModel(name, null, convertedProperties);

            //Act
            var result = converter.Render(model);

            //Assert
            result.Should().Be(
$@"export class TestClass {{
  {excepted}
}}");
        }
    }
}
