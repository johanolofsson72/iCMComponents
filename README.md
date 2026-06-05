# iCMComponents

Server-side building blocks for the iCM content management system: ASP.NET server controls, SOAP web services, a data-access library, and a pile of test harnesses. Written in C# and VB.NET against .NET Framework 1.1 (Visual Studio .NET 2003 project format). The code dates from roughly 2003-2005 and is archived here as-is.

## What's included

Everything lives under `wwwroot/`. The pieces that matter:

- **iCMServer** (`iCMServer/`, also `iConsulting.iCMServer.Library/`) — the core object model. C# classes `iCMServer`, `Site`, `Page`, `Module` and their collections (`SiteCollection`, `PageCollection`, `ModuleCollection`), plus a `DocumentCache`. This is the runtime that loads a site's pages and the modules on each page. A compiled `iConsulting.iCMServer.dll` sits in `Source/`.
- **iCDataManager / iCDataManager2 / iCDataManagerService** — VB.NET ASMX web services that wrap the data source. Operations include `GetData`, `GetDataFromSP`, `GetDataScalar`, `GetMultiData`, `SaveData`, `SaveBlobData`, `UpdateData`. Crypto helpers guard the column/table strings passed across the wire.
- **iCDataGrid** (`iCDataGrid/clsDataGrid.vb`) — a VB.NET data grid web control built on `System.Web.UI.WebControls.DataGrid`, with sortable arrow templates, link/delete button templates, paging (default page size 10) and AES-style crypto over the authorized-column string.
- **iCXmlDbClient** — a C# ADO.NET provider (`XmlDbConnection`, `XmlDbCommand`, `XmlDbDataReader`, `XmlDbDataAdapter`, `XmlDbTransaction`, `XmlDbParameter`) that talks to an XML-over-HTTP database. Based on Paul Wilson's WilsonDotNet sample — credit lines preserved in the source.
- **iCUpload** (`iCUpload/iCUpload/iCUpload.vb`) — a VB.NET upload control with a progress bar, built on the SoftArtisans.Net upload component.
- **iCLibrary** (`iConsulting.Library`) — shared VB.NET utilities: SMTP mail (`clsSmtpMail`), crypto (`clsCrypto`), binary cache, and several data-list helpers (`clsJoinView`, `clsMultiQueryList`, `clsBlobDataList`, and so on).
- **iCInstaller** — a Windows Forms installer (`Easy.vb`) that ships a `iCInstaller.zip` and a bundle of CMS modules: Documents, Calendar, Discussion, Events, Mediagallery, Notice, Publisher, Quicklinks, Search, Timeline, Timesheet, plus numbered page templates (Template005-Template013, RBTemplate2).
- **iCDataChannel** (`iCDataChannel/Document/`) — design notes only (ER models and `.txt` API/taxonomy specs), no code. Documents the web-service interface and the taxonomy mapping (Tables/Columns/Items/Taxon).
- **Testers and scratch projects** — `iCMServerTester`, `iCDataManager2Tester`, `iConsulting.iCMServer.Library.Tester`, `Tester`, `FTPGet`, and the `WebApplication1-4` / `Wrapper995*` projects are test harnesses and experiments, kept for reference.

`Dokument/` holds two CASE Studio (`iCModeler`) ER-model files for the database schema.

## Tech stack

- C# and VB.NET, .NET Framework 1.1
- ASP.NET Web Forms server controls + ASMX (SOAP) web services
- Visual Studio .NET 2003 (`.csproj`/`.vbproj` in the old XML `<VisualStudioProject>` format, `ProductVersion 7.10.3077`)
- MySQL Connector/Net 1.0.6 bundled under `iCDataHandler/`
- Third-party bits: SoftArtisans.Net (upload), Chilkat FTP, Paul Wilson's XmlDbClient sample

## Related repos

Part of the same iCM family:

- [iCMServer](https://github.com/johanolofsson72/iCMServer) — the iCM server side
- [iCMModules](https://github.com/johanolofsson72/iCMModules) — the CMS modules

This repo is the components/library layer those projects build on.

## Getting started

There's no modern build here. To open it you need Visual Studio .NET 2003 (or a later VS that can still upgrade the 7.10 project format) and the .NET Framework 1.1 SDK. Open the per-project solution you care about, for example:

```
wwwroot/iCMServer/iCMServer.sln
wwwroot/iCDataGrid/iCDataGrid.sln
wwwroot/iCXmlDbClient/WilsonXmlDbClient.sln
```

The web-service and web-control projects expect to run under IIS with ASP.NET 1.1. The MySQL data path needs the bundled Connector/Net registered. Expect to do some manual wiring — this predates NuGet, package restore, and modern MSBuild.

## Status

Archived. Single `init` commit, last touched 19 October 2024 (the code itself is from 2003-2005). Nothing here targets a supported .NET Framework or runtime any more. It's kept for history and reference, not for active development.
