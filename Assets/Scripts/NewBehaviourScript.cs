using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class NewBehaviourScript : MonoBehaviour
{
    [Serializable]
    struct Messages
    {
        public Message[] messages;
    }
    // Start is called before the first frame update
    void Start()
    {
        var messages = MessageLoader.GetFromFile(Application.dataPath + "/messages.json");
        messages.ForEach(message =>
        {
            Debug.Log($"type => {message.type}, text => {message.text}");
        });

        {
            var eventsData = EventLoader.GetFromFile(Application.dataPath + "/events.json");
            var decreaseLove = EventLoader.SpawnEventById("decreaseLove");
            decreaseLove.run(null);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
