using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public Transform space1;
    public Transform space2;

    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (space1 == null || space2 == null) Destroy(gameObject);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        Vector3[] positions = { space1.position, space2.position };
        lineRenderer.SetPositions(positions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
