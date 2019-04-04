﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalModelManager : ModelManager
{
    //Directory where models are locally stored
    private string _modelDir;
    private string _imageDir;
    private string _textureDir;

    public LocalModelManager(string modelPath, string imagePath, string texPath) : base()
    {
        _modelDir = modelPath;
        _imageDir = imagePath;
        _textureDir = texPath;
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

        g.GetComponent<Renderer>().material.SetTexture("_MainTex", getTexture(modelId));

        cacheModel(modelId, g);
        return g;
    }

    public override int[] availableModelIds()
    {
        return new int[] { 0, 1, 2 };
    }

    public override Texture2D getTrackedImage(int modelId)
    {
        Texture2D tmp = Resources.Load<Texture2D>(_imageDir + "/image_" + modelId);
        Texture2D ret = new Texture2D(tmp.width,tmp.height,TextureFormat.RGBA32, false);
        
        ret.SetPixels(tmp.GetPixels());
        ret.Apply();
        return ret;
    }

    public override Mesh getMesh(int modelId)
    {
        return Resources.Load<Mesh>(_modelDir + "/model_" + modelId);
    }

    public override Texture2D getTexture(int modelId)
    {
        Texture2D tmp = Resources.Load<Texture2D>(_textureDir + "/texture_" + modelId);
        Texture2D ret = new Texture2D(tmp.width, tmp.height, TextureFormat.RGBA32, false);

        ret.SetPixels(tmp.GetPixels());
        ret.Apply();
        return ret;
    }
}
