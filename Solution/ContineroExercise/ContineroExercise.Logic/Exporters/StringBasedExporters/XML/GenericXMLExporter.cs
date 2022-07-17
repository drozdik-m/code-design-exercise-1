using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ContineroExercise.Logic.Exporters.StringBasedExporters.XML
{
    public class GenericXMLExporter<TModel> : XMLExporter<TModel>
    {
        /// <inheritdoc/>
        protected override string FromModel(TModel model)
        {
            //source: https://stackoverflow.com/questions/4123590/serialize-an-object-to-xml
            XmlSerializer xmlSerializer = new(typeof(TModel));
            using var sww = new StringWriter();
            var xml = string.Empty;
            using (XmlWriter writer = XmlWriter.Create(sww))
            {
                xmlSerializer.Serialize(writer, model);
                xml = sww.ToString();
            }

            return xml;
        }
    }
}
