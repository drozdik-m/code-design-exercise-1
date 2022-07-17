# About

This is a code design exercise from [Continero](https://www.continero.com/). 

## Instructions

Please find a console application in the [Problem](./Problem) folder whose primary purpose is to convert the formats.

### Prepare:

Please find at least five potential code issues and be able to explain the reason behind them.

2. Refactor the app to allow:
	- Work with documents of various storages, eg. filesystem, cloud storage or HTTP (HTML read-only), etc. Implement just one of them, but be sure that implementation is versatile for adding other storages.
	- Be capable of reading/writing different formats. Implement XML and JSON format, but be sure that implementation is versatile for adding more formats (YAML, BSON, etc.). 
	- Build the app in a way to be able to test classes in isolation
	- Be able to add new formats and storages in the future so it will have no or minimal impact on the existing code
	- Be able to use any combination of input/output storages and formats (eg. read JSON from the filesystem, convert to XML and upload to cloud storage)

### Things to remember

This exercise tests the **design of the given code** that should match the quality of the production application. Thus imagine this application as a system ready for feature development (adding new storages or formats).

**Tests should be written** as a demonstration of your skills; there is no need to cover everything.

## A solution

This is an abstract overview of the solution:

![Abstract overview diagram](./imgs/solution.png)

The solution is a simple yet highly expandable and modifiable pipeline. 

**`IDataSource`** is an abstract representation of data. I can be anything that can work with streams, which is virtually anything. First I though about a solution with BLOBs and such, however, using a standard structure as a Stream is more that enought for a solution of this scale.

Currently implemented sources:
- Files
- In-Memory – very convenient


**`IReader`** uses a data source and transforms it into a data model. First, I intuitively went with readers accepting something more abstract thana  data source (or just bytes); however, data sources are abstract and comfortable enough to be accepted directly. This resulted in potential efficiency boosts, where files (and other structures) are not required to be loaded entirely into memory. 

Currently implemented readers:
- JSON
- XML

**`IExporter`** takes a data model and exports it to bytes. Initially, I wanted to continue the efficiencies of the stream; similar to readers; however, more research and intense design needed to be undertaken, and this solution is more than suitable for this case and scale. A more efficient solution can be added without combinatoric ripple changes. 

Currently implemented exporters:
- JSON
- XML

Readers and exporters can be treated as general classes for multiple general data models. Specific readers and exporters for specific data models can also be inherited quite quickly and cleanly. 

**`ISaver`** simply saves a byte array (and possibly other formats) into a target.

### UI

The console UI is just a hard-coded process. Additionally, specific arguments could affect and set different sources, readers, exporters, and savers. I consider this an unnecessary addition for this case, however, the program structure allows me to do it easily. 

### Testing

Unit testing has been done with a scale according to the exercises' scale. XML testing and some other edge cases have been skipped for they would take more time unnecessarily. 