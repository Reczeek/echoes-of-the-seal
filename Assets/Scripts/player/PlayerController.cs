using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x - y, (x + y) * 0.5f, 0).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
