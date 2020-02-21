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

    [SerializeField] private SelectionCursor cursor;

    void Start()
    {
        LoadJson();
        var textComponent = gameObject.GetComponent<Text>();
        textComponent.text = "";
        switch (message.type)
        {
            // 選択肢つき
            case 1:
                {
                }
                break;
            default:
                {
                    textComponent.text = message.text;
                }
                break;
        }
        textComponent.text = message.text;
        // 選択肢のあるやつ
        if (message.type == 1)
        {
            var selections = message.selections.Keys;
            selections.
        }
    }

    void Update()
    {
        
    }

    static public void LoadJson(string path = null)
    {
        messages = MessageLoader.GetFromFile(path ?? $"{Application.dataPath}/messages.json").ToArray();
    }
}
