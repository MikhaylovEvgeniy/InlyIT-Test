using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Instance.gameObject)
        {
            ItemsSaving.Instance.SaveItemName("Note");
            NoteMenu noteMenu = FindAnyObjectByType<NoteMenu>();
            noteMenu.OpenNote();
            Destroy(gameObject);
        }
    }
}
