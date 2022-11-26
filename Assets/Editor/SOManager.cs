using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/MeiMeiSan")]
public class SOManager : ScriptableObject
{
    [SerializeField]
    private int _hogeInt = 0;
    [SerializeField]
    private string _hogeStr = null;

    public List<HogeData> TypeList = new List<HogeData>();
}

[Serializable]
public class HogeData
{
    public TYPE Type = TYPE.None;
    public enum TYPE
    {
        None,
        Type001,
        Type002,
        Type003,
    }

    public int IntText  = 0;
    public string TextName = null;
    public string TextA = null;
    public string TextB = null;
    public Vector3 VectorText = Vector3.zero;
}