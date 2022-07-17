using ContineroExercise.Logic.Sources.FileSystem;
using System.Text;

namespace ContineroExercise.Logic.Tests.Sources.FileSystem
{
    public class FileSaverTests
    {
        [Test]
        public async Task FileSave()
        {
            var guid = Guid.NewGuid().ToString();
            var filePath = $"./{guid}.txt";

            try
            {
                //Create the file
                var stream = File.Create(filePath);
                using (StreamWriter writer = new(stream))
                {
                    writer.WriteLine("This is a text");
                }
                stream.Dispose();

                //Check the contents
                var fileSource = new FileDataSource(filePath);
                var fileContentsStream = await fileSource.GetStreamAsync();
                var fileContent = string.Empty;
                using (StreamReader reader = new(fileContentsStream, Encoding.UTF8))
                {
                    fileContent = reader.ReadToEnd();
                }
                Assert.That(fileContent, Is.EqualTo("This is a text" + Environment.NewLine));
            }
            catch
            {

            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [Test]
        public async Task FileNotFound()
        {
            var guid = Guid.NewGuid().ToString();
            var filePath = $"./{guid}.txt";
            var fileSource = new FileDataSource(filePath);
            Assert.ThrowsAsync<FileNotFoundException>(async () => { await fileSource.GetStreamAsync(); });
        }
    }
}