using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    // private float distX;
    private float dist;
    [SerializeField] private GameObject player;
    private bool waveable = false;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
               
        // distZ = Mathf.Abs(transform.position.z - player.transform.position.z);

        if (dist <= 15f)
        {
            waveable = true;
        }
        else
        {
            waveable = false;
        }

        if (waveable && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("waving", true);
            Debug.Log(dist);
        }
        else
        {
            anim.SetBool("waving", false);
        }
    }
}
