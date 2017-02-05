using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CBetterUI : LuaBehaviour {
    public bool isRecordUI = true;
    protected Dictionary<string, UnityEngine.Object> m_lstData = new Dictionary<string, Object>();

    public override void Awake() {
        Init();
        base.Awake();
    }

    public void Init() {
        if (isRecordUI) {
            InitUI();//缓存UI组件
        }
    }

    public void InitUI() {
        RecordUI(transform, true);
    }


    public void RecordUI(Transform obj, bool islog = false) {
        RecordUIImpl(obj, islog);
    }

    private void RecordUIImpl(Transform obj, bool islog = false) {
        Add(obj.gameObject);
        if (islog) {
            Debug.Log("record go " + obj.gameObject.name );
        }
        for (var i = 0; i < obj.childCount; ++i) {
            RecordUIImpl(obj.GetChild(i), islog);
        }
    }

    /// <summary>
    /// add 
    /// </summary>
    /// <param name="model"></param>
    public void Add(UnityEngine.Object obj) {
        m_lstData[obj.name] = obj;
    }

    /// <summary>
    /// get
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public UnityEngine.Object Get(string objName) {
        if (m_lstData.ContainsKey(objName)) {
            return this.m_lstData[objName];
        } else {
            return null;
        }

    }

    /// <summary>
    /// Remove 
    /// </summary>
    public void Remove(string objName) {
        if (m_lstData.ContainsKey(objName)) {
            m_lstData.Remove(objName);
        }
    }

    public int Count {
        get {
            return m_lstData.Count;
        }
    }

    /// <summary>
    /// Clear 
    /// </summary>
    public void Clear() {
        m_lstData.Clear();
    }
}
