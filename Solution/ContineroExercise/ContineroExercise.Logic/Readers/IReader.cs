using ContineroExercise.Logic.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Readers
{
    public interface IReader<TModel>
    {
        /// <summary>
        /// Reads a source and translates it into a data model
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        Task<TModel> ReadAsync(IDataSource dataSource);
    }
}
