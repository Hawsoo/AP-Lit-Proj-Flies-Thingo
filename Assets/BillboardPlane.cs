using UnityEngine;
using System.Collections;

public class BillboardPlane : MonoBehaviour
{
    public static bool canSenseForInput = true;

    public Material regMaterial;
    public Material hovMaterial;

	// Update
	void Update()
	{
        // Billboard
        transform.rotation = Camera.main.transform.rotation;

        // Check raycasting
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, 500)
            && canSenseForInput)
        {
            //Debug.Log("Hit: " + rayHit.collider.tag);
            if (rayHit.collider.gameObject == gameObject)
            {
                // Update material
                GetComponent<Renderer>().material = hovMaterial;

                // Check if should click
                if (Input.anyKeyDown)
                {
                    Debug.Log("I was hit!");
                    canSenseForInput = false;
                    //infoPanel.SetActive(true);
                }
            }
        }
        else
        {
            // Update material
            GetComponent<Renderer>().material = regMaterial;
        }
	}
}