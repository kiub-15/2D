using Unity;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float Speed = 5f; // �̵� �ӵ� ������ ����

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

        // ������ �� �Ʒ����� ������ �⺻ ��������Ʈ ����
        if (down != null)
        {
            spriteRenderer.sprite = down;
        }
    }

    void Update()
    {
        // Ű���� �Է� �ޱ� (GetAxisRaw�� �ȼ� ������ ���� ���� �ϱ�)
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
        // Ű �Է��� ���� ���� ���� �ٲٱ�
        if (movement.x != 0 || movement.y != 0)
        {
            if (movement.y > 0) // ���� �̵�
            {
                if (up != null)
                {
                    spriteRenderer.sprite = up;
                }
            }
            else if (movement.y < 0) // �Ʒ��� �̵�
            {
                if (down != null)
                {
                    spriteRenderer.sprite = down;
                }
            }
            else if (movement.x < 0) // �������� �̵�
            {
                {
                    if (left != null) spriteRenderer.sprite = left;
                }
            }
            else if (movement.x > 0) // ���������� �̵�
            {
                if (right != null)
                {
                    spriteRenderer.sprite = right;
                }
            }
        }
    }
}
