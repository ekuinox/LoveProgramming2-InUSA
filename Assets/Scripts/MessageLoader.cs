using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public static class MessageLoader
{
    public static List<Message> GetFromJson(string json)
    {
        return JsonConvert.DeserializeObject<List<Message>>(json);
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
