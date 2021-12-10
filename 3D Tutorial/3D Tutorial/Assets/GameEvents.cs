using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DialogueEventArgs : EventArgs
{

    public Dialogue DialoguePayload;

}

public static class GameEvents
{

    public static event EventHandler<DialogueEventArgs> DialogueInitiated;

    public static event EventHandler DialogueFinished;

    public static void InvokeDialogueInitiated(Dialogue d)
    {

        DialogueInitiated(null, new DialogueEventArgs { DialoguePayload = d});

    }


    public static void InvokeDialogueFinished()
    {

        DialogueFinished(null, EventArgs.Empty);

    }
}
