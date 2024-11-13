using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{
    private Vector2 direction, pointer; 
    private Rigidbody rb;
    [SerializeField] private float speed, sense;
    private Vector3 camRot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (transform.forward * direction.y + transform.right * direction.x)*speed;
        transform.eulerAngles += new Vector3(0,pointer.x*sense,0);
        camRot.x -= pointer.y*sense;
        camRot.x = Mathf.Clamp(camRot.x, -90, 90);
        Camera.main.transform.localEulerAngles = camRot;
    }

    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        pointer = context.ReadValue<Vector2>();
    }
}
