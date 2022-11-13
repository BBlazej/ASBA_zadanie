using ABSAConversionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAConversionLib
{
    public abstract class Convertor
    {
        public abstract IConvertor FactoryMethod();
        public Output Convert(Input input)
        {
            var product = FactoryMethod();
            var result = product.Convert(input);

            return result;
        }
    }

    class LengthConvertorCreator : Convertor
    {
        public override IConvertor FactoryMethod()
        {
            return new LengthConvertor();
        }
    }

    class TemperatureConvertorCreator : Convertor
    {
        public override IConvertor FactoryMethod()
        {
            return new TemperatureConvertor();
        }
    }

    class InformationConvertorCreator : Convertor
    {
        public override IConvertor FactoryMethod()
        {
            return new InformationConvertor();
        }
    }
}
