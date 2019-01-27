using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUiTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this.GetType().FullName + ": Collision with " + collision);
        if (collision.tag != "Player")
            return;

        collision.GetComponent<GrandmaProperties>().pressEInstruction.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(this.GetType().FullName + ": Collision with " + collision);
        if (collision.tag != "Player")
            return;

        collision.GetComponent<GrandmaProperties>().pressEInstruction.SetActive(false);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //}
}
