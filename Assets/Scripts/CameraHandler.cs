using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public GameObject newCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //create a ray cast and set it to the mouses cursor position
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        ////draw invisible ray cast/vector
        //        //Debug.DrawLine(ray.origin, hit.point);
        //        ////log hit area to the console
        //        newCamera.transform.position = new Vector3(hit.point.x, newCamera.transform.position.y, hit.point.z) ;
        //    }
        //}
    }
}
