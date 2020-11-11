using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public RawImage charaAImg;
    public RawImage charaBImg;
    public Image digBgImg;
    public Text digText;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 控制整个画布显示
    public void ShowCanvas(bool isShow)
    {
        canvas.enabled = isShow;
    }


    // 控制主角色显示
    public void ShowCharaA(bool isShow)
    {
        charaAImg.enabled = isShow;
    }
    // 控制副角色显示
    public void ShowCharaB(bool isShow)
    {
        charaBImg.enabled = isShow;
    }
    // 控制对话框背景显示
    public void ShowDigBg(bool isShow)
    {
        digBgImg.enabled = isShow;
    }

    // 控制对话文字显示
    public void ShowDigText(bool isShow)
    {
        digText.enabled = isShow;
    }

    // 设置对话文字
    public void SetDigText(string text)
    {
        digText.text = text;
    }

    // 改变人物图片
    public void ChangeCharaATex(Texture tex)
    {
        charaAImg.texture = tex;
    }

    public void ChangeCharaBTex(Texture tex)
    {
        charaBImg.texture = tex;
    }
}
