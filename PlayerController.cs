using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class PlayerController наследует свойства от класса MonoBehaviour
public class PlayerController : MonoBehaviour
{
    // SerializeField нужно, чтобы переменная была видна в редакторе Unity, но была скрыта для других классов с помощью private
    [SerializeField] private float speedX = 1f;

    private Rigidbody2D rb;
    const float speedXMultiplayer = 100f;
    private float horizontal = 0f;
    private bool isJump = false;
    private bool isGround = false;

    void Start()
    {
        Debug.Log("Game Started");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //присваивает объекту движение по горизонту с помощью клавиш A D, стиков влево право, стрелок вправо влево.
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W) && isGround)
        {
            isJump = true;
        }
        //можно таким образом достукиваться до кнопок.
        // Input.GetKey(KeyCode.A);
        // Input.GetKey(KeyCode.D);
    }

    //FixedUpdate служит для того, чтобы менять физику объекта.
    void FixedUpdate()
    {
        //устанавливаю скорость движение объекта по оси X и Y с сохранением постоянной скорости по Y
        rb.velocity = new Vector2(horizontal * speedX * speedXMultiplayer * Time.fixedDeltaTime, rb.velocity.y);
        if (isJump)
        {
            rb.AddForce(new Vector2(0f, 500f));
            isGround = false;
            isJump = false;
        }
    }

    //вычисляет когда коллизии объектов соприкасаются
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
