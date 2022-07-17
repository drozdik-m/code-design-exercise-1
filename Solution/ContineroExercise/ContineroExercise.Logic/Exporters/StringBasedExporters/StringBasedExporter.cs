using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Exporters.StringBasedExporters
{
    public abstract class StringBasedExporter<TModel> : Exporter<TModel>
    {
        /// <inheritdoc />
        public override Task<byte[]> ExportAsync(TModel model)
        {
            var exportString = FromModel(model);
            return Task.FromResult(Encoding.UTF8.GetBytes(exportString));
        }

        /// <summary>
        /// Converts a model into a string representation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected abstract string FromModel(TModel model);
    }
}
