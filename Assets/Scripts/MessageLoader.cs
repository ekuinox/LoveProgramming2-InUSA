using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public static class MessageLoader
{
    public static List<Message> GetFromJson(string json)
    {
        try
        {
            return JsonConvert.DeserializeObject<List<Message>>(json);
        }
        catch (JsonException exception)
        {
            Debug.Log($"[MessageLoader#GetFromJson] error {exception.Message}");
            return new List<Message>();
        }
    }

    public static List<Message> GetFromFile(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);
            return GetFromJson(json);
        }
        catch {
            Debug.Log("[MessageLoader#GetFromFile] error");
            return new List<Message>();
        }
    }
}
