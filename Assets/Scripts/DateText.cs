using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateText : MonoBehaviour
{
    private Text date;

    // Start is called before the first frame update
    void Start()
    {
        date = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        date.text = Manager.GetPassedDay().ToString();
    }
}
