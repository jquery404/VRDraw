using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandController : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;

    // drawing ......
    public GameObject linePrefab;
    Line activeLine;
    bool _startDrawing;


    private InputDevice targetDevice;
    private GameObject spawnedController;
    private Vector3 _controllerPosition = Vector3.zero;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        // foreach(var item in devices){
        //     Debug.Log(item.name + item.characteristics);
        // }

        if(devices.Count > 0){
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);

            if(prefab){
                spawnedController = Instantiate(prefab, transform);
            }else{
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }
            

    }

    void Update()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue){
            Debug.Log("primary");
        }
            

        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue == 1){
            Debug.Log("trigger");
            
            if(_startDrawing == false)
            {
                GameObject newLine = Instantiate(linePrefab);
                activeLine = newLine.GetComponent<Line>();
                _startDrawing = true;
            }

        } else {
            activeLine = null;
            _startDrawing = false;
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero){
            Debug.Log("touchpad " + primary2DAxisValue);
        }


        if(activeLine != null)
        {
            if(targetDevice.TryGetFeatureValue(CommonUsages.devicePosition, out _controllerPosition) && _controllerPosition != Vector3.zero && _startDrawing)
            {
                activeLine.UpdateLine(_controllerPosition);    
            }            
            
        }
            

    }
}
