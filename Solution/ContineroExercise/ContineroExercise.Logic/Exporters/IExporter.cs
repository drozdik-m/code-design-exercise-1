using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Exporters
{
    public interface IExporter<TModel>
    {
        /// <summary>
        /// Exports a model into its byte representation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Task<byte[]> ExportAsync(TModel model);
    }
}
