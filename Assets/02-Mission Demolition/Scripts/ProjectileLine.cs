using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{

    static public ProjectileLine S; // singleton

    [Header("Set in Inspector")]
    public float minDist = 0.1f;
    
    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

    void Awake()
    {
        S = this; // set the singleton
        // get the reference to the LineRenderer
        line = GetComponent<LineRenderer>();
        // disable the LineRenderer until it's needed
        line.enabled = false;
        // initialize the points List
        points = new List<Vector3>();
    }

    public GameObject poi
    {
        get {
            return (_poi);
        }
        set {
            _poi = value;
            if (_poi != null) {
                // when _poi is set to something new, it resets everything
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
            }
        }
    }

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
