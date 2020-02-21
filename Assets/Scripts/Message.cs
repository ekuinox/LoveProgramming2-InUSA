using System;

namespace Assets.Scripts
{
    [Serializable]
    struct Message
    {
        [Serializable]
        public enum Type
        {
            Normal,
            Selection,
        }

        public Type type;
        public string text; // if Type::Normal
        public string[] selections; // if Type::Selection
    }
}
