using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutoAdapter.Tests
{
    public class Convertable
    {
        private AdapterTest Sut;
        private TypeConverter Converter;

        public Convertable()
        {
            Sut = new AdapterTest();
            Converter = TypeDescriptor.GetConverter(typeof(IAdapterTest));
        }

        [Fact]
        public void Converts()
        {
            Assert.False(typeof(IAdapterTest).IsAssignableFrom(Sut.GetType()));
            //Assert.False(Sut.GetType().IsAssignableTo(typeof(IAdapterTest)));
            IAdapterTest iSut = (IAdapterTest)Converter.ConvertFrom(Sut);
            Assert.False(Sut.Called);
            iSut.TestMethod();
            Assert.True(Sut.Called);
        }

        [Fact]
        public void ConvertsThroughStatic()
        {
            Assert.False(typeof(IAdapterTest).IsAssignableFrom(Sut.GetType()));
            //Assert.False(Sut.GetType().IsAssignableTo(typeof(IAdapterTest)));
            var iSut = AdapterConverter<IAdapterTest>.Cast(Sut);
            Assert.False(Sut.Called);
            iSut.TestMethod();
            Assert.True(Sut.Called);
        }
    }
}
