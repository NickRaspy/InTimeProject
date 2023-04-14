using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

public class PlayerControl : MonoBehaviour
{
    public float direct = 0f;
    public float speed;
    public float jumpPower;
    public bool canJump = false;
    public bool canMove = true;
    public bool isDead = false;
    public new GameObject camera;

    private Rigidbody2D rb;
    private float jumpBoost;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        rb= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (camera != null)camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (canMove)
        {
#if (UNITY_EDITOR)

            Move(Input.GetAxis("Horizontal"));
            Move(direct);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
#else
            Move(direct);
#endif
        }
        if (isDead)
        {
            GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0f), 2f*Time.deltaTime);
            transform.Find("Body").GetComponent<SpriteRenderer>().color = Color.Lerp(transform.Find("Body").GetComponent<SpriteRenderer>().color, new Color(transform.Find("Body").GetComponent<SpriteRenderer>().color.r, transform.Find("Body").GetComponent<SpriteRenderer>().color.g, transform.Find("Body").GetComponent<SpriteRenderer>().color.b, 0f), 2f*Time.deltaTime);
        }
    }
    public void Death()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        camera = null;
        canMove= false;
        isDead = true;
        StartCoroutine(FinalCooldown());
    }
    public void Move(float direct)
    {
        if(canMove)transform.Translate(direct * Time.deltaTime * speed, 0, 0);
    }
    public void SetDirect(float d)
    {
        direct = d;
    }
    public void Jump()
    {
        if (canJump)
        {
            Debug.Log("Jump");
            rb.AddForce(Vector2.up * jumpPower + Vector2.up * jumpBoost, ForceMode2D.Impulse);
        }
    }
    IEnumerator FinalCooldown()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.EndGame();
    }
}
