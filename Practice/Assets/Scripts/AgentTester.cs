using UnityEngine;
using UnityEngine.AI;


public class AgentTester : MonoBehaviour
{
    NavMeshAgent _agent;
    Camera _camera;
    [SerializeField] LayerMask _groundMask;


    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // 마우스왼쪽 누름
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity, _groundMask))
            {
                _agent.SetDestination(hit.point);
            }
        }
        
    }
}
