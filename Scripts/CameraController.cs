using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed_move = 3.0f;
    private float speed_rota = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveObj();
        onClick();
    }
    private void moveObj()
    {
        float keyH = Input.GetAxis("Horizontal");
        float keyV = Input.GetAxis("Vertical");
        keyH = keyH * Time.deltaTime * speed_move;
        keyV = keyV * Time.deltaTime * speed_move;

        transform.Translate(Vector3.right * keyH);
        transform.Translate(Vector3.forward * keyV);
    }
    public void onClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if(hitObject.CompareTag("Area")) 
                    this.transform.LookAt(hit.transform.position);
                }
        }
    }
}
