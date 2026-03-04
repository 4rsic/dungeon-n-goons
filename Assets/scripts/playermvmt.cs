using UnityEngine;

public class playermvmt : playerStats
{
    //[SerializeField]
    //private float speed = 5f;

    [SerializeField]
    private float mouseSens = 2f;

    private Vector3 moveDir;
    private float rotationY;
    void Update()
    {

        handleMvmt();

    }

    private void handleMvmt()
    {

        float horizontal = Input.GetAxis("Horizontal");

        float vertical = Input.GetAxis("Vertical");

        moveDir = new Vector3(horizontal, 0f, vertical).normalized;

        transform.Translate(moveDir * speed * Time.deltaTime);

    }

    private void handlerotation()
    {

        float mouseX = Input.GetAxis("Mouse X");

        rotationY += mouseX * mouseSens;

        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

    }
}
