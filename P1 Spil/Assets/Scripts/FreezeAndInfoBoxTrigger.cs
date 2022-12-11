using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAndInfoBoxTrigger : MonoBehaviour
{
    public List<GameObject> infoBoxes;

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (tag)
        {
            case "Item":
                if (col.CompareTag("Freeze"))
                {
                    Time.timeScale = 0;
                    SpawnInfoBox();
                }
                break;

            case "Enemy":
                if (col.CompareTag("Freeze"))
                {
                    Time.timeScale = 0;
                    SpawnInfoBox();
                }
                break;
        }
    }

    private void SpawnInfoBox()
    {
        Instantiate(infoBoxes[0]);
        infoBoxes.Remove(infoBoxes[0]);
    }
}
