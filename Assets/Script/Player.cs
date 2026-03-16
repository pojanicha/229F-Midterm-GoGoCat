using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] public float speed;
    public float Xrange = 4;

    public Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // leaw sai leaw kwa
        var moveAction = InputSystem.actions.FindAction("Move");
        var hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(hInput * speed * Time.deltaTime * Vector3.right);
        
        //  player can walk left right/but not falling off map.
        if (transform.position.x < -Xrange)
        {
            transform.position = new Vector3(-4, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > Xrange)
        {
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
        }

        // plyer go straight
        /*Transform t = GetComponent<Transform>();
        t.Translate(0,0,speed * Time.deltaTime);*/
    }
}
