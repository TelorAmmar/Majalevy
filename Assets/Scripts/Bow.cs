using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bow : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    public ArrowPossession arrowPossession;
    public GameObject arrow;
    public GameObject bowSprite;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    public float launchForce;
    public float arrowGravity;
    public Transform shotPoint;
    Vector2 direction;
    Animator animator;
    InputAction shoot;

    private Quaternion lastParentRotation;

    private bool _isAiming = false;

    public bool IsAiming
    {
        get
        {
            return _isAiming;
        }
        private set
        {
            _isAiming = value;
            animator.SetBool(AnimationStrings.isAiming, value);
        }
    }

    void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
        arrowPossession = player.GetComponent<ArrowPossession>();
        animator = bowSprite.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for(int i=0; i<numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
            points[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(IsAiming)
        {
            Trajectory();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        bool playerHasArrow = arrowPossession.HasArrow;
        if(playerHasArrow)
        {
            if(context.performed)
            {
                IsAiming = true;
            }
            else if(context.canceled)
            {
                IsAiming = false;
                Shoot();
            }
        }

    }

    void Shoot()
    {
        GameObject newArrrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        for(int i=0; i<numberOfPoints; i++)
        {
            points[i].SetActive(false);
        }
        arrowPossession.ArrowUsed();
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + (0.5f * Physics2D.gravity * arrowGravity * (t * t));
        return position;
    }

    void Trajectory()
    {
        Vector2 bowPos = transform.position;
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        direction = worldPos - bowPos;
        bool playerFacingRight = playerController.IsFacingRight;
        lastParentRotation = transform.parent.localRotation;
        transform.localRotation = Quaternion.Inverse(transform.parent.localRotation) * lastParentRotation * transform.localRotation;
        for(int i=0; i<numberOfPoints; i++)
        {
            points[i].SetActive(true);
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
        transform.right = direction;
    }
}
