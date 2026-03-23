using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] int reducedTime;
    private AudioSource audioSource;
    public AudioClip hitClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component if it doesn't exist
        }
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {

            Debug.Log("Player hit an obstacle!");
            AudioSource.PlayClipAtPoint(hitClip, Camera.main.transform.position);

            TimeControl.Instance.ReduceTime(reducedTime);
           Destroy(this.gameObject);

        }
    }

   
}
