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

    [SerializeField]
    private Background background;

    [SerializeField]
    private Character character;

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
        if (!message.isNormal)
        {
            foreach (var text in message.selections.Keys)
            {
                textComponent.text += $"{text}\n";
            }
            cursor.setSelections(message);
            cursor.setActive(true);
        }
        else
        {
            textComponent.text = message.text;
            cursor.setActive(false);
        }

        // 画像セット
        background.setTexture(message.backgroundImageType);
        character.setTexture(message.characterImageType);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (message.type)
            {
                case Message.MessageType.Normal:
                    Next(message.nextId);
                    break;
                case Message.MessageType.Selection:
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
                    break;
                case Message.MessageType.GameClear:
                    {
                        var gameClearEvent = new GameClearEvent();
                        gameClearEvent.init(new Dictionary<string, string>());
                        gameClearEvent.run(this);
                    }
                    break;
                case Message.MessageType.GameOver:
                    {
                        var gameOverEvent = new GameOverEvent();
                        gameOverEvent.init(new Dictionary<string, string>());
                        gameOverEvent.run(this);
                    }
                    break;
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
