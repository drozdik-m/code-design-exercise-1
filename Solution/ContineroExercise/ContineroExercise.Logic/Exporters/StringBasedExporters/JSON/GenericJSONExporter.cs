using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Exporters.StringBasedExporters.JSON
{
    public class GenericJSONExporter<TModel> : StringBasedExporter<TModel>
    {
        /// <inheritdoc/>
        protected override string FromModel(TModel model)
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}
