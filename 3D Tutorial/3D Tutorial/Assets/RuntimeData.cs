using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "New RuntimeData")]

public class RuntimeData : ScriptableObject
{
   
    public string currentFood;

    public GameplayState currentState;
    
}
