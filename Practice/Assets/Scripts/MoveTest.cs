using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed = 5f;
    // �ܼ��� ĸ��ȭ�� ������Ƽ�� ������
    //public Vector3 Velocity { get; private set; }

    // C# �� ������Ƽ�� ������ ĸ��ȭ
    public Vector3 Velocity
    {
        get
        {
            return _velocity;
        }
        private set
        {
            _velocity = value;
        }
    }

    private Vector3 _velocity;

    // ���Ž� ��Ÿ���� ���� ĸ���Լ�
    public Vector3 GetVelocity()
    {
        return _velocity;
    }

    public void SetVelocity(Vector3 value)
    {
        _velocity = value;
    }

    // Unity �� Component �� �����ڸ� �����ε��Ͽ� ���� ȣ���� �� ����.
    // GameObject.AddComponent �� �߰��ϰԵǸ� ���� ���ο��� �����Ѵ�. 
    // �׷��� AddCompnent �� �Ǿ� Component �� ���ʷ� �����Ǿ� �ε�ɶ�
    // �����ڿ��� �ϴ� �ʱ�ȭ������ Awake �� �ۼ����ָ�ȴ�.
    private void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
    }

    // �� ������Ʈ�� Ȱ��ȭ�ɶ����� �ʱ�ȭ�� ������ �ִٸ� ���� �ۼ�
    private void OnEnable()
    {
        
    }

    // ���� ���� �������� ������Ʈ �Ǳ��� ���ʷ� �ѹ��� ȣ���Ͽ� �ʱ�ȭ��.
    // ���ӷ����� ����ϴ� �ٸ� �ʱ�ȭ�� �Ϸ�� ��ü���� ������ ���� ���ӽ����� �����ؾ��ϴ� ������ �ʱ�ȭ
    private void Start()
    {
        
    }

    /// <summary>
    /// �� �����Ӹ��� ȣ��
    /// </summary>
    private void Update()
    {
        // Update �� ȣ��Ǵ� �ֱ�� �̵��Ÿ�
        // �̵��Ÿ��� = �ӷ� * �ð�
        // ���� = �ӵ� * �ð���ȭ
        // ������ġ = ������ġ + ����
        // Vector3 velocity = new Vector3(0, 0, 1f); // m/s
        // Vector3 deltaPosition = velocity * Time.deltaTime;
        // Vector3 targetPosition = transform.position + deltaPosition;
        // transform.position = targetPosition;

        //transform.position += velocity * Time.deltaTime;
        HandleInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // ũ�� 1�� ���⺤�ͷ� ����ȭ
        Velocity = direction * _speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Down space key");
        }
    }

    void Move()
    {
        transform.position += Velocity * Time.fixedDeltaTime;
    }
}

public class Test
{
    void main()
    {
        A a = new A();
    }
}

public class A
{
    int a;

    // ������ �����ε� ������ ��������� �ʱ�ȭ�ϱ�����. (��ü�� ������ ����)
    public A()
    {
        a = 5;
    }
    ~A()
    {

    }
}