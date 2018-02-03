# Utilities
Common utilities for application development: SMTP, LDAP, File Servers, Database, Web Servers, HTTP, TCP, Parallelization, Tasking, etc.

## Publish Nuget:
[Reference](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-nuspec-package-manifest-file )
1. nuget pack Utilities.csproj -Version 1.0.x
2. nuget push GW.Common.Utilities.1.0.15.nupkg {API_KEY} -Source https://www.nuget.org/api/v2/package
