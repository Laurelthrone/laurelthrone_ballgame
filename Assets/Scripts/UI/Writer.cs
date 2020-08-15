﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Writer : MonoBehaviour
{
    protected TextWriter processor;
    protected Text textfield;

    protected bool coroutineActive = false;
    protected int currentLine = 0;

    protected void prepForWriting()
    {
        textfield = gameObject.GetComponent<Text>();
        textfield.text = "";
        processor = new TextWriter("");
    }

    protected IEnumerator WriteLineAsChars(float waittime, string textsound)
    {
        yield return new WaitForSeconds(waittime);
        textfield.text = "";
        for (int i = 0; i < processor.getLength(); i++)
        {
            char write = processor.returnText();
            textfield.text += write;
            if (write != ' ') Sounder.PlaySound(textsound);
            yield return new WaitForSeconds(.1f);
        }
        coroutineActive = false;
    }
}