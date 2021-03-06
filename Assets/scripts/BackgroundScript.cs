using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public BoxCollider2D collidernew;

    public Rigidbody2D rb;

    private float width;

    public float scrollSpeed;

    [SerializeField] private float scrollSpeedPerSec;



    public GameObject asteroid;

    void Start()
    {
        scrollSpeed = -8f;

        scrollSpeedPerSec = -0.1f;

        collidernew = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collidernew.size.x;
        collidernew.enabled = false;

        
        ResetObstacle();
        ResetCollectibles();
    }

  
    void Update()
    {
        scrollSpeed += scrollSpeedPerSec * Time.deltaTime;

        rb.velocity = new Vector2(scrollSpeed, 0);

        if (transform.position.x < -width)
        {
            Vector2 resetPosition = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
            ResetObstacle();
            ResetCollectibles();
        }
    
    }

    void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(Random.Range(4,7), Random.Range(-3, 3), 0);
    }

   void ResetCollectibles()
    {
     
        transform.GetChild(1).localPosition = new Vector3(10, Random.Range(-4, 4), 0);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        if(transform.GetChild(0).localPosition == transform.GetChild(1).localPosition)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }


}
