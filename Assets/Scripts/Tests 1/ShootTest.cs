using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ShootTest
{
    private GameObject playerPrefab;
    private GameObject playerInstance;
    private GameObject projectile;
    private Movement movement;

    [SetUp]
    public void SetUp()
    {
        playerPrefab = Resources.Load<GameObject>("Prefab/Spacer");
        playerInstance = GameObject.Instantiate(playerPrefab);
        projectile = Resources.Load<GameObject>("Prefab/Bullet");
        movement = playerInstance.GetComponent<Movement>();
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(playerInstance);
    }
    [UnityTest]
    public IEnumerator TestShoot()
    {
        movement.Start();
        movement.Update();
        movement.FixedUpdate();
        int originalAmmo = movement.currentAmmo;
        movement.TestFire();
        yield return new WaitForSeconds(3f);
        Assert.IsTrue(originalAmmo > movement.currentAmmo);
    }
}
