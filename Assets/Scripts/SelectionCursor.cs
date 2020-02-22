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

    private int selectionLength = 3;
    private string[] selections;

    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentSelected += 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentSelected -= 1;
        }

        // clamp
        if (currentSelected < 0) currentSelected = 0;
        if (currentSelected > selectionLength - 1) currentSelected = selectionLength - 1;
    }

    public void clear()
    {
        currentSelected = 0;
        selections = new string[] { };
    }

    public void setSelections(Message message)
    {
        var n = 0;
        selections = new string[3];
        foreach (var text in message.selections.Keys)
        {
            selections[n++] = text;
        }
    }

    public string getCurrentSelected()
    {
        return selections[currentSelected];
    }
}
