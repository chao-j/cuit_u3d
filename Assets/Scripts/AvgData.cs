using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AvgData : ScriptableObject
{
    public List<DialogContent> contents;
    
}

[System.Serializable]
public class DialogContent
{
    public string dialogText;
    public bool showA;
    public bool showB;
}