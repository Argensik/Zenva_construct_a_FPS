using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int value;

    [Header("Bobbing")]
    public float rotateSpeed;
    public float bobSpeed;
    public float bobHeight;

    Vector3 startPos;
    bool bobbingUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            switch (type)
            {
                case PickupType.Health:
                    player.GiveHealth(value);
                    break;

                case PickupType.Ammo:
                    player.GiveAmmo(value);
                    break;
            }

            Destroy(gameObject);
        }
    }
}
