using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FirepointTargetable : MonoBehaviour
{
    public abstract void EnableTargetableAction();
    public abstract void PlayerFPAction(Transform currentFirepoint);
}
