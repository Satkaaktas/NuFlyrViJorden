﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;
using Yarn.Unity;
/*Modified by Björn Andersson && Timmy Alvelöv*/
public class DialogueUI : Yarn.Unity.DialogueUIBehaviour
{
    /// The object that contains the dialogue and the options.
    /** This object will be enabled when conversation starts, and 
     * disabled when it ends.
     */
    public GameObject dialogueContainer;
    [SerializeField]
    Image lastLineBox;

    [SerializeField]
    Text lastLineText;

    [SerializeField]
    KeyCode[] dialogueKeys;

    string lastLine;

    /// The UI element that displays lines
    public Text lineText;

    /// A UI element that appears after lines have finished appearing
    public GameObject continuePrompt;

    /// A delegate (ie a function-stored-in-a-variable) that
    /// we call to tell the dialogue system about what option
    /// the user selected
    private Yarn.OptionChooser SetSelectedOption;

    //public Image characterDisplay;

    /// How quickly to show the text, in seconds per character
    [Tooltip("How quickly to show the text, in seconds per character")]
    public float textSpeed = 0.025f;

    /// The buttons that let the user choose an option
    public List<Button> optionButtons;

    /// Make it possible to temporarily disable the controls when
    /// dialogue is active and to restore them when dialogue ends
    public RectTransform gameControlsContainer;

    TextColorChanger tCC;

    PauseGame pG;

    void Awake()
    {
        // Start by hiding the container, line and option buttons
        pG = FindObjectOfType<PauseGame>();
        tCC = FindObjectOfType<TextColorChanger>();
        if (dialogueContainer != null)
            dialogueContainer.SetActive(false);

        lineText.gameObject.SetActive(false);

        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }

        // Hide the continue prompt if it exists
        if (continuePrompt != null)
            continuePrompt.SetActive(false);
    }

    /// Show a line of dialogue, gradually
    public override IEnumerator RunLine(Yarn.Line line)
    {
        bool skipping = false;
        // Show the text
        lineText.gameObject.SetActive(true);
        if (textSpeed > 0.0f)
        {
            lastLine = line.text;
            // Display the line one character at a time
            var stringBuilder = new StringBuilder();
            foreach (char c in line.text)
            {
                if (c == '¤')
                {
                    tCC.ChangeTextColor("Blue");
                }
                else if (c == '%')
                {
                    tCC.ChangeTextColor("Black");
                }
                else
                {
                    yield return new WaitForSeconds(textSpeed);
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        stringBuilder = new StringBuilder();
                        skipping = true;
                        foreach (char c2 in line.text)
                        {
                            if (c2 != '¤' && c2 != '%')
                            {
                                stringBuilder.Append(c2);
                            }
                        }
                        lineText.text = stringBuilder.ToString();
                        lastLine = stringBuilder.ToString();
                        break;
                    }
                    else
                    {
                        if (c != '#' && c != '¤')
                        {
                            stringBuilder.Append(c);
                        }
                        lineText.text = stringBuilder.ToString();
                        lastLine = stringBuilder.ToString();
                    }
                }
            }
        }
        else
        {
            string finalLine = "";
            // Display the line immediately if textSpeed == 0
            foreach (char c in line.text)
            {
                if (c != '¤' && c != '%')
                {
                    finalLine += c;
                }
            }
            lineText.text = finalLine;
            lastLine = finalLine;
        }
        // Show the 'press any key' prompt when done, if we have one
        if (continuePrompt != null)
            continuePrompt.SetActive(true);

        // Wait for user input
        while (skipping || (Input.GetKeyDown(KeyCode.Space) == false && Input.GetKeyDown(KeyCode.Return) == false && Input.GetKeyDown(KeyCode.KeypadEnter) == false))
        {
            skipping = false;
            yield return null;
        }
        // Hide the text and prompt
        lineText.gameObject.SetActive(false);

        if (continuePrompt != null)
            continuePrompt.SetActive(false);

    }

    /// Show a list of options, and wait for the player to make a selection.
    public override IEnumerator RunOptions(Yarn.Options optionsCollection,
                                            Yarn.OptionChooser optionChooser)
    {
        // Do a little bit of safety checking
        if (optionsCollection.options.Count > optionButtons.Count)
        {
            Debug.LogWarning("There are more options to present than there are" +
                             "buttons to present them in. This will cause problems.");
        }
        lastLineBox.gameObject.SetActive(true);
        lastLineText.text = lastLine;
        // Display each option in a button, and make it visible
        int i = 0;
        foreach (var optionString in optionsCollection.options)
        {
            optionButtons[i].gameObject.SetActive(true);
            optionButtons[i].GetComponentInChildren<Text>().text = optionString;
            i++;
        }

        // Record that we're using it
        SetSelectedOption = optionChooser;

        // Wait until the chooser has been used and then removed (see SetOption below)
        while (SetSelectedOption != null)
        {
            yield return null;
        }

        // Hide all the buttons
        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }
        lastLineBox.gameObject.SetActive(false);
    }

    /// Called by buttons to make a selection.
    public void SetOption(int selectedOption)
    {

        // Call the delegate to tell the dialogue system that we've
        // selected an option.
        SetSelectedOption(selectedOption);

        // Now remove the delegate so that the loop in RunOptions will exit
        SetSelectedOption = null;
    }

    /// Run an internal command.
    public override IEnumerator RunCommand(Yarn.Command command)
    {
        // "Perform" the command
        Debug.Log("Command: " + command.text);

        yield break;
    }

    /// Called when the dialogue system has started running.
    public override IEnumerator DialogueStarted()
    {
        Debug.Log("Dialogue starting!");
        pG.CanPause = false;
        // Enable the dialogue controls.
        if (dialogueContainer != null)
            dialogueContainer.SetActive(true);

        // Hide the game controls.
        if (gameControlsContainer != null)
        {
            gameControlsContainer.gameObject.SetActive(false);
        }
        yield break;
    }

    /// Called when the dialogue system has finished running.
    public override IEnumerator DialogueComplete()
    {
        pG.CanPause = true;
        GetComponent<DialogueRunner>().CurrentAgent = null;
        Debug.Log("Complete!");

        // Hide the dialogue interface.
        if (dialogueContainer != null)
            dialogueContainer.SetActive(false);

        // Show the game controls.
        if (gameControlsContainer != null)
        {
            gameControlsContainer.gameObject.SetActive(true);
        }
        yield break;
    }

}