using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    public GameObject portal;
    public Camera arCamera;

    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    private ARAnchorManager _arAnchorManager;
    private List<ARAnchor> _anchors;
    private GameObject _spawnedObject;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool existARPortal = false;

    private void Start()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arAnchorManager = GetComponent<ARAnchorManager>();

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (Constants.instance.firstTime)
        {
            InstancePortal();
        }
        else
        {
            if (!existARPortal)
            {
                Instantiate(portal, arCamera.transform.position+ new Vector3(0,0,4.87f), Quaternion.identity);
                existARPortal = true;
            }
        }

    }

    private void InstancePortal()
    {
        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            ARAnchor anchor = _arAnchorManager.AddAnchor(new Pose(hitPose.position, hitPose.rotation));
            if (anchor != null)
            {
                {
                    if (_spawnedObject == null)
                    {
                        _spawnedObject = Instantiate(portal, hitPose.position, hitPose.rotation,anchor.transform);
                        _anchors.Add(anchor);
                    }
                    else
                    {
                        _spawnedObject.transform.position = hitPose.position;
                        _spawnedObject.transform.rotation = hitPose.rotation;
                    }
                }
            }
            
        }
    }
    
}
