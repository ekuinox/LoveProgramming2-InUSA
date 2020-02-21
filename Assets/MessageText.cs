using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///  メッセージテキストを弄る
/// </summary>
public class MessageText : MonoBehaviour
{
    /// <summary>
    /// 表示するテキストのid
    /// </summary>
    static public int textId = 0;

    static private Message[] messages;

    private Message message
    {
        get
        {
            return messages[textId];
        }
    }

    void Start()
    {
        LoadJson();
        var textComponent = gameObject.GetComponent<Text>();
        textComponent.text = message.text;
    }

    void Update()
    {
        
    }

    static public void LoadJson(string path = null)
    {
        messages = MessageLoader.GetFromFile(path ?? $"{Application.dataPath}/messages.json").ToArray();
    }
}
