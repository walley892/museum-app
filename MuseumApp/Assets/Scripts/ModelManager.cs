using System;
using System.Collections.Generic;
using UnityEngine;


abstract class ModelManager
{
    Dictionary<int, GameObject> _cache;

    public abstract int[] availableModelIds();
    public abstract GameObject createModel(int modelId);

    public ModelManager()
    {
        _cache = new Dictionary<int, GameObject>();
    }

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