using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject prefabRocket;
    public float velocityMult = 8f;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject rocket;
    public bool aimingMode;
    private Rigidbody rocketRigidbody;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    void OnMouseEnter()
    {
        // print("Launcher:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        print("Launcher:OnMouseExit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
        aimingMode = true;
        rocket = Instantiate(prefabRocket) as GameObject;
        rocket.transform.position = launchPos;
        // rocket.GetComponent<Rigidbody>().isKinematic = true;
        rocketRigidbody = rocket.GetComponent<Rigidbody>();
        rocketRigidbody.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode) return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 rocketPos = launchPos + mouseDelta;
        rocket.transform.position = rocketPos;

        if (Input.GetMouseButtonUp(0)) {
            aimingMode = false;
            rocketRigidbody.isKinematic = false;
            rocketRigidbody.velocity = -mouseDelta * velocityMult;
            rocket = null;
        }
    }
}
