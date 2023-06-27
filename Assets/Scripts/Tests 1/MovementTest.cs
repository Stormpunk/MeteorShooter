using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    private GameObject playerPrefab;
    private GameObject playerInstance;
    private Movement movement;
    private GameObject thisCamera;
    private Camera m_Camera;

    [SetUp]
    public void SetUp()
    {
        playerPrefab = Resources.Load<GameObject>("Prefab/Spacer");
        playerInstance = GameObject.Instantiate(playerPrefab);
        movement = playerInstance.GetComponent<Movement>();
        m_Camera = Resources.Load<Camera>("Prefab/Main Camera");
        m_Camera = GameObject.Instantiate(m_Camera);
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(playerInstance);
    }

    [UnityTest]
    public IEnumerator MoveTest()
    {
        movement.Start();
        movement.Update();
        movement.FixedUpdate();
        float originalPos = playerInstance.transform.position.x;
        movement.FlyLeft();
        yield return new WaitForSeconds(3f);
        Debug.Log("MoveX = " + movement.moveX + " MoveSpeed = " + movement.moveSpeed);
        Debug.Log("Location = " + playerInstance.transform.position.x + "Original Location = " + originalPos);
        Assert.Greater(playerInstance.transform.position.x, originalPos);

    }
}
