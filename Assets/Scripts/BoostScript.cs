using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BoostController boostController = FindAnyObjectByType<BoostController>();

        if (other.gameObject == Player.Instance.gameObject)
        {
            ItemsSaving.Instance.SaveItemName("Boost");
            boostController.Boost();
            Destroy(gameObject);
        }
    }
}
