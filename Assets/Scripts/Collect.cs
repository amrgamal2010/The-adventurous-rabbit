using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collect : MonoBehaviour
{
    public GameObject Coin;
    public AudioSource collectSound;
    [SerializeField] private TextMeshProUGUI CoinText;
    public static int coinValue = 0;
    void Start()
    {
        coinValue = 0;
        CoinText.text = coinValue.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinValue++;
            collectSound.Play();
            CoinText.text = coinValue.ToString();
            Destroy(Coin);
        }
        else if (collision.gameObject.CompareTag("Damage"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
