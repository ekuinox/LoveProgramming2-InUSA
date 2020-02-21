﻿using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public static class EventLoader
{
    public struct EventData
    {
        int type; // イベントのタイプ
        Dictionary<string, string> args; // イベントに与える引数
    }

    static Dictionary<string, EventData> eventDataDict;

    public static Dictionary<string, EventData> GetFromJson(string json)
    {
        eventDataDict = JsonConvert.DeserializeObject<Dictionary<string, EventData>> (json);
        return eventDataDict;
    }

    public static Dictionary<string, EventData> GetFromFile(string filePath)
    {
        try
        {
            var json = File.ReadAllText(filePath);
            return GetFromJson(json);
        }
        catch
        {
            return new Dictionary<string, EventData>();
        }
    }

    public static EventData GetById(string id)
    {
        if (eventDataDict.ContainsKey(id))
        {
            return eventDataDict[id];
        }
        Debug.Log("[EventLoader#GetById] Not found id");
        return new EventData();

    }
}