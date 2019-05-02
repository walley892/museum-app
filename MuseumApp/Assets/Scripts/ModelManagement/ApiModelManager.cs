using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using art_dl;

public class ApiModelManager : ModelManager
{
    //Directory where model data is locally stored
    private string _baseDir;

    public ApiModelManager(string baseDir) : base()
    {
        _baseDir = baseDir;
    }

    public override GameObject createModel(int modelId, bool augmented = false)
    {

        if (isCached(modelId))
        {
            return createCachedModel(modelId);
        }

        GameObject g = new GameObject();
        string shader = "Mobile/VertexLit";
        if (augmented)
        {
            shader = "ARCore/SpecularWithLightEstimation";
        }
        Material mat = new Material(Shader.Find(shader));

        g.AddComponent<MeshFilter>().mesh = getMesh(modelId);

        g.AddComponent<MeshRenderer>().material = mat;
        g.SetActive(false);
        GameObject.DontDestroyOnLoad(g);

        g.AddComponent<MeshCollider>();

        g.GetComponent<Renderer>().material.SetTexture("_MainTex", getTexture(modelId));

        cacheModel(modelId, g);

        GameObject model = GameObject.Instantiate(g);
        model.SetActive(true);

        return model;
    }

    public override int[] availableModelIds()
    {
        artifact_dl dl = new artifact_dl("", "");
        //return dl.get_all_models();
        return new int[] { };
    }

    public override Texture2D getTrackedImage(int modelId)
    {
        Texture2D tmp = Resources.Load<Texture2D>(_baseDir + "qr_codes/image_" + modelId);
        Texture2D ret = new Texture2D(tmp.width,tmp.height,TextureFormat.RGBA32, false);
        
        ret.SetPixels(tmp.GetPixels());
        ret.Apply();
        return ret;
    }

    public override Mesh getMesh(int modelId)
    {
        artifact_dl dl = new artifact_dl("", "models/");
        dl.get_model();

        return Resources.Load<Mesh>(_baseDir + "models/model_" + modelId);
    }

    public override Texture2D getTexture(int modelId)
    {
        artifact_dl dl = new artifact_dl("", "textures/");
        dl.get_texture();

        Texture2D tmp = Resources.Load<Texture2D>(_baseDir + "textures/texture_" + modelId);
        Texture2D ret = new Texture2D(tmp.width, tmp.height, TextureFormat.RGBA32, false);

        ret.SetPixels(tmp.GetPixels());
        ret.Apply();
        return ret;
    }
}
