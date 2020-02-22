using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 選択肢をやるためのカーソル
/// </summary>
public class SelectionCursor : MonoBehaviour
{
    [SerializeField] private int currentSelected = 0;
    [SerializeField] private int padding = 50;
    private Vector3 initPosition;

    private string[] selections;


    private void Start()
    {
        initPosition = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentSelected += 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentSelected -= 1;
        }

        // clamp
        if (currentSelected < 0) currentSelected = 0;
        if (currentSelected >= selections.Length) currentSelected = selections.Length - 1;
        gameObject.transform.SetPositionAndRotation(initPosition + new Vector3(0, - padding * currentSelected, 0), Quaternion.identity);
    }

    public void clear()
    {
        currentSelected = 0;
        selections = new string[] { };
    }

    public void setSelections(Message message)
    {
        var n = 0;
        selections = new string[message.selections.Count];
        foreach (var text in message.selections.Keys)
        {
            selections[n++] = text;
        }
    }

    public string getCurrentSelected()
    {
        return selections[currentSelected];
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
        if (!active)
        {
            clear();
        }
    }
}
