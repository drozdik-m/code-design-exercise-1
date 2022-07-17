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
    }


}
