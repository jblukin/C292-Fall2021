using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intializer : MonoBehaviour
{

    [SerializeField] RuntimeData _runtimeData;

    [SerializeField] Dialogue _startingDialogue;

    void Awake()
    {
        _runtimeData.currentFood = "";

        _runtimeData.currentState = GameplayState.InDialogue;

    }

    void Start()
    {

        GameEvents.InvokeDialogueInitiated(_startingDialogue);

    }

}
