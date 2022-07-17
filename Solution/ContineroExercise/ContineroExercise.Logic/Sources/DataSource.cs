using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Sources
{
    public abstract class DataSource : IDataSource
    {
        readonly IDataSource dataSourceTrait;

        public DataSource()
        {
            dataSourceTrait = this;
        }

        /// <inheritdoc />
        public abstract Task<Stream> GetStreamAsync();

        /// <summary>
        /// Takes the stream data source and converts it into UTF-8 string
        /// </summary>
        /// <returns></returns>
        public Task<string> GetStreamAsStringAsync()
            => dataSourceTrait.GetStreamInStringAsync();
    }
}
