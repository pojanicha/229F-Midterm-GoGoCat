using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] int reducedTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            Destroy(this.gameObject);
           TimeControl.Instance.ReduceTime(reducedTime);          


        }
    }

   
}
