using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
#if (UNITY_EDITOR)
using UnityEditor;
#endif

public class VolleyballLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject opponent;
    [SerializeField] private Collider2D opponentSpawnZone;
    [SerializeField] private Sprite alterSprite;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject hint;

    [SerializeField] private float speed;
    [SerializeField] private float ballSpeed;

    private Touch touch;
    public float zRot;
    public bool canBeThrown = false;
    public bool canRotate = false;
    public bool isTouched = false;
    void Start()
    {
        OpponentSpawn();
        player.transform.position = new Vector2(Random.Range(-8, 9), player.transform.position.y);
        StartCoroutine(ThrowBall());
    }
    void OpponentSpawn()
    {
        Vector2 newPos = new Vector2(Random.Range(opponentSpawnZone.bounds.min.x, opponentSpawnZone.bounds.max.x), Random.Range(opponentSpawnZone.bounds.min.y, opponentSpawnZone.bounds.max.y));
        opponent.transform.position = newPos;
        ball.transform.position = newPos;
    }
    void Update()
    {
        float h = default;
#if(UNITY_EDITOR)
        h = Input.GetAxis("Horizontal");
#else
    if(Input.touchCount > 0)
    {
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Moved)
        {
            if(!hint.IsDestroyed()) Destroy(hint);
            h = touch.deltaPosition.x/10;
        }
    }
#endif
        player.transform.Translate(Time.deltaTime * speed * h, 0, 0);
        player.transform.position = new Vector2(Mathf.Clamp(player.transform.position.x, -10, 10), player.transform.position.y);
        if (canBeThrown)
        {
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.down * Time.deltaTime * ballSpeed, ForceMode2D.Force);
        }
        if (canRotate)
        {
            opponent.transform.rotation = Quaternion.Lerp(opponent.transform.rotation, Quaternion.Euler(0, 0, zRot), Time.deltaTime * 4f);
            ball.transform.rotation = Quaternion.Lerp(ball.transform.rotation, Quaternion.Euler(0, 0, zRot), Time.deltaTime * 4f);
        }

    }
    IEnumerator ThrowBall()
    {
        yield return new WaitForSeconds(1f);
        zRot = Random.Range(-30f, 30f);
        canRotate = true;
        yield return new WaitForSeconds(1f);
        canRotate = false;
        canBeThrown = true;
        opponent.GetComponent<SpriteRenderer>().sprite = alterSprite;
    }
}
