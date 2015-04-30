using UnityEngine;
using System.Collections;

public class ControlsCamera : MonoBehaviour
{
    public bool skipZoomOut = false;

    private bool keepZooming = true;
    private float origZoom;
    private float targetZoom = 1;
    private float zoomFactor = 2;

    // Init
    void Start()
    {
        // Init
        origZoom = transform.localScale.x - 0.05f;      // Assumed local scale is same coords

        // Completely zoom out if wanted to skip
        if (skipZoomOut)
        {
            transform.localScale = new Vector3(1, 1, 1);
            keepZooming = false;
        }
    }

    // Update
    void Update()
    {
        // Zoom out if needed
        if (keepZooming)
        {
            // Calculate delta zoom
            float deltaFromOrig = (transform.localScale.x - origZoom) * zoomFactor;
            float deltaToTarget = (targetZoom - transform.localScale.x) * zoomFactor;
            float delta = Mathf.Min(deltaFromOrig, deltaToTarget);
            
            // Apply zoom
            transform.localScale += new Vector3(delta, delta, delta) * Time.deltaTime;

            // Stop zoom if too much
            if (Mathf.Abs(transform.localScale.x - targetZoom) < 0.01f)
            {
                keepZooming = false;
                transform.localScale = new Vector3(targetZoom, targetZoom, targetZoom);
            }
        }
    }
}
