using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [field: SerializeField] public Vector2 MovementInput { get; private set; }
    [field: SerializeField] public bool AcceptanceInput { get; private set; }
    // Start is called before the first frame update

    public void OnMove(InputValue value)
    {
        //SetMoveInput(value.Get<Vector2>().normalized);
        Vector2 sourceVector = value.Get<Vector2>();
        if (sourceVector.x > 0.5f && sourceVector.y > 0.5f) sourceVector = new Vector2(1, 0);
        else if (sourceVector.x < -0.5f && sourceVector.y < -0.5f) sourceVector = new Vector2(-1, 0);
        //
        if (sourceVector.x < -0.5f && sourceVector.y > 0.5f) sourceVector = new Vector2(0, 1);
        else if (sourceVector.x > 0.5f && sourceVector.y < -0.5f) sourceVector = new Vector2(0, -1);
        SetMoveInput(sourceVector);
    }

    public void OnAccept(InputValue value)
    {
        SetAcceptanceInput(value.isPressed);
    }

    private void SetAcceptanceInput(bool newValue)
    {
        AcceptanceInput = newValue;
    }

    private void SetMoveInput(Vector2 newVector)
    {
        MovementInput = newVector;
    }
}
