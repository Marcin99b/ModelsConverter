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
        public void Convert_ShouldConvertBasicPropertiesToModel(Type type, string expectedTypeName)
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
        public void Render_ShouldRenderBasicModel()
        {
            //Arrange
            var converter = new TypescriptConverter();
            var name = "TestClass";
            var convertedProperties = new[] { new ConvertedProperty("string", "test") };
            var model = new ConvertedModel(name, null, convertedProperties);

            //Act
            var result = converter.Render(model);

            //Assert
            result.Should().Be(
@"export class TestClass {
  test: string;
}");
        }
    }
}
