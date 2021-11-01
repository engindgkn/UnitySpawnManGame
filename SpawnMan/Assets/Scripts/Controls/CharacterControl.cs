using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterControl : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    Animator animator;
    Rigidbody rb;
    private CharacterController controller;
    float vertical = 1;
    public GameObject canvas;
    public GameObject touchPanel;
    float crossHorizontal = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        controller = gameObject.AddComponent<CharacterController>();
        
    }


    void Update()
    {

         
        Vector3 move = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, vertical * speed);
        controller.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cubes")

        {

            var rigiObject = other.GetComponent<Collider>().gameObject.GetComponent<Rigidbody>();
            var colliderObject = other.GetComponent<Collider>().gameObject.GetComponent<Collider>();

            rigiObject.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ;
            colliderObject.isTrigger = true;
        }
        if (other.gameObject.tag == "EnemyBot")
        {
            if(canvas.active == false)
            {
                if (touchPanel.active == true) { touchPanel.SetActive(false); }
                canvas.SetActive(true);
                GameObject.Find("ReloadButton").GetComponentInChildren<Text>().text = "GameOver Reload!";
            }


            Time.timeScale = 0;
        }
    }
}
