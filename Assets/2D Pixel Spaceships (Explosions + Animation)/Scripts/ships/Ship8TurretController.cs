using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllShips
{
    public class Ship8TurretController : MonoBehaviour {

        public Transform turret;
        public float deltaAngle;

        Camera mainCamera;

	    // Use this for initialization
	    void Start () {
            mainCamera = Camera.main;
        }
	
	    // Update is called once per frame
	    void Update () {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Tools.TraceTarget(turret, mousePos, deltaAngle);
        }
    }

}
