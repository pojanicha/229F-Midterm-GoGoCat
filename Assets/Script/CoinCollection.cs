using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
	private int Coin = 0;
	private int maxCoin = 10;
	private int addTime = 5;

	private AudioSource audioSource;
	public AudioClip coinSound;

    public TextMeshProUGUI CoinText;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
		if (audioSource == null)
		{ 
			audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component if it doesn't exist

        }
    }




    private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Coin")) //Check if the collide object has tag "Coin"
		{
			Coin++;
			
			CoinText.text = "Egg: " + Coin.ToString();
			Debug.Log(Coin);
			audioSource.PlayOneShot(coinSound); // Play the coin sound effect
            Destroy(other.gameObject);

			if (Coin == maxCoin)
			{
				TimeControl.Instance.AddTime(addTime);
				Coin = 0;
			}
		}
	}
}
