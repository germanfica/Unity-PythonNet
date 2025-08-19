using System;
using UnityEngine;
using Python.Runtime;

public class PythonTest : MonoBehaviour
{
    void Start()
    {
        Runtime.PythonDLL = Application.streamingAssetsPath + "/python-3.10.0-embed-amd64/python310.dll";
        PythonEngine.Initialize();

        using (Py.GIL())
        {
            PyObject sys = Py.Import("sys");
            string version = sys.GetAttr("version").ToString();
            Debug.Log("Python version: " + version);
        }

        PythonEngine.Shutdown();
    }
}
