using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [field: SerializeField] public Player Player { get; private set; }
    public SpaceController startingSpace;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        Player.InitializePlayer(this, startingSpace);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
