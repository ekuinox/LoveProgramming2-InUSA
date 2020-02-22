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

    static private bool isDay4 = false;


    [SerializeField]
    private Background background;

    [SerializeField]
    private Character character;

    private Message message
    {
        get
        {
            if (Manager.messages.Length <= textId)
            {
                Debug.Log($"messages index error textId => {textId}");
            }
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
        Debug.Log($"LoadMessage id => {textId}");
        var textComponent = gameObject.GetComponent<Text>();
        textComponent.text = "";
        if (message.type == Message.MessageType.Selection)
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
            // 三日目
            if (Manager.GetPassedDay() == 3)
            {
                Next(23);
                Manager.ForwardDay();
                isDay4 = true;
                return;
            }
            if (!isDay4)
            {
                Manager.ForwardDay();
            } else
            {
                isDay4 = false;
            }
            if (!SceneController.LoadScene(SceneController.lastState))
            {
                // 失敗時
                LoadMessage();
            }
        }
    }
}
