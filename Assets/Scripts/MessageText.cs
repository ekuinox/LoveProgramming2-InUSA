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
            return Manager.messages[textId];
        }
    }

    [SerializeField] private SelectionCursor cursor;

    void Start()
    {
        Manager.Load();
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
            cursor.gameObject.SetActive(true);
        }
        else
        {
            textComponent.text = message.text;
            cursor.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (message.isNormal)
            {
                Next(message.nextId);
            }
            else
            {
                var selected = cursor.getCurrentSelected();
                var eventIds = message.selections[selected].Split(',');
                var isIgnoredNext = false;
                foreach (var eventId in eventIds)
                {
                    var loveEvent = EventLoader.SpawnEventById(eventId);
                    loveEvent.run(this);
                    if (loveEvent.GetType() == typeof(ChangeNextMessage))
                    {
                        isIgnoredNext = true;
                    }
                }
                if (!isIgnoredNext)
                {
                    Next(message.nextId);
                }
            }
        }
    }

    public void Next(int index = -1)
    {
        if (index > 0)
        {
            textId = index;
            LoadMessage();
        }
        else
        {
            // マップに戻る
        }
    }
}
