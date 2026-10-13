using UnityEngine;
using TMPro;


public class ItemCollector : MonoBehaviour
{
    int coins = 0;

    [SerializeField] TMP_Text coinText;
    [SerializeField] AudioSource collectionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            collectionSound.Play();
            Destroy(other.gameObject);
            coins++;
            coinText.text = "Coins: " + coins;
        }
    }
}