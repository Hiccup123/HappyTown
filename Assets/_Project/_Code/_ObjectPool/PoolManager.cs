using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    Dictionary<string, Queue<GameObject>> _pool;

    void Awake()
    {
        _pool = new Dictionary<string, Queue<GameObject>>();
    }

    /// <summary>
    /// 从对象池中获取对象
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public GameObject RequestObj(GameObject prefab)
    {
        GameObject getObj;
        string tag = "Pool_" + prefab.name;
        //Debug.Log("tag:" + tag);
        Queue<GameObject> arr;
        if (!_pool.TryGetValue(tag, out arr))
        {
            arr = new Queue<GameObject>();
            _pool.Add(tag, arr);
        }
        //Debug.Log("arr.Count:" + arr.Count);
        getObj = arr.Count > 0 ? arr.Dequeue() : GameObject.Instantiate(prefab) as GameObject;
        getObj.SetActive(true);

        PoolMark mark = getObj.GetComponent<PoolMark>() ?? getObj.AddComponent<PoolMark>();
        mark._Mark = tag;

        return getObj;
    }

    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="obj"></param>
    public void RecycleObj(GameObject obj)
    {
        PoolMark mark = obj.GetComponent<PoolMark>() ?? obj.AddComponent<PoolMark> ();
        if(string.IsNullOrEmpty(mark._Mark))
        {
            Debug.LogWarning("The gameObject has not been marked ! Please Check the gameObject : " + obj);
            mark._Mark = "Pool_" + obj.name;
        }

        //Debug.Log("mark:" + mark._Mark);
        Queue<GameObject> arr;
        if (!_pool.TryGetValue(mark._Mark, out arr))
        {
            arr = new Queue<GameObject>();
            _pool.Add(mark._Mark, arr);
        }

        UnityHelper.AddChildToParent(obj.transform, this.transform);
        obj.SetActive(false);
        arr.Enqueue(obj);
        //Debug.Log("arr1.Count：" + arr.Count);
    }

    /// <summary>
    /// Destroy all GameObjects in the pool.
    /// </summary>
    public void Clear()
    {
        foreach (KeyValuePair<string, Queue<GameObject>> kv in _pool)
        {
            Queue<GameObject> list = kv.Value;
            foreach (GameObject obj in list)
            {
                GameObject.Destroy(obj);
            }
        }
        _pool.Clear();
    }

    /// <summary>
    /// 对象池的数量
    /// </summary>
    public int count
    {
        get { return _pool.Count; }
    }
}
