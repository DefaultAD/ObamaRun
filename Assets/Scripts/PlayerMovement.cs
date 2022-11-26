using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public float spawnDeltaTime;
    public bool _isGamePaused { get; set; }

    public float startVelocity;
    public float moveVelocity;
    [SerializeField] private Transform spawnPoint;
    private ObjectPoolManager _objectPoolManager;
    [SerializeField] private string[] obstaclesKeys;

    [HideInInspector] public List<Transform> MovingObjects { get; private set; }
    [HideInInspector]
    public Animator _animator;

    [Space(20)] public float maxPos;
    public float moveAmount;
    public float controlSens;
    public float controlSmooth;

    public float rotationAmount;

    [Space(20)] public Transform pointer;
    public Canvas canvas;
    float xPos;
    float xPosC;
    float x;
    Vector2 screenSize;
    Vector2 movePos;
    float rot;
    float tempX;

    private void Awake()
    {
        MovingObjects = new List<Transform>();
        _animator = transform.GetChild(0).GetComponent<Animator>();

    }

    private void Start()
    {
        _animator.SetBool("Start", true);
        screenSize = new Vector2(Screen.width, Screen.height);

#if UNITY_EDITOR
        screenSize = new Vector2(960, 1920);
#endif

        pointer.transform.position -= new Vector3(screenSize.x / 2, 0, 0);

        _objectPoolManager = ObjectPoolManager.Singleton;
    }

    void Update()
    {
        if (_isGamePaused)
            return;

        #region Movement
        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out movePos);
        
        if (Input.GetMouseButtonDown(0))
        {
            pointer.transform.position = canvas.transform.TransformPoint(movePos);
            xPos = pointer.transform.position.x;
            xPosC = transform.position.x;
            x = 0;
        }
        float delta = transform.position.x - tempX;
        if (delta > 0.02f)
            rot = 1;
        if (delta < -0.02f)
            rot = -1;
        if (delta > -0.02f && delta < 0.02f)
            rot = 0;
        
        
        tempX = transform.position.x;
        _animator.transform.rotation = Quaternion.Slerp(_animator.transform.rotation, Quaternion.Euler(0, rot * rotationAmount, 0), Time.deltaTime * controlSmooth);
        
        if (Input.GetMouseButton(0))
            pointer.transform.position = canvas.transform.TransformPoint(movePos);
        
        
        x = ((pointer.position.x - xPos) / screenSize.x) * moveAmount;
        transform.position = Vector3.Lerp(transform.position, new Vector3(xPosC + x, transform.position.y, transform.position.z), Time.deltaTime * controlSens);
        
        
        if (transform.position.x <= -maxPos)
        {
            transform.position = new Vector3(-maxPos + 0.001f, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= maxPos)
        {
            transform.position = new Vector3(maxPos - 0.001f, transform.position.y, transform.position.z);
        }
        
        #endregion
    }

    private void FixedUpdate()
    {
        foreach (Transform movingObject in MovingObjects)
        {
            for (int i = 2; i < movingObject.childCount; i++)
            {
                Rigidbody rb = movingObject.GetChild(i).GetComponent<Rigidbody>();
                var tmpVelocity = rb.velocity;
                tmpVelocity = new Vector3(tmpVelocity.x, tmpVelocity.y, -moveVelocity);
                rb.velocity = tmpVelocity;
            }
        }
        _animator.speed = 0.24f * Mathf.Pow(moveVelocity, 0.6f);
    }
}