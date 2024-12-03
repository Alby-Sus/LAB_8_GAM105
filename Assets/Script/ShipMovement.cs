using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Gắn Animator vào GameObject
    }

    void Update()
    {
        // Nhận input từ phím (trái/phải/lên/xuống)
        float moveX = Input.GetAxisRaw("Horizontal"); // Trái (-1) hoặc phải (+1)
        float moveY = Input.GetAxisRaw("Vertical");   // Xuống (-1) hoặc lên (+1)

        // Di chuyển phi thuyền theo hướng input
        Vector2 movement = new Vector2(moveX, moveY).normalized; // Chuẩn hóa để giữ tốc độ cố định
        rb.linearVelocity = movement * moveSpeed;

        // Cập nhật Animation dựa trên hướng di chuyển
        UpdateAnimation(moveX);
    }

    void UpdateAnimation(float moveX)
    {
        // Gửi giá trị MoveDirection cho Animator
        if (animator != null)
        {
            animator.SetFloat("MoveDirection", moveX);
        }
    }
}
