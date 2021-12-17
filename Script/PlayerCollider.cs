using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    public GameObject Scene_Load;//¾À ·Îµå ÆÐ³Î

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Load Scene2")
        {
            Scene_Load.SetActive(true);
        }
        if (other.tag == "Load Scene1")
        {
            Scene_Load.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Load Scene2")
        {
            Scene_Load.SetActive(false);
        }
        if (other.tag == "Load Scene1")
        {
            Scene_Load.SetActive(false);
        }
    }
}
