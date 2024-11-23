using Mirror;
using UnityEngine;

public class ColliderScript : NetworkBehaviour
{
    private bool isFirstUpdate = true;

    void Start()
    {
        Debug.Log($"Start ran for CollisionCapsule object: isServer is {isServer} and isClient is {isClient}");
    }

    void Update()
    {
        if (isFirstUpdate)
        {
            Debug.Log($"First update ran for CollisionCapsule object: isServer is {isServer} and isClient is {isClient}");
            isFirstUpdate = false;
        }
       
    }

     void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision ran for CollisionCapsule object: isServer is {isServer} and isClient is {isClient}");
    }
}
