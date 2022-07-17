using ContineroExercise.Logic.Readers.StringBasedReaders;
using ContineroExercise.Logic.Readers.StringBasedReaders.JSON;
using ContineroExercise.Logic.Sources.FileSystem;
using ContineroExercise.Logic.Sources.Memory;
using Newtonsoft.Json;
using System.Text;

namespace ContineroExercise.Logic.Tests.Sources.FileSystem
{
    public class GenericJSONReaderTests
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
            var serializedDoc = JsonConvert.SerializeObject(doc);
            var reader = new GenericJSONReader<Document>();
            var result = await reader.ReadAsync(new MemoryDataSource(serializedDoc));
            Assert.That(result, Is.EqualTo(doc));
        }
        [Test]
        public async Task GenericValue()
        {
            var val = "ahoj";
            var serializedDoc = JsonConvert.SerializeObject(val);
            var reader = new GenericJSONReader<string>();
            var result = await reader.ReadAsync(new MemoryDataSource(serializedDoc));
            Assert.That(result, Is.EqualTo(val));
        }
    }
}