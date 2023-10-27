using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] PlayerStackController playerStackController;
    private Vector3 direction = Vector3.back;
    private RaycastHit hit;
    private bool isStack = false;
    void Start()
    {
         playerStackController = GameObject.FindObjectOfType<PlayerStackController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetCubeRaycast();
    }
    private void SetCubeRaycast()
    {
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!isStack)
            {
                isStack = true;
                playerStackController.IncreaseBlockStack(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube")
            {
                playerStackController.DecreaseBlock(gameObject);
            }
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
