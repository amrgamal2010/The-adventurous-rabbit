using UnityEngine;
using TMPro;


public class Finallevel : MonoBehaviour
{
    [SerializeField] private GameObject winText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            Debug.Log("Player touched the flag!");
            winText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
