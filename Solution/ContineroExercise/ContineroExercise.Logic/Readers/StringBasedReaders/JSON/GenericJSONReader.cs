using ContineroExercise.Logic.Sources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContineroExercise.Logic.Readers.StringBasedReaders.JSON
{
    public abstract class GenericJSONReader<TModel> : JSONReader<TModel>
    {
        protected override TModel CreateModel(string jsonString)
        {
            var result = JsonConvert.DeserializeObject<TModel>(jsonString);
            if (result is null)
                throw new Exception($"Could not generally transform the JSON model");

            return result;
        }
    }
}
