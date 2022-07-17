using ContineroExercise.Logic.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Readers
{
    public abstract class Reader<TModel> : IReader<TModel>
    {
        /// <inheritdoc/>
        public abstract Task<TModel> ReadAsync(IDataSource dataSource);
    }
}
