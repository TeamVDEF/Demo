using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator m_Controller;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 m_world;
    public Camera m_camera;
    // Use this for initialization
    private void Awake()
    {
       if(m_Controller == null)
       {
            m_Controller = gameObject.GetComponent<Animator>();
       }
        
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInPut();
        Run(Time.deltaTime);
        Rotate();
    }

    private void Attack()
    {
            
    }

    private void CheckInPut()
    {
        if(Input.GetMouseButtonDown(1))
        {
            m_Controller.Play("RightCut");
        }
        if(Input.GetMouseButtonDown(0))
        {
            m_Controller.Play("LeftCut"); 
        }
    }

    private void Run(float deltaTime)
    {
        if(Input.GetKey("a"))
        {
            transform.localPosition = transform.position + Vector3.left * Time.deltaTime; 
        }
        if (Input.GetKey("d"))
        {
            transform.localPosition = transform.position + Vector3.right * Time.deltaTime; 
        }
        if (Input.GetKey("w"))
        {
            transform.localPosition = transform.position + Vector3.back * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.localPosition = transform.position + Vector3.forward * Time.deltaTime;
        }
    }

    private void Rotate()
    {
        Vector3 e = Input.mousePosition;//鼠标的位置  
        m_world = m_camera.ScreenToWorldPoint(e);
        transform.LookAt(m_world); //物体朝向鼠标  
    }
}
