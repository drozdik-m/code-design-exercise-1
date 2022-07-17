using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Exporters
{
    public abstract class Exporter<TModel> : IExporter<TModel>
    {
        public abstract Task<byte[]> ExportAsync(TModel model);
    }
}
