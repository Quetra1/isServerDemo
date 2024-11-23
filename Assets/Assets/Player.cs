using Mirror;
using System.Text.RegularExpressions;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public float speed = 5f;
    public GameObject collisionCapsule;

    private void Start()
    {
        Debug.Log("Spacebar to spawn the collider object, which will have the broken isServer/isClient checks");
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                CmdMove(horizontal, vertical);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject spawnedObject = Instantiate(collisionCapsule, new Vector3(0, 0, 2), Quaternion.identity);
                CmdSpawn();
            }
        }
    }

    [Command]
    public void CmdMove(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    [Command]
    public void CmdSpawn()
    {
        GameObject spawnedObject = Instantiate(collisionCapsule, Vector3.zero, Quaternion.identity);
    }
}
