using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;

    [SerializeField]
    Rigidbody2D rb;

    Vector2 movement;

    public bool isFacingLeft = true;

    public GameObject firePoint;
    public int health = 3;
    public int keyAmount;
    public GameManager GameManager;
    SpriteRenderer spriteRenderer;
    public Text objectives;

    public Animator animatora;
    void Start() {
        animatora = gameObject.GetComponent<Animator>();
        animatora.SetBool("isMoving", false);
    }
    void Update()
    {
        //Movement Controls
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        DirectionalShooting();

        Debug.Log(rb.velocity.magnitude); //check after
    }

    void FixedUpdate() {
        //player movement
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    void DirectionalShooting(){
        //Method to change firePoint rotation depending on keypress

        if (Input.GetKeyDown(KeyCode.D))
        {
            if(isFacingLeft){
                flip();
                isFacingLeft = false;
            }
            firePoint.transform.rotation = Quaternion.Euler(0,0,180);
            animatora.SetBool("isMoving", true);
            animatora.SetBool("isRight", true);
            animatora.SetBool("isLeft", false);
            animatora.SetBool("isFront", false);
            animatora.SetBool("isBack", false);
            animatora.SetBool("isHorizontal", true);
            animatora.SetBool("isVertical", false);
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            if(!isFacingLeft){
                flip();
                isFacingLeft = true;
            }
            firePoint.transform.rotation = Quaternion.Euler(0,0,0);
            animatora.SetBool("isMoving", true);
            animatora.SetBool("isRight", false);
            animatora.SetBool("isLeft", true);
            animatora.SetBool("isFront", false);
            animatora.SetBool("isBack", false);
            animatora.SetBool("isHorizontal", true);
            animatora.SetBool("isVertical", false);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            firePoint.transform.rotation = Quaternion.Euler(0,0,-90);
            animatora.Play("walkBack");
            animatora.SetBool("isMoving", true);
            animatora.SetBool("isRight", false);
            animatora.SetBool("isLeft", false);
            animatora.SetBool("isFront", false);
            animatora.SetBool("isBack", true);
            animatora.SetBool("isVertical", true);
            animatora.SetBool("isHorizontal", false);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            firePoint.transform.rotation = Quaternion.Euler(0,0,90);
            animatora.Play("walkFront");
            animatora.SetBool("isMoving", true);
            animatora.SetBool("isRight", false);
            animatora.SetBool("isLeft", false);
            animatora.SetBool("isFront", true);
            animatora.SetBool("isBack", false);
            animatora.SetBool("isVertical", true);
            animatora.SetBool("isHorizontal", false);
            
        }

        /* 8 directional shooting 
        //using keycode instead of keycodedown because both need to be pressed simultaneously
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,45);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,135);
        }
        else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,315);
        }
        else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)){
            firePoint.transform.rotation = Quaternion.Euler(0,0,225);
        }
        */
    }

    void flip()
    {
        //flips sprite depending on direction facing
        isFacingLeft = !isFacingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D col) 
        {
            if (col.gameObject.tag == "Key")
            {
                keyAmount +=1;
                Destroy(col.gameObject);

                if (keyAmount == 1)
                {
                    StartCoroutine(OneKeyCoroutine());
                }
            }

            else if (col.gameObject.tag == "Door" && keyAmount == 3)
            {
                GameManager.GameComplete();
            }

            else if (col.gameObject.name == "EasterEgg"){
                GameObject chicken = GameObject.Find("Chicken");
                chicken.GetComponent<SpriteRenderer>().enabled = true;
                objectives.text = "What on earth are you doing?";
            }

            else if(col.gameObject.name == "Chicken"){
                Destroy(col.gameObject); 
                objectives.text = "A chicken?\nCool, I like it!";
                StartCoroutine(TextDisappearCoroutine());
            }

            else if(col.gameObject.name == "Objective1")
            {
                Destroy(col.gameObject);
                StartCoroutine(IntroCoroutine());
            }

            else if(col.gameObject.name == "Objective2")
            {
                Destroy(col.gameObject);
                objectives.text = "I wonder what's around here..";
                StartCoroutine(TextDisappearCoroutine());
            }

            else if(col.gameObject.name == "Objective3")
            {
                Destroy(col.gameObject);
                objectives.text = "It might look friendl-\nNever mind, that thing is clearly hostile!";
                StartCoroutine(TextDisappearCoroutine());
            }

            else if(col.gameObject.name == "Objective5")
            {
                Destroy(col.gameObject);
                objectives.text = "Turn back or else you will die";
                StartCoroutine(TextDisappearCoroutine());
            }
            
            else if(col.gameObject.name == "Objective6")
            {
                Destroy(col.gameObject);
                objectives.text = "If you keep going down you just might find something";
                StartCoroutine(TextDisappearCoroutine());
            }

            else if(col.gameObject.name == "Objective7")
            {
                Destroy(col.gameObject);
                objectives.text = "The exit is near, keep going";
                StartCoroutine(TextDisappearCoroutine());
            }
        }

        IEnumerator TextDisappearCoroutine()
        {
            yield return new WaitForSeconds(3);
            objectives.text = " ";
        }

        IEnumerator IntroCoroutine()
        {
            objectives.text = "Welcome to great labryinth of... Escape the Dungeon!";
            yield return new WaitForSeconds(3);
            objectives.text = "Not exactly the most original name right?\nWe're aware of it";
            yield return new WaitForSeconds(3);
            objectives.text = "For now just take your first left..";
            yield return new WaitForSeconds(3);
            objectives.text = " ";
        }

        IEnumerator OneKeyCoroutine()
        {
            objectives.text = "A key... I wonder where the door for it is";
            yield return new WaitForSeconds(3);
            objectives.text = " ";
        }
}
