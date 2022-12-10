using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 dir;
    private Rigidbody rb;

    [SerializeField] private float rX;
    [SerializeField] private float rY;

    [SerializeField] private Transform camPivot;
    [SerializeField] private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);

        rX = Mathf.Lerp(rX, Input.GetAxisRaw("Mouse X") * 2, 100 * Time.deltaTime);
        rY = Mathf.Clamp(rY - (Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -30, 30);

        player.Rotate(0, rX, 0, Space.World);
        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(rY * 2, player.eulerAngles.y, 0), 100 * Time.deltaTime);

        camPivot.position = Vector3.Lerp(camPivot.position, player.position, 10 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * 10 * Time.fixedDeltaTime);
    }
}
