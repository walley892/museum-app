using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class LocalModelManager : ModelManager
{

    private string _modelDir;

    public LocalModelManager(string path) : base()
    {
        _modelDir = path;
    }

    public override GameObject createModel(int modelId)
    {

        if (isCached(modelId))
        {
            return createCachedModel(modelId);
        }

        GameObject g = new GameObject();
        Object.DontDestroyOnLoad(g);
        Material mat = new Material(Shader.Find("Specular"));
        g.AddComponent<MeshFilter>().mesh = Resources.Load<Mesh>(_modelDir + "/model_" + modelId);
        g.AddComponent<MeshRenderer>().material = mat;

        g.SetActive(false);
        cacheModel(modelId, g);
        GameObject h = GameObject.Instantiate(g);
        h.SetActive(true);
        return h;
    }
}
