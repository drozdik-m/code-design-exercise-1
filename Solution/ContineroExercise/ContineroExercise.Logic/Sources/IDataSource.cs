using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Sources
{
    /// <summary>
    /// Represents a binary source of data
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Returns a binary representation fo the data source via Stream
        /// </summary>
        /// <returns></returns>
        Task<Stream> GetStreamAsync();

        /// <summary>
        /// Takes the stream data source and converts it into UTF-8 string
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetStreamInStringAsync()
        {
            using var stream = await GetStreamAsync();
            stream.Position = 0;

            using StreamReader reader = new(stream, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }
    }


}
