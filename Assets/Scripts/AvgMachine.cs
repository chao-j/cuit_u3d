using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvgMachine : MonoBehaviour
{
    // 状态机
    public enum STATE
    {
        OFF,
        TYPING,
        PAUSE
    }
    public STATE state;

    private bool justEnter;
    public AvgData data;
    public AvgAssetConfig asset;
    public UIPanel uiPanel;

    [Range(5,20)]
    public float typingSpeed = 10f;

    private string targetString;
    private float timerValue;

    [SerializeField]
    private int curLine;
    void Start()
    {
        state = STATE.OFF;
        justEnter = true;
    }

    void Update()
    {
        switch (state)
        {
            // justEnter 做一些第一次进入时候的初始化
            case STATE.OFF:
                if (justEnter)
                {
                    Init();
                    LoadCharaTexture(asset.CharaATex, asset.CharaBTex);
                    justEnter = false;
                }
                break;
            case STATE.TYPING:
                if (justEnter)
                {
                    // 第一次进入typing
                    ShowUI();
                    LoadContent(data.contents[curLine].dialogText, data.contents[curLine].showA, data.contents[curLine].showB);
                    justEnter = false;
                    timerValue = 0;
                }
                CheckTypingFinished();
                // 逐字显示文字
                UpdateContentString();
                break;
            case STATE.PAUSE:
                if (justEnter)
                {
                    justEnter = false;
                }
                break;
            default:break;
        }
    }

    public void startAvg()
    {
        GoToState(STATE.TYPING);
    }

    // 用户点击下一步操作
    public void UserClicked()
    {
        switch (state)
        {
            //case STATE.OFF:
            //    GoToState(STATE.TYPING);
            //    break;
            case STATE.TYPING:
                break;
            case STATE.PAUSE:
                NextLine();
                if (curLine >= data.contents.Count)
                {
                    GoToState(STATE.OFF);
                }
                else
                {
                    GoToState(STATE.TYPING);
                }
                break;
            default: break;
        }
    }

    private void CheckTypingFinished()
    {
        if (state == STATE.TYPING)
        {
            // 整句话已经完全显示，切换状态
            int subLen = (int)Mathf.Floor(timerValue * typingSpeed);
            if (subLen >= targetString.Length)
            {
                GoToState(STATE.PAUSE);
            }
        }
    }

    private void GoToState(STATE next)
    {
        state = next;
        justEnter = true;
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
        uiPanel.ShowCanvas(true);
    }

    private void HideUI()
    {
        uiPanel.ShowCanvas(false);
    }

    private void NextLine()
    {
        curLine++;
    }

    //private void LoadText(string text)
    //{
    //    uiPanel.SetDigText(text);
    //}

    
    private void UpdateContentString()
    {
        // 打字机效果
        timerValue += Time.deltaTime;
        int subLen = (int)Mathf.Floor(timerValue * typingSpeed);
        string tempString = targetString.Substring(0, Mathf.Min(subLen,targetString.Length));
        uiPanel.SetDigText(tempString);
    }
    private void LoadContent(string text,bool showA,bool showB)
    {
        //uiPanel.SetDigText(text);
        targetString = text;
        uiPanel.ShowCharaA(showA);
        uiPanel.ShowCharaB(showB);
    }

    // 加载对应的人物图片
    private void LoadCharaTexture(Texture texA,Texture texB)
    {
        uiPanel.ChangeCharaATex(texA);
        uiPanel.ChangeCharaBTex(texB);
    }
}
