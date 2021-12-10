using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{

    [SerializeField] Dialogue _NPC_log;
    [SerializeField] Dialogue _NPC_correct;
    [SerializeField] Dialogue _NPC_wrong;
    [SerializeField] GameObject _answer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {

        GameEvents.InvokeDialogueInitiated(_NPC_log);

    }

    public void Selected(GameObject food)
    {

        if (food == _answer)
        {

            Debug.Log("Work");

            GameEvents.InvokeDialogueInitiated(_NPC_correct);

        }
        else
        {

            GameEvents.InvokeDialogueInitiated(_NPC_wrong);

        }

        Destroy(food);

    }
}
