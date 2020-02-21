using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class MessageLoader
{
    [System.Serializable]
    struct Messages
    {
        public Message[] messages;
    }

    public static List<Message> GetFromJson(string json)
    {
        var messages = JsonUtility.FromJson<Messages>(json);

        var messageList = new List<Message>();

        foreach (Message message in messages.messages)
        {
            messageList.Add(message);
        }

        return messageList;
    }

    public static List<Message> GetFromFile(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);
            return GetFromJson(json);
        }
        catch {
            return new List<Message>();
        }
    }
}
