using ContineroExercise.Logic.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Savers
{
    public abstract class Saver : ISaver
    {
        readonly ISaver saverTrait;

        public Saver()
        {
            saverTrait = this;
        }

        /// <inheritdoc/>
        public abstract Task SaveAsync(byte[] data);

        /// <summary>
        /// Saves a string into a destination
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task SaveAsync(string data)
            => saverTrait.SaveStringAsync(data);
    }
}
