using Unity;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float Speed = 5f; // 이동 속도 조절용 변수

    private Rigidbody2D rb;

    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        // 시작할 때 아래쪽을 보도록 기본 스프라이트 설정
        if (down != null)
        {
            spriteRenderer.sprite = down;
        }
    }

    void Update()
    {
        // 키보드 입력 받기 (GetAxisRaw로 픽셀 움직임 느낌 나게 하기)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        UpdateSprite();
        Vector2 move = new Vector2(moveX, moveY).normalized;
        rb.velocity = move * Speed;
    }
    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -8f, 8f);
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);

        transform.position = pos;
    }
    void UpdateSprite()
    {
        // 키 입력이 있을 때만 방향 바꾸기
        if (movement.x != 0 || movement.y != 0)
        {
            if (movement.y > 0) // 위로 이동
            {
                if (up != null)
                {
                    spriteRenderer.sprite = up;
                }
            }
            else if (movement.y < 0) // 아래로 이동
            {
                if (down != null)
                {
                    spriteRenderer.sprite = down;
                }
            }
            else if (movement.x < 0) // 왼쪽으로 이동
            {
                {
                    if (left != null) spriteRenderer.sprite = left;
                }
            }
            else if (movement.x > 0) // 오른쪽으로 이동
            {
                if (right != null)
                {
                    spriteRenderer.sprite = right;
                }
            }
        }
    }
}
