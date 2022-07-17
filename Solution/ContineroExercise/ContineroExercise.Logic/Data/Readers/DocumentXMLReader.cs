using ContineroExercise.Logic.Readers.StringBasedReaders.JSON;
using ContineroExercise.Logic.Readers.StringBasedReaders.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContineroExercise.Logic.Data.Readers
{
    public class DocumentXMLReader : XMLReader<Document>
    {
        protected override Document CreateModel(string data)
        {
            var xdoc = XDocument.Parse(data);
            var doc = new Document
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
            return doc;
        }
    }
}
