using System;
using System.Collections.Generic;
using UnityEngine;


abstract class ModelManager
{
    //Caching for already created artifacts
    Dictionary<int, GameObject> _cache;


    //Get the ids of all artifacts that can be rendered in unity
    public abstract int[] availableModelIds();

    //Given the id of a model, return its representation as a Unity GameObject
    public abstract GameObject createModel(int modelId);

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

        return GameObject.Instantiate(_cache[modelId]);
    }
}