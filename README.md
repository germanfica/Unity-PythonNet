# Unity-PythonNet

This is a sample project that integrates Unity and Python.NET.

## Prerequisites

- Windows
- Unity 2022.3.15f1 (.NET Framework or both .NET Standard 2.1 and [Microsoft.CSharp](https://www.nuget.org/packages/microsoft.csharp/) is required at Api Compatibility Level)
- [Python.NET](https://www.nuget.org/packages/pythonnet) 3.0.5
- [Python Embeddable Package](https://www.python.org/downloads/windows/) 3.10.0

### Quick Guide to NuGet Packages

**Option 1: Using NuGet CLI**

Download NuGet CLI:

* [NuGet Downloads](https://www.nuget.org/downloads)
* [Latest nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
* [Specific version (v6.14.0)](https://dist.nuget.org/win-x86-commandline/v6.14.0/nuget.exe)

Then install the packages:

```bash
./nuget.exe install Microsoft.CSharp -Version 4.7.0
./nuget.exe install pythonnet -Version 3.0.5
```

---

**Option 2: Direct .nupkg Download**

Alternatively, you can download the `.nupkg` files directly (they are essentially ZIP archives):

* [Microsoft.CSharp 4.7.0](https://www.nuget.org/api/v2/package/Microsoft.CSharp/4.7.0)
* [pythonnet 3.0.5](https://www.nuget.org/api/v2/package/pythonnet/3.0.5)

This method is faster since you can simply extract the `.dll` files from the package manually.

## Project structure

```plaintext
Assets/
 ├─ Plugins/
 │   └─ Python.Runtime.dll                <-- the managed .NET <-> Python bridge
 │
 └─ StreamingAssets/
     └─ python-3.10.0-embed-amd64/
         ├─ python310.dll                 <-- the native Python interpreter (required by Runtime.PythonDLL)
         ├─ python.exe                    <-- optional, useful for testing the embedded environment manually
         ├─ python310.zip                 <-- original compressed standard library (can be removed after extraction)
         │
         └─ Lib/                          <-- must be created manually
             ├─ __future__.py             <-- extracted from python310.zip (part of the Python standard library)
             ├─ os.py                     <-- extracted from python310.zip
             ├─ encodings/                <-- extracted from python310.zip
             ├─ importlib/                <-- extracted from python310.zip
             ├─ ... (all other stdlib modules extracted here)
             │
             └─ site-packages/            <-- external dependencies go here
                 ├─ numpy/                <-- installed via "pip install numpy --target=Lib/site-packages"
                 ├─ numpy-1.26.4.dist-info/
                 ├─ (other dependencies)
```

## Credits

This project was inspired by the work of **shiena** and the repository [Unity-PythonNet](https://github.com/shiena/Unity-PythonNet) (MIT License).  
Special thanks to shiena for sharing this implementation, which served as a valuable reference and guidance during development.
