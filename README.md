# Utilities
Common utilities which can be pulled from the core Nuget repository.  These utilities are relevant for application development, including the following areas: SMTP, LDAP, File Servers, Database, Web Servers, HTTP, TCP, Parallelization, Tasking... etc.

## Publish Nuget:
[Reference - pushing to Nuget](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-nuspec-package-manifest-file )

1. nuget pack Utilities.csproj -Version 1.0.x
2. nuget push GW.Common.Utilities.1.0.15.nupkg {API_KEY} -Source https://www.nuget.org/api/v2/package

## Contributing

* Ask a question
* File a bug in [GitHub Issues] (https://github.com/garrettwong/Utilities/issues)

## License

Apache 2.0; see [`LICENSE`](LICENSE) for details.
