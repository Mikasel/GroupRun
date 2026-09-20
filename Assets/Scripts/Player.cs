using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public Camera Camera;
    public bool isLastTrigger;
    public GameObject TargetLocation;

    private void FixedUpdate()
    {
        if (!isLastTrigger)
            transform.Translate(Vector3.forward * .5f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLastTrigger)
        {
            transform.position = Vector3.Lerp(transform.position, TargetLocation.transform.position, .015f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position,
                        new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
                }

                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position,
                        new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("addition") || other.CompareTag("subtraction") || other.CompareTag("multiplication") ||
            other.CompareTag("division"))
        {
            gameManager.SpawnPlayer(other.tag, int.Parse(other.name), other.transform);
        }
        else if (other.CompareTag("lastTrigger"))
        {
            Camera.GetComponent<Camera>().isLastTrigger = true;
            gameManager.TriggerEnemy();
            isLastTrigger = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("sidePost") || collision.gameObject.CompareTag("spikeBox") || collision.gameObject.CompareTag("fanSpike"))
        {
            if (transform.position.x > 0)
            {
                transform.position =
                    new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position =
                    new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            }
        }
        if (collision.gameObject.CompareTag("middlePost"))
        {
            if (transform.position.x > 0)
            {
                transform.position =
                    new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position =
                    new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            }
        }
    }
}