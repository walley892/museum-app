using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LocalModelManager : ModelManager
{
    //Directory where models are locally stored
    private string _modelDir;
    private string _imageDir;

    public LocalModelManager(string modelPath, string imagePath) : base()
    {
        _modelDir = modelPath;
        _imageDir = imagePath;
    }

    public override GameObject createModel(int modelId)
    {

        if (isCached(modelId))
        {
            return createCachedModel(modelId);
        }

        GameObject g = new GameObject();
        Material mat = new Material(Shader.Find("Specular"));
        g.AddComponent<MeshFilter>().mesh = Resources.Load<Mesh>(_modelDir + "/model_" + modelId);
        g.AddComponent<MeshRenderer>().material = mat;

        cacheModel(modelId, g);
        return g;
    }

    public override int[] availableModelIds()
    {
        return new int[] { 1, 2, 3 };
    }

    public override Texture2D getTrackedImage(int modelId)
    {
        return Resources.Load<Texture2D>(_imageDir + "/image_" + modelId);
    }
}
