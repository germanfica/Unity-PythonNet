using UnityEngine;
using TMPro;
using Python.Runtime;
using System.IO;

public class PythonProjectUI : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    void Start()
    {
        string pythonDll = Application.streamingAssetsPath + "/python-3.10.0-embed-amd64/python310.dll";
        string pythonHome = Path.GetDirectoryName(pythonDll);
        string pythonProjectPath = Application.streamingAssetsPath + "/python_project";

        Runtime.PythonDLL = pythonDll;
        PythonEngine.PythonHome = pythonHome;

        PythonEngine.PythonPath =
            pythonHome + "/Lib;" +
            pythonHome + "/Lib/site-packages;" +
            pythonProjectPath;

        PythonEngine.Initialize();

        using (Py.GIL())
        {
            try
            {
                using (PyObject calc = Py.Import("calc"))
                {
                    PyObject result = calc.InvokeMethod("heavy_math");
                    resultText.text = "Resultado Python: " + result.ToString();
                }
            }
            catch (PythonException ex)
            {
                Debug.LogError("Error Python: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        PythonEngine.Shutdown();
    }
}
