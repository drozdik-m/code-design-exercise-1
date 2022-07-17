using ContineroExercise.Logic.Data;
using ContineroExercise.Logic.Data.Exporters;
using ContineroExercise.Logic.Data.Readers;
using ContineroExercise.Logic.Exporters;
using ContineroExercise.Logic.Exporters.StringBasedExporters.JSON;
using ContineroExercise.Logic.Readers;
using ContineroExercise.Logic.Readers.StringBasedReaders.JSON;
using ContineroExercise.Logic.Readers.StringBasedReaders.XML;
using ContineroExercise.Logic.Savers;
using ContineroExercise.Logic.Savers.FileSystem;
using ContineroExercise.Logic.Sources;
using ContineroExercise.Logic.Sources.FileSystem;
using ContineroExercise.Logic.Sources.Memory;

//--- SOURCE ---
var sourceFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\SourceFiles\\document.json");
var source = new FileDataSource(sourceFileName);

//In memory source
/*var source = new MemoryDataSource("{" +
  "\"Title\": \"Ahoj\"," +
  "\"Text\": \"Ano, ty!\"" +
"}");*/

//--- READER ---
//Specific for the document – inherited from GenericJSONReader
var reader = new DocumentJSONReader();

//General reader
//var reader = new GenericJSONReader<Document>();

//Others
//var reader = new DocumentXMLReader();
//var reader = new GenericXMLReader<Document>();

//--- EXPORTER ---
//* Very simmilar to readers
var exporter = new DocumentXMLExporter();

//General exporter
//var exporter = new GenericXMLExporter<Document>();

//Others
//var exporter = new DocumentJSONExporter();
//var exporter = new GenericJSONExporter<Document>();


//--- SAVER ---
var saver = new FileSaver("..\\..\\..\\SourceFiles\\export.xml");

//--- EXECUTE ---
await ExecuteProcessAsync(source, reader, exporter, saver);

/// <summary>
/// The main business process of the application
/// </summary>
async Task ExecuteProcessAsync<TModel>(
    IDataSource source,
    IReader<TModel> reader,
    IExporter<TModel> exporter,
    ISaver saver)
{
    //Read the source
    var model = await reader.ReadAsync(source);

    //Export the model
    var export = await exporter.ExportAsync(model);

    //Save the result
    await saver.SaveAsync(export);
}