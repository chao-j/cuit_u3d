using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //public List<string> contents;
    public AvgData data;
    public AvgAssetConfig asset;
    public UIPanel uiPanel;
    [SerializeField]
    private int curLine;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Init();
            //LoadText(data.contents[curLine].dialogText);
            LoadCharaTexture(asset.CharaATex, asset.CharaBTex);
            ShowUI();
        }
        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
            if (curLine >= data.contents.Count)
            {
                Init();
            }
            LoadContent(data.contents[curLine].dialogText,data.contents[curLine].showA, data.contents[curLine].showB);
        }
    }

    private void Init()
    {
        HideUI();
        curLine = 0;
        uiPanel.SetDigText("");
        LoadContent(data.contents[curLine].dialogText, data.contents[curLine].showA, data.contents[curLine].showB);
    }

    private void ShowUI()
    {
        //uiPanel.ShowCharaA(true);
        //uiPanel.ShowCharaB(true);
        //uiPanel.ShowDigBg(true);
        //uiPanel.ShowDigText(true);
        uiPanel.ShowCanvas(true);
    }

    private void HideUI()
    {
        //uiPanel.ShowCharaA(false);
        //uiPanel.ShowCharaB(false);
        //uiPanel.ShowDigBg(false);
        //uiPanel.ShowDigText(false);
        uiPanel.ShowCanvas(false);
    }

    private void NextLine()
    {
        curLine++;
    }

    private void LoadText(string text)
    {
        uiPanel.SetDigText(text);
    }

    private void LoadContent(string text,bool showA,bool showB)
    {
        uiPanel.SetDigText(text);
        uiPanel.ShowCharaA(showA);
        uiPanel.ShowCharaB(showB);
    }

    private void LoadCharaTexture(Texture texA,Texture texB)
    {
        uiPanel.ChangeCharaATex(texA);
        uiPanel.ChangeCharaBTex(texB);
    }
}
