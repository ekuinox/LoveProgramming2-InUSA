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
        LoadMessage();
    }

    void LoadMessage()
    {
        var textComponent = gameObject.GetComponent<Text>();
        textComponent.text = "";
        if (message.type == 1)
        {
            foreach (var text in message.selections.Keys)
            {
                textComponent.text += $"{text}\n";
            }
            cursor.setSelections(message);
        }
        else
        {
            textComponent.text = message.text;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (message.isNormal)
            {
                var nextId = message.nextId;
                if (nextId < 0)
                {
                    // todo マップに戻る
                    return;
                }

                textId = nextId;
                LoadMessage();
            }
            else
            {
                var selected = cursor.getCurrentSelected();
                var eventId = message.selections[selected];
                var loveEvent = EventLoader.SpawnEventById(eventId);
                loveEvent.run();
            }
        }
    }

    static public void LoadJson(string path = null)
    {
        messages = MessageLoader.GetFromFile(path ?? $"{Application.dataPath}/messages.json").ToArray();
    }
}
