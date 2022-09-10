using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimingSMInteractable 
{
    int InteractableStateIndex { get; }
    int OldStateIndex { set; get; }
}
