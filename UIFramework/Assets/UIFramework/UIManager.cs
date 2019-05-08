 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager{

    /// <summary>
    /// 单例模式的核心
    /// 1.定义一个静态的对象 在外界访问 在内部构造
    /// 2.构造方法私有化
    /// </summary>
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UIManager();
            return _instance;
        }
        
    }

    private Dictionary<UIPanelType, string> panelPathDict;//存储所有面板Prefab的路径

    private UIManager()
    {
        ParseUIPanelTypeJson();
    }

    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();
        TextAsset textAsset = Resources.Load<TextAsset>("UIPanelType");

        List<UIPanelInfo> panelInfoList = JsonUtility.FromJson<List<UIPanelInfo>>(textAsset.text);
        //panelPathDict = JsonUtility.FromJson<Dictionary<UIPanelType, string>>(textAsset.text);
        //UIPanelType  = JsonUtility.FromJson<List<UIPanelInfo>>(textAsset.text);

        foreach (UIPanelInfo info in panelInfoList)
            panelPathDict.Add(info.panelType, info.path);
    }

    /// <summary>
    /// 测试
    /// </summary>
    public void Test()
    {
        string path;
        panelPathDict.TryGetValue(UIPanelType.Item, out path);
        Debug.Log(path);
    }
}
