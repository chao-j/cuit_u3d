using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<string> contents;
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
            LoadText(contents[curLine]);
            ShowUI();
        }
        if (Input.GetMouseButtonDown(0))
        {
            NextLine();
            if (curLine >= contents.Count)
            {
                Init();
            }
            LoadText(contents[curLine]);
        }
    }

    private void Init()
    {
        HideUI();
        curLine = 0;
        uiPanel.SetDigText("");
    }

    private void ShowUI()
    {
        uiPanel.ShowCharaA(true);
        uiPanel.ShowCharaB(true);
        uiPanel.ShowDigBg(true);
        uiPanel.ShowDigText(true);
    }

    private void HideUI()
    {
        uiPanel.ShowCharaA(false);
        uiPanel.ShowCharaB(false);
        uiPanel.ShowDigBg(false);
        uiPanel.ShowDigText(false);
    }

    private void NextLine()
    {
        curLine++;
    }

    private void LoadText(string text)
    {
        uiPanel.SetDigText(text);
    }
}
