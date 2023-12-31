using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.UI;
using System;

public class Console : MonoBehaviour
{
    [SerializeField] private bool consoleIsActivatedByTheUser = false;
    [SerializeField] private GameObject console;
    [SerializeField] private bool consoleActivated;
    [SerializeField] private TMPro.TMP_Text backgroundText;
    [SerializeField] private TMPro.TMP_InputField inputText;
    [SerializeField] CanvasScript canvasScript;

    public delegate void TemplateMethod();

    public Dictionary<string, TemplateMethod> allCommands = new Dictionary<string, TemplateMethod>();

    private void Start()
    {
        RegisterCommand("cls", Clear);
        RegisterCommand("clear", Clear);
        RegisterCommand("help", Help);
        Write("Use with caution!\n");
    }

    private void Update()
    {
        if (consoleActivated)
        {
            inputText.Select();
        }
    }

    public void DevConsoleEnabledByTheUser()
    {
        if (!consoleIsActivatedByTheUser)
        {
            consoleIsActivatedByTheUser = true;
        }
        else
        {
            consoleIsActivatedByTheUser = false;
        }
    }

    public void RegisterCommand(string commandName, TemplateMethod command)
    {
        allCommands.Add(commandName, command);
    }

    public void SendToConsole()
    {
        if (consoleActivated)
        {
            if(allCommands.ContainsKey(inputText.text))
            {
                try
                {
                    allCommands[inputText.text].Invoke();
                }
                catch(Exception error)
                {
                    Write("Error " + error.Message + "\n\n" + error.StackTrace);
                }
            }
            inputText.text = "";
        }
    }
    public void ActivateConsole()
    {
        if (consoleIsActivatedByTheUser)
        {
            canvasScript.CallPause();
            if (consoleActivated == false)
            {
                console.SetActive(true);
                consoleActivated = true;
            }
            else
            {
                console.SetActive(false);
                consoleActivated = false;
            }
        }
    }

    public void Write(string txt)
    {
        backgroundText.text += txt;
    }

    public void Clear()
    {
        backgroundText.text = "";
    }

    public void Help()
    {
        backgroundText.text += "\nYou can use 'clear' for clear the console!";
    }
}