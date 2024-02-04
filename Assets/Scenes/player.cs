using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float camRotation = 0f;
    [SerializeField] private Transform CamTransform;
    [SerializeField] private CharacterController CC;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera control
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        camRotation -= mouseY;
        camRotation = Mathf.Clamp(camRotation, -90f, 90f);
        CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));
        transform.localRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseX, 0f));

        // Movement control
        Vector3 movement = Vector3.zero;

        float ForwardMovement = Input.GetAxis("Vertical") * Time.deltaTime * 10;
        float SideMovement = Input.GetAxis("Horizontal") * Time.deltaTime * 10;

        movement += (transform.forward * ForwardMovement) + (transform.right * SideMovement);

        CC.Move(movement);

        if (ForwardMovement != 0 || SideMovement != 0)
        {
            anim.SetFloat("speed", 1);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }

        if(Input.GetMouseButton(0))
        {
            anim.SetBool("wave", true);
        }
        else
        {
            anim.SetBool("wave", false);
        }
    }
}
