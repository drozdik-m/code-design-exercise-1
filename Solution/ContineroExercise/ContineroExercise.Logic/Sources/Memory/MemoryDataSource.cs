using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Sources.Memory
{
    /// <summary>
    /// In-Memory data source
    /// </summary>
    public class MemoryDataSource : DataSource
    {
        readonly MemoryStream memoryStream = new();

        public MemoryDataSource(MemoryStream memoryStream)
        {
            this.memoryStream = new();
            memoryStream.Position = 0;
            memoryStream.CopyTo(this.memoryStream);
            this.memoryStream.Position = 0;
        }

        public MemoryDataSource(byte[] bytes)
        {
            memoryStream = new MemoryStream(bytes);
        }

        public MemoryDataSource(string text)
        {
            memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(text));
        }

        /// <inheritdoc/>
        public override Task<Stream> GetStreamAsync()
        {
            Stream result = memoryStream;
            return Task.FromResult(result);
        }
    }
}
