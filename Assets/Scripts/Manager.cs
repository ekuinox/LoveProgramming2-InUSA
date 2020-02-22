﻿using UnityEngine;

public static class Manager
{
    private static bool isLoaded = false;

    public static Message[] messages;

    public static int unityLovePoint = 0;

    public static int ue4LovePoint = 0;

    public static void Load(bool isForce = false)
    {
        if (!isLoaded || isForce)
        {
            messages = MessageLoader.GetFromFile($"{Application.dataPath}/messages.json").ToArray();
            EventLoader.GetFromFile($"{Application.dataPath}/events.json");
            isLoaded = true;
        }
    }

}