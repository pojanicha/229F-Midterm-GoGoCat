using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private RectTransform SafeZone;
    [SerializeField] private int movespeed;
    bool isPress;

    private float diraction = 1f;
    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, movespeed * Time.deltaTime);

        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
            diraction = 1f;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
            diraction = -1f;
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
            
        }
        else
        {
            Debug.Log("Fall jaaaa");
        }
    }
}
