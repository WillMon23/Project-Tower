using UnityEngine;
public class InputBehaviour : MonoBehaviour
{
    private MovementScript _movemnet;
    private float _moveX;
    private float _moveZ;

    // Start is called before the first frame update
    void Start()
    {
        _movemnet = GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");

        _movemnet.Input = new Vector3(_moveX, 0 , _moveZ).normalized;
    }
}
