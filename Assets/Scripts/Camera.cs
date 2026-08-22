using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 target_offset;

    void Start()
    {
        target_offset = transform.position - target.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + target_offset, .125f);
    }
}