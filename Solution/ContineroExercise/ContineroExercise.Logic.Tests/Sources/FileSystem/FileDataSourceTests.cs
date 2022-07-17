using ContineroExercise.Logic.Savers.FileSystem;
using ContineroExercise.Logic.Sources.FileSystem;
using System.Text;

namespace ContineroExercise.Logic.Tests.Sources.FileSystem
{
    public class FileDataSourceTests
    {
        [Test]
        public async Task FileSave_NotExists()
        {
            var guid = Guid.NewGuid().ToString();
            var filePath = $"./{guid}.txt";

            try
            {
                //Create the saver and save stuff
                var save = new FileSaver(filePath);
                await save.SaveAsync("Keep calm and save bytes");


                //Check the contents
                var content = await File.ReadAllTextAsync(filePath);
                Assert.That(content, Is.EqualTo("Keep calm and save bytes"));
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
        public async Task FileSave_Exists()
        {
            var guid = Guid.NewGuid().ToString();
            var filePath = $"./{guid}.txt";

            try
            {
                await File.WriteAllTextAsync(filePath, "Ahoj");

                //Create the saver and save stuff
                var save = new FileSaver(filePath);
                await save.SaveAsync("Keep calm and save bytes");

                //Check the contents
                var content = await File.ReadAllTextAsync(filePath);
                Assert.That(content, Is.EqualTo("Keep calm and save bytes"));
            }
            catch
            {

            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}