using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    Dialogue _current;

    [SerializeField] RuntimeData _runtimeData;

    int _slideIndex = 0;

    void Awake()
    {

        GameEvents.DialogueFinished += OnDialogueFinished;

        GameEvents.DialogueInitiated += OnDialogueInitiated;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (_slideIndex < _current.DialogueSlides.Length - 1)
            {

                _slideIndex++;

                showSlide();

            }
            else
            {

                GameEvents.InvokeDialogueFinished();

            }

        }
    }

    void OnDialogueInitiated(object sender, DialogueEventArgs e)
    {

        _runtimeData.currentState = GameplayState.InDialogue;
        _current = e.DialoguePayload;
        _slideIndex = 0;
        showSlide();
        loadAvatar();
        GetComponent<Canvas>().enabled = true;

    }

    void OnDialogueFinished(object sender, EventArgs e)
    {

        GetComponent<Canvas>().enabled = false;

        _runtimeData.currentState = GameplayState.FreeWalk;

    }

    void showSlide()
    {

        GameObject textObj = transform.Find("DialogueText").gameObject;

        TextMeshProUGUI text = textObj.GetComponent<TextMeshProUGUI>();

        text.text = _current.DialogueSlides[_slideIndex];

    }

    void loadAvatar()
    {

        GameObject avatar = transform.Find("Avatar").gameObject;

        avatar.GetComponent<RawImage>().texture = _current.avatar;

    }

}
