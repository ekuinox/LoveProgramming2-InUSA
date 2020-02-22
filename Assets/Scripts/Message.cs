using System;
using System.Collections.Generic;

[Serializable]
public struct Message
{
    public enum MessageType
    {
        Normal,
        Selection,
        GameClear,
        GameOver,
    };

    public int id;
    public int nextId;
    public MessageType type;
    public string text; // if Type::Normal
    public Dictionary<string, string> selections; // if Type::Selection selection: eventId
    public int backgroundImageType;
    public Character.TextureType characterImageType;
    public bool isNormal
    {
        get
        {
            return type == MessageType.Normal;
        }
    }
}
