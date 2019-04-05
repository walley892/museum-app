using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class ModelManager
{
    //Caching for already created artifacts
    Dictionary<int, GameObject> _cache;


    //Get the ids of all artifacts that can be rendered in unity
    public abstract int[] availableModelIds();

    //Given the id of a model, return its representation as a Unity GameObject
    public abstract GameObject createModel(int modelId);

    //Given the id of a model, return the image that will trigger its instantiation
    public abstract Texture2D getTrackedImage(int modelId);

    public ModelManager()
    {
        _cache = new Dictionary<int, GameObject>();
    }

    //Add a spawned model to the cache
    public void cacheModel(int modelId, GameObject obj)
    {
        _cache.Add(modelId, obj);
    }

    public bool isCached(int modelId)
    {
        return _cache.ContainsKey(modelId);
    }

    public GameObject createCachedModel(int modelId)
    {
        if (!isCached(modelId))
        {
            throw new KeyNotFoundException("Model not in the cache");
        }

        GameObject model = GameObject.Instantiate(_cache[modelId]);
        model.SetActive(true);

        return model;
    }
}