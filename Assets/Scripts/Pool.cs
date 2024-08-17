using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private int _minCapacity;
    [SerializeField]
    private int _maxCapacity;
    [Space(10)]
    [SerializeField]
    private bool _autoExpand;
    [Space(10)]
    [SerializeField]
    private Transform _container;
    [Space(10)]
    [SerializeField]
    private PoolObject[] _prefab;

    private List<PoolObject> _pool;

    public List<PoolObject> PoolObject 
    { 
        get 
        { 
            return _pool;
        }
    }

    private void OnValidate()
    {
        if (_autoExpand)
        {
            _maxCapacity = int.MaxValue;
        }
    }

    private void CreatePool()
    {
        _pool = new List<PoolObject>(_minCapacity);

        for (int i = 0; i < _minCapacity; i++)
        {
            CreateElement();
        }
    }

    private PoolObject CreateElement(bool isActiveByDefault = false)
    {
        PoolObject createdObject = null; ;

        if (_prefab.Length > 1)
        {
            for (int i = 0; i < _prefab.Length; i++)
            {
                createdObject = Instantiate(_prefab[i], _container);
                createdObject.gameObject.SetActive(isActiveByDefault);
                _pool.Add(createdObject);
            }
            return createdObject;
        }
        else
        {
            createdObject = Instantiate(_prefab[0], _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }
    }

    private bool TryGetElement(out PoolObject element)
    {
        var inactiveElements = new List<PoolObject>();
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                inactiveElements.Add(item);
            }
        }

        if (inactiveElements.Count > 0)
        {
            element = inactiveElements[Random.Range(0, inactiveElements.Count)];
            element.gameObject.SetActive(true);
            return true;
        }

        element = null;
        return false;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }

        if (_autoExpand)
        {
            return CreateElement(true);
        }

        if (_pool.Count < _maxCapacity)
        {
            return CreateElement(true);
        }

        throw new System.Exception(message: "Pool is over!");   
    }

    public PoolObject GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        return element;
    }

    public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }

    private void Awake()
    {
        CreatePool();
    }
}