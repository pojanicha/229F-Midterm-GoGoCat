using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = GetComponent<Transform>();
        t.Translate(0,0,speed * Time.deltaTime);
    }
}
