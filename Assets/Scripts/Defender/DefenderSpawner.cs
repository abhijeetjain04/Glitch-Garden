using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;

    private GameObject defenderParent;
    private StarDisplay stardisplay;

	void Start ()
    {
        defenderParent = GameObject.Find("Defenders");
        stardisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
	}
	
    void OnMouseDown()
    {
        if (ButtonS.selectedDefender)
        {
            Vector2 rawPos = calculateWorldPointOfMouseClisck();
            Vector2 roundedPos = SnapToGrid(rawPos);

            GameObject defenders = ButtonS.selectedDefender;
            int defenderCost = defenders.GetComponent<Defender>().starCost;

            if (stardisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
                SpawnDefender(roundedPos, defenders);
            else
                Debug.Log("Insufficient star to spawn"); 
        } 
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defenders)
    {
        GameObject newDef = Instantiate(defenders, roundedPos, Quaternion.identity) as GameObject;
        newDef.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float roundX =  Mathf.RoundToInt(rawWorldPos.x);
        float roundY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(roundX, roundY);
    }

    Vector2 calculateWorldPointOfMouseClisck()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
        Vector2 worldpos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldpos ;
    }
}
