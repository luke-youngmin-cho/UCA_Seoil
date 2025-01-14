using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed = 5f;
    // 단순한 캡슐화용 프로퍼티의 생략형
    //public Vector3 Velocity { get; private set; }

    // C# 의 프로퍼티로 변수를 캡슐화
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

    // 레거시 스타일의 변수 캡슐함수
    public Vector3 GetVelocity()
    {
        return _velocity;
    }

    public void SetVelocity(Vector3 value)
    {
        _velocity = value;
    }

    // Unity 의 Component 는 생성자를 오버로드하여 직접 호출할 수 없다.
    // GameObject.AddComponent 로 추가하게되면 엔진 내부에서 생성한다. 
    // 그래서 AddCompnent 가 되어 Component 가 최초로 생성되어 로드될때
    // 생성자에서 하던 초기화내용을 Awake 에 작성해주면된다.
    private void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
    }

    // 이 컴포넌트가 활성화될때마다 초기화할 내용이 있다면 여기 작성
    private void OnEnable()
    {
        
    }

    // 게임 로직 프레임이 업데이트 되기전 최초로 한번만 호출하여 초기화함.
    // 게임로직에 사용하는 다른 초기화가 완료된 객체들의 참조를 통해 게임시작전 설정해야하는 값들을 초기화
    private void Start()
    {
        
    }

    /// <summary>
    /// 매 프레임마다 호출
    /// </summary>
    private void Update()
    {
        // Update 가 호출되는 주기당 이동거리
        // 이동거리는 = 속력 * 시간
        // 변위 = 속도 * 시간변화
        // 다음위치 = 현재위치 + 변위
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
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // 크기 1의 방향벡터로 정규화
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

    // 생성자 오버로드 목적은 멤버변수를 초기화하기위함. (객체의 데이터 설정)
    public A()
    {
        a = 5;
    }
    ~A()
    {

    }
}