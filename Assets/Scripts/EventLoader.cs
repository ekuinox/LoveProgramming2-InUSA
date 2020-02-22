using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using System;

public static class EventLoader
{
    public struct EventData
    {
        public string type; // イベントのタイプ
        public Dictionary<string, string> args; // イベントに与える引数
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

    public static Type GetType(string type)
    {
        switch (type)
        {
            case "decreaseLove":
                return typeof(DecreaseLoveEvent);
            case "gameOver":
                return typeof(GameOverEvent);
            case "gameClear":
                return typeof(GameClearEvent);
        }
        return typeof(DoNothing);
    }

    public static LoveEvent SpawnEventById(string id)
    {
        var eventData = GetById(id);
        var type = GetType(eventData.type);
        var loveEvent = Activator.CreateInstance(type) as LoveEvent;
        loveEvent.init(eventData.args);
        return loveEvent;
    }
}