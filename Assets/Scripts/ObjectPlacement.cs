using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectPlacement : MonoBehaviour
{
    public GameObject objectPrefab;
    public ARRaycastManager raycastManager;

    private GameObject _spawnedObject;

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            Debug.Log("touched screen");

            raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if(hits.Count > 0)
            {
                if(_spawnedObject == null)
                {
                    _spawnedObject = Instantiate(objectPrefab, hits[0].pose.position, hits[0].pose.rotation);
                }
                else
                {
                    _spawnedObject.transform.SetPositionAndRotation(hits[0].pose.position, hits[0].pose.rotation);
                }
            }
        }
    }
}
