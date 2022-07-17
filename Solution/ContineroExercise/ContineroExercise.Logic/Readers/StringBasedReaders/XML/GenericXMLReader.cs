using ContineroExercise.Logic.Sources;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContineroExercise.Logic.Readers.StringBasedReaders.XML
{
    public abstract class GenericXMLReader<TModel> : StringBasedReader<TModel>
    {
        protected override TModel CreateModel(string xmlString)
        {
            XmlSerializer serializer = new(typeof(TModel));
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString));
            TModel? result = (TModel?)serializer.Deserialize(stream);
            if (result is null)
                throw new Exception($"Could not generally transform the XML model");

            return result;
        }
    }
}
