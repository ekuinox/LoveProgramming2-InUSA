using System;

[Serializable]
public struct Message
{
    public int type;
    public string text; // if Type::Normal
    public string[] selections; // if Type::Selection
}
