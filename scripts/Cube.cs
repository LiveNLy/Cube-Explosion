using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action ChangingState;

    private void OnMouseUpAsButton()
    {
        ChangingState?.Invoke();
    }
}
