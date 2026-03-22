using Unity.VisualScripting;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    
    // for Skill check UI
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private RectTransform SafeZone;
    [SerializeField] private int movespeed;

    //Newton Law 2
    [SerializeField] float force;
    [SerializeField] float mass;
    [SerializeField] float acc;


    //test
    public Player player;
    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    public GameObject skillCheck;

    int reducedTime = 5;


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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
           
        }
        
    }

    void CalculateForce()
    {
        mass = player.rb.mass;
        force = mass * acc;
        player.rb.AddForce(0, force, 0);
    }

    void CheckSuccess()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(SafeZone, pointerTransform.position, null))
        {
            Debug.Log("Success");
            
            skillCheck.SetActive(false); // success = UI close
            

            CalculateForce();

            
        }
        else
        {
            Debug.Log("Fall jaaaa");
            TimeControl.Instance.ReduceTime(reducedTime);
        }
    }
}
