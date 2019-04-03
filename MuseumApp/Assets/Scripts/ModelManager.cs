using System;
using System.Collections.Generic;
using UnityEngine;


abstract class ModelManager
{
    Dictionary<int, GameObject> _cache;

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
        if (!_cache.ContainsKey(modelId))
        {
            throw new KeyNotFoundException("Model not in the cache");
        }

        GameObject model = GameObject.Instantiate(_cache[modelId]);
        model.SetActive(true);

        return model;
    }
}