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


