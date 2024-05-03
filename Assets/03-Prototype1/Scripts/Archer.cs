using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject               prefabArrow;
    public GameObject               prefabTarget;
    public float                    velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject               launchPoint;
    public Vector3                  launchPos;
    public GameObject               targetLocation;
    public Vector3                  targetLoc;
    public GameObject               arrow;
    public GameObject               target;
    public bool                     aimingMode;
    private Rigidbody               arrowRigidbody;
    private Rigidbody               targetRigidbody;



    void Awake() {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;

        Transform tLocTrans = transform.Find("TargetLocation");
    }

    void OnMouseEnter() {
        //print("Archer:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit() {
        //print("Archer:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    // Start is called before the first frame update
    void OnMouseDown() {
        aimingMode = true;
        arrow = Instantiate(prefabArrow) as GameObject;
        arrow.transform.position = launchPos;
        arrowRigidbody = arrow.GetComponent<Rigidbody>();
        arrowRigidbody.isKinematic = true;
    }

    void Update() {
        // If archer is not in aimingMode, don't run this code
        if (!aimingMode) return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D-launchPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *=maxMagnitude;
        }

        Vector3 arrowPos = launchPos + mouseDelta;
        arrow.transform.position = arrowPos;

        if (Input.GetMouseButtonUp(0)) {
            aimingMode = false;
            arrowRigidbody.isKinematic = false;
            arrowRigidbody.velocity = -mouseDelta * velocityMult;
            arrow = null;
        }
    }
}