using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSpaceController : SpaceController
{
    [field: SerializeField] public SpaceController NextSpace { get; private set; }
    public enum NextDirection
    {
        up,
        down,
        left,
        right
    }
    [field: SerializeField] public SpaceController ForwardSpace { get; private set; }
    [field:SerializeField]public NextDirection ForwardSpaceDirection { get; private set; }
    [field: SerializeField] public SpaceController BackSpace { get; private set; }
    [field: SerializeField] public NextDirection BackSpaceDirection { get; private set; }
    [SerializeField] private bool GoingForward;

    [SerializeField] private GameObject upArrow;
    [SerializeField] private GameObject downArrow;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;

    // Start is called before the first frame update
    void Start()
    {
        DisableDirectionGraphics();
        SetDirectionGraphics();
        GoingForward = true;
        NextSpace = ForwardSpace;
    }

    public void PassGoSpace()
    {
        if (GoingForward)
        {
            NextSpace = BackSpace;
        }
        else
        {
            NextSpace = ForwardSpace;
        }
        GoingForward = !GoingForward;
    }

    private void SetDirectionGraphics()
    {
        switch (ForwardSpaceDirection)
        {
            case NextDirection.up:
                upArrow.SetActive(true);
                break;
            case NextDirection.down:
                downArrow.SetActive(true);
                break;
            case NextDirection.right:
                rightArrow.SetActive(true);
                break;
            case NextDirection.left:
                leftArrow.SetActive(true);
                break;
        }
        switch (BackSpaceDirection)
        {
            case NextDirection.up:
                upArrow.SetActive(true);
                break;
            case NextDirection.down:
                downArrow.SetActive(true);
                break;
            case NextDirection.right:
                rightArrow.SetActive(true);
                break;
            case NextDirection.left:
                leftArrow.SetActive(true);
                break;
        }
    }

    private void DisableDirectionGraphics()
    {
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
