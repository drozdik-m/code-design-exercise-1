using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Sources.FileSystem
{
    public class FileDataSource : DataSource
    {
        private readonly string filePath;

        public FileDataSource(string filePath)
        {
            this.filePath = filePath;
        }

        public override Task<Stream> GetStreamAsync()
        {
            //Check the file existence
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File ${filePath} has not been found");

            //Load the file stream
            Stream stream = File.Open(filePath, FileMode.Open);
            return Task.FromResult(stream);
        }
    }
}
