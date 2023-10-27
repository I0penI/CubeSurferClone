using UnityEngine;


public class PlayerMovmentController : MonoBehaviour
{
    [SerializeField] private PlayerInputController  playerInputController;

    [SerializeField] private float forwardMovSpeed;
    [SerializeField] private float horizontalMovSpeed;
    [SerializeField] private float horizontalLimitValue;

    private float newPositionX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetHeroForwardMovment();
        SetHeroHorizontalMovment();
    }
    private void SetHeroForwardMovment()
    {
        transform.Translate(Vector3.down * forwardMovSpeed * Time.fixedDeltaTime);
    }
    private void SetHeroHorizontalMovment()
    {
        newPositionX = transform.position.x + playerInputController.HorizontalValue * horizontalMovSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
