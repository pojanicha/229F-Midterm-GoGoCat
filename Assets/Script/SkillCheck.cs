using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private RectTransform SafeZone;
    [SerializeField] private int movespeed;
    bool isPress; // for check prees 

    //[SerializeField] private Object player;
    
    //test
    public Player player;

    
    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    public GameObject skillCheck;

    
    void Start()
    {
        
        
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
        skillCheck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, movespeed * Time.deltaTime);

        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
            
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
            
        }

        if (Input.GetKey(KeyCode.Space) && isPress)
        {
            CheckSuccess();
            isPress = false;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isPress = true;
        }
    }

    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(SafeZone, pointerTransform.position, null))
        {
            Debug.Log("Success");
            skillCheck.SetActive(false); // success = UI close

            //test fix later
            player.rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);

            //Time.timeScale = 1;

            
            
        }
        else
        {
            Debug.Log("Fall jaaaa");
        }
    }
}
