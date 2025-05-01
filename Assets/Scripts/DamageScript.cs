using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            ItemsSaving.Instance.SaveItemName("Damage");
            Player.Instance.GetDamage();
            Destroy(gameObject);
        }
    }
}
