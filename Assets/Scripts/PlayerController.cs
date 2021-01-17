using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Variables

    [Header("Controll")]
    public float speed;
    public bool faceRight;

    [Header("Jump")]
    public bool canJump = true;
    public float jumpPower;
    public float jumpFrequency;
    public float nextJumpTime;

    [Header("Rollover")]
    public float rolloverRull;
    public float rolloverSpeed;
    public float extremJumpPower;
    public bool canRollover = false;

    #endregion

    #region Private Variables
    private Rigidbody2D rb2d;

    #endregion

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        #region Controll
        float input = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(input * speed, rb2d.velocity.y);

        if (Input.GetKey(KeyCode.Space) && canJump && nextJumpTime < Time.timeSinceLevelLoad) Jump();

        #endregion

        #region Flip
        if (input > 0 && !faceRight || input < 0 && faceRight) Flip();
        #endregion

        #region Rollover
        if (canRollover) Rollover();
        #endregion
    }
    private void Rollover()
    {
        transform.Rotate(Vector3.forward * rolloverSpeed * Time.deltaTime);
    }
    private void Jump()
    {
        nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;

        GetComponent<AudioSource>().Play();

        float extrem_jump_power = 0;

        if (rb2d.velocity.x > rolloverRull || rb2d.velocity.x < -rolloverRull)
        {
            extrem_jump_power = extremJumpPower;
            canRollover = true;
        }

        rb2d.AddForce(Vector2.up * (50 * (jumpPower + extrem_jump_power)));
    }
    private void Flip()
    {
        faceRight = !faceRight;

        Vector3 scale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 0);
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D()
    {
        // Reset Rotation
        canRollover = false;
        transform.rotation = Quaternion.Euler(Vector3.zero);

        canJump = true;
    }
    private void OnCollisionExit2D()
    {
        canJump = false;
    }
}