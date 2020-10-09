using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    private float speed;
    public float walkspeed = 5;
    public float sprintspeed = 10;
    Vector2 velocity;


    void Update()
    {


        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);


        if (Input.GetKey(KeyCode.LeftShift))

        {
            speed = 10f;
        }
        else

        {
            speed = 5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
        }
    }
}
