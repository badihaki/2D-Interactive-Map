using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpaceConroller : SpaceController
{
    [field: SerializeField] public SpaceController nextTopSpace { get; private set; }
    [field: SerializeField] public SpaceController nextBottomSpace { get; private set; }
    [field: SerializeField] public SpaceController nextLeftSpace { get; private set; }
    [field: SerializeField] public SpaceController nextRightSpace { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
