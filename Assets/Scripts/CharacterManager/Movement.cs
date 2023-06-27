using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Movement
    public float moveX;
    public float moveY;
    //for the test
    public float baseSpeed = 0.1f;
    public float moveSpeed;
    public float boostSpeed = 0.3f;
    [SerializeField]
    private bool isBoosted = false;
    #endregion

    #region Camera
    [SerializeField]
    private Camera m_Camera;
    private float cameraXMin, cameraXMax, cameraYMin, cameraYMax;
    private float characterWidth, characterHeight;
    #endregion

    #region GameObjects

    [SerializeField] private GameObject spacer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private GameObject bullet;
    #endregion
    #region Gun Variables
    private int maxAmmo = 30;
    public int currentAmmo;
    #endregion
    // Start is called before the first frame update
    public void Start()
    {
        #region Constrained Character Setup
        m_Camera = Camera.main;

        //find camera bounds and equivalent world coordinates
        Vector2 cameraBoundMin = m_Camera.ViewportToWorldPoint(new Vector3(0, 0, m_Camera.nearClipPlane));
        Vector2 cameraBoundMax = m_Camera.ViewportToWorldPoint(new Vector3(1, 1, m_Camera.nearClipPlane));

        cameraXMax = cameraBoundMax.x;
        cameraYMax = cameraBoundMax.y;
        cameraXMin = cameraBoundMin.x;
        cameraYMin = cameraBoundMin.y;

        //find the characters bounds
        SpriteRenderer characterRenderer = GetComponent<SpriteRenderer>();
        characterWidth = characterRenderer.bounds.extents.x;
        characterHeight = characterRenderer.bounds.extents.y;
        #endregion
        moveSpeed = baseSpeed;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentAmmo > 0)
        {
           StartCoroutine(Fire());
        }
        #region Boost Speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isBoosted = true;
        }
        else
        {
            isBoosted = false;
        }
        if(isBoosted == true)
        {
            moveSpeed = boostSpeed;
        }
        else
        {
            moveSpeed = baseSpeed;
        }
        #endregion
    }
    public void FixedUpdate()
    {
        Fly();
    }

    public void Fly()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        //rb.velocity = new Vector2(moveX * speed, moveY * speed);
        #region Constrain Spacer's Movement
        //get targetposition
        Vector3 targetPos = transform.position + new Vector3(moveX * moveSpeed, moveY * moveSpeed, 0);
        targetPos.x = Mathf.Clamp(targetPos.x, cameraXMin + characterWidth, cameraXMax - characterWidth);
        targetPos.y = Mathf.Clamp(targetPos.y, cameraYMin + characterHeight, cameraYMax - characterHeight);

        transform.position = targetPos;
        #endregion
    }
    public void FlyLeft()
        //TestOnly
    {
        moveX = 1;
        moveY = Input.GetAxisRaw("Vertical");
        //rb.velocity = new Vector2(moveX * speed, moveY * speed);
        #region Constrain Spacer's Movement
        //get targetposition
        Vector3 targetPos = transform.position + new Vector3(moveX * moveSpeed, moveY * moveSpeed, 0);
        targetPos.x = Mathf.Clamp(targetPos.x, cameraXMin + characterWidth, cameraXMax - characterWidth);
        targetPos.y = Mathf.Clamp(targetPos.y, cameraYMin + characterHeight, cameraYMax - characterHeight);

        transform.position = targetPos;
        #endregion
    }

    private IEnumerator Fire()
    {
        currentAmmo--;
        Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Debug.Log("Pew");
    }
    public void TestFire()
        //testfiring
    {
        //does not need to worry about shooting too quickly
        currentAmmo--;
        Instantiate(bullet, shootOrigin.position, Quaternion.identity);
    }
}
