using ContineroExercise.Logic.Sources;
using ContineroExercise.Logic.Sources.FileSystem;
using System.Text;

namespace ContineroExercise.Logic.Tests.Sources.FileSystem
{
    public class DataSourceTests
    {
        class TestingIDataSource : DataSource
        {
            public override Task<Stream> GetStreamAsync()
            {
                var stream = new MemoryStream(Encoding.ASCII.GetBytes("Toto je test"));

                Stream result = stream;
                return Task.FromResult(result);
            }
        }

        [Test]
        public async Task GetStreamAsStringAsync()
        {
            var testSource = new TestingIDataSource();
            Assert.That(await testSource.GetStreamAsStringAsync(), Is.EqualTo("Toto je test"));
        }

    }
}