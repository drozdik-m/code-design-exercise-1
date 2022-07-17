using ContineroExercise.Logic.Exporters.StringBasedExporters.JSON;
using ContineroExercise.Logic.Readers.StringBasedReaders;
using ContineroExercise.Logic.Readers.StringBasedReaders.JSON;
using ContineroExercise.Logic.Sources.FileSystem;
using ContineroExercise.Logic.Sources.Memory;
using Newtonsoft.Json;
using System.Text;

namespace ContineroExercise.Logic.Tests.Sources.FileSystem
{
    public class GenericJSONExporterTests
    {
        public record Document
        {
            public string Title { get; set; } = string.Empty;

            public string Text { get; set; } = string.Empty;
        }

        [Test]
        public async Task GenericDocument()
        {
            var doc = new Document()
            {
                Title = "Ahoj",
                Text = "Mam rad zmrzlinu"
            };
            var serializedDoc = await new GenericJSONExporter<Document>().ExportAsync(doc);
            var deserializedDoc = JsonConvert.DeserializeObject<Document>(
                Encoding.UTF8.GetString(serializedDoc)
                );

            Assert.That(deserializedDoc, Is.EqualTo(doc));
        }
        [Test]
        public async Task GenericValue()
        {
            var val = "ahoj";
            var serializedVal = await new GenericJSONExporter<string>().ExportAsync(val);
            var decoded = Encoding.UTF8.GetString(serializedVal);
            var deserializedVal = JsonConvert.DeserializeObject<string>(decoded);

            Assert.That(deserializedVal, Is.EqualTo(val));
        }
    }
}