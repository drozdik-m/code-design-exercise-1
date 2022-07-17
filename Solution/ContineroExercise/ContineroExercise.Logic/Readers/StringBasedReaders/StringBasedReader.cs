using ContineroExercise.Logic.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Readers.StringBasedReaders
{
    public abstract class StringBasedReader<TModel> : Reader<TModel>
    {
        /// <inheritdoc/>
        public override async Task<TModel> ReadAsync(IDataSource dataSource)
        {
            var sourceString = await GetSourceAsStringAsync(dataSource);
            var model = CreateModel(sourceString);
            return model;
        }

        /// <summary>
        /// The logic that creates the model out of the data string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected abstract TModel CreateModel(string data);

        /// <summary>
        /// Reads the data source as UTF-8 string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected Task<string> GetSourceAsStringAsync(IDataSource source)
            => source.GetStreamInStringAsync();
    }
}
