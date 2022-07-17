using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Savers.FileSystem
{
    public class FileSaver : Saver
    {
        private readonly string path;

        public FileSaver(string path)
        {
            this.path = path;
        }

        /// <inheritdoc />
        public override async Task SaveAsync(byte[] data)
        {
            await File.WriteAllBytesAsync(path, data);
        }
    }
}
