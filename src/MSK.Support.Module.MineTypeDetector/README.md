# Mime Type Detector

This is a sub-module in [Modular Starter Kits](https://github.com/thangchung/modular-starter-kits) project
The mime type detector for files (e.g. png, gif, jpeg, rtf, pdf, docx, zip, rar,...) helps to prevent attacker trying to upload or attack damage files to the web server.
Reference to [OWASP Top 10 - 2017](https://www.owasp.org/index.php/Top_10-2017_Top_10) for the risks.

> Based on https://github.com/Muraad/Mime-Detective

Usage 

```csharp

// Both ways are writing the data to a temp file
// to get a FileInfo. GetFileType are extension methods
byte[] fileData = ...;
FileType fileType = fileData.GetFileType();
   
// or 
Stream fileDataStream = ...;
FileType fileType = fileDataStream.GetFileType();

// If writing to a temp file is not practicable use it like this
byte[] fileData = ...;
FileType fileType = MimeTypes.GetFileType(() => fileData);
   
```
