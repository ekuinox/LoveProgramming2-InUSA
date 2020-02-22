using System;
using System.Collections.Generic;

[Serializable]
public struct Message
{
    public int id;
    public int nextId;
    public int type;
    public string text; // if Type::Normal
    public Dictionary<string, string> selections; // if Type::Selection selection: eventId
    public bool isNormal
    {
        get
        {
            return type != 1;
        }
    }
}
