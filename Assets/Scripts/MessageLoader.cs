using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public static class MessageLoader
{
    static List<Message> GetFromJson(string json)
    {
        var messages = JsonUtility.FromJson<Message[]>(json);

        var messageList = new List<Message>();

        foreach (Message message in messages)
        {
            messageList.Add(message);
        }

        return messageList;
    }

    static List<Message> GetFromFile(string filePath)
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
