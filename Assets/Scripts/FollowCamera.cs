using HighHeels.PlayerSpace;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float zOffset;
    public float heightOffset;
    public float speed;
    private Vector3 newPos = Vector3.zero;
    private Vector3 vel = Vector3.zero;

    public Vector3 offset;
    private float smoothSpeed = 0.125f;

    private void Start()
    {
        speed = Player.instance.forwardSpeed;
    }

    void LateUpdate()
    {
        FollowMethod2();
    }

    void FollowMethod1()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos , smoothSpeed);
        transform.position = smoothedPos;
    }
    void FollowMethod2()
    {
        if (target != null)//for safety
        {
            newPos.y = target.position.y + heightOffset;
            newPos.z = target.position.z - zOffset;
            newPos.x = target.position.x / 2;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref vel, speed * Time.deltaTime);
        }
    }
}
