using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constrain : MonoBehaviour
{
    #region Camera
    [SerializeField]
    private Camera m_Camera;
    private float cameraXMin, cameraXMax, cameraYMin, cameraYMax;
    private float characterWidth, characterHeight;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        #region Constrain Spacer
        //get targetposition
        Vector3 targetPos = transform.position + new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        float clampedX = Mathf.Clamp(targetPos.x, cameraXMin + characterWidth, cameraXMax - characterWidth);
        float clampedY = Mathf.Clamp(targetPos.y, cameraYMin + characterHeight, cameraYMax - characterHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        #endregion
    }
}
