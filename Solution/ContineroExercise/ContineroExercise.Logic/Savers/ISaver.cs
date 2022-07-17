using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Savers
{
    /// <summary>
    /// Represents a 
    /// </summary>
    public interface ISaver
    {
        /// <summary>
        /// Saves data into a destination
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task SaveAsync(byte[] data);

        /// <summary>
        /// Saves a string into a destination
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task SaveStringAsync(string data)
            => await SaveAsync(Encoding.UTF8.GetBytes(data));
        
    }
}
