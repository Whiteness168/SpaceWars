using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AllShips
{

    public class Ship7Controller : MonoBehaviour {

        public Transform turretLeft;
        public Transform turretRight;
        public int deltaAngle;

        [Space(20)]
        public GameObject childShipPrefab;
        public int childCount;
        public float delayInLaunch;
        public Transform childLeftStart;
        public Transform childRightStart;

        Camera mainCamera;
        Animator animator;


	    // Use this for initialization
	    void Start () {
            mainCamera = Camera.main;
            animator = GetComponent<Animator>();
	    }

        public void GateOpened()
        {
            StartCoroutine(LaunchChildShips());
        }

        IEnumerator LaunchChildShips()
        {
            for (int index = 0; index < childCount; index++)
            {
                Instantiate(childShipPrefab, 
                    ((index % 2 == 0) ? childLeftStart.position : childRightStart.position), 
                    Quaternion.identity);
                yield return new WaitForSeconds(delayInLaunch);
            }
            animator.SetBool("open", false);
        }

	    // Update is called once per frame
	    void Update () {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Tools.TraceTarget(turretLeft, mousePos, deltaAngle);
            Tools.TraceTarget(turretRight, mousePos, deltaAngle);
        }
    }
}
