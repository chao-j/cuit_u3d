using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
public class TalkTrigger : MonoBehaviour
{
    //public Story01 data;
    public AvgData data;
    public AvgAssetConfig team;

    public UIManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.startAvg(data,team);
    }
}
