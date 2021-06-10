using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class ItemPickUp : MonoBehaviour
{

    public Item item;

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
