using UnityEngine;
using TMPro;
using Python.Runtime;

public class PythonVersionUI : MonoBehaviour
{
    [SerializeField] private TMP_Text versionText;

    void Start()
    {
        Runtime.PythonDLL = Application.streamingAssetsPath + "/python-3.10.0-embed-amd64/python310.dll";
        PythonEngine.Initialize();

        using (Py.GIL())
        {
            PyObject sys = Py.Import("sys");
            string version = sys.GetAttr("version").ToString();
            versionText.text = "Python " + version;
        }

        PythonEngine.Shutdown();
    }
}
