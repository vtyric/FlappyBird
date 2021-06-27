using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float tapForce;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotationZ;
    [SerializeField] private float maxRotationZ;

    private Rigidbody2D rigidbody;
    private Quaternion minRotation;
    private Quaternion maxRotation;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        minRotation = Quaternion.Euler(0, 0, minRotationZ);
        maxRotation = Quaternion.Euler(0, 0, maxRotationZ);

        RestartBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector2(speed, 0);
            transform.rotation = maxRotation;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, minRotation, rotationSpeed * Time.deltaTime);
    }

    public void RestartBird()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rigidbody.velocity = Vector2.zero;
    }
}