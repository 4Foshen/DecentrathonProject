using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;
    [SerializeField] private float _speed;
    private Transform _targetPosition;
    private int _targetPositionID;

    private void Start()
    {
        _targetPosition = _positions[0];
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, _targetPosition.position, _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MovementPos"))
        {
            UpdateTargetPosition();
        }
    }
    private void UpdateTargetPosition() 
    {
        _targetPositionID++;
        if (_targetPositionID == _positions.Length) _targetPositionID = 0;
        _targetPosition = _positions[_targetPositionID];
    }
}
