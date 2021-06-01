using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracking : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public List<GameObject> prefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private void Awake()
    {
        foreach (GameObject prefab in prefabs)
        {
            GameObject instantiatedPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            instantiatedPrefab.SetActive(false);

            instantiatedPrefab.name = prefab.name;

            spawnedPrefabs.Add(instantiatedPrefab.name, instantiatedPrefab);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage addedImage in eventArgs.added)
        {
            GameObject obj = spawnedPrefabs[addedImage.referenceImage.name];
            obj.SetActive(true);
            obj.transform.SetPositionAndRotation(addedImage.transform.position, addedImage.transform.rotation);

            Debug.Log(addedImage.name);
        }

        foreach (ARTrackedImage updatedImage in eventArgs.updated)
        {
            GameObject obj = spawnedPrefabs[updatedImage.referenceImage.name];

            if (updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                }

                obj.transform.SetPositionAndRotation(updatedImage.transform.position, updatedImage.transform.rotation);
            }
            else
            {
                obj.SetActive(false);
            }
        }

        foreach (ARTrackedImage removedImage in eventArgs.removed)
        {
            GameObject obj = spawnedPrefabs[removedImage.referenceImage.name];
            obj.SetActive(false);
        }
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }
}
