/*
* John Nguyen
* ShootWithRaycasts.cs
* Assignment 5B - 3D Prototype with ProBuilder
* This is the ShootWithRaycasts script, which manages how the player's gun (rifle) shoots "raycasts" to see if they've hit an enemy.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootWithRaycasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public float hitForce = 10f;
    public float shotCooldown = 1f;
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // At the beginning of the Shoot() method, play the particle effect
        muzzleFlash.Play();

        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);

            // Get the IDamageable interface from the hit object
            IDamageable damageable = hitInfo.transform.gameObject.GetComponent<IDamageable>();

            // If a target script was found, make the target take damage
            if (damageable != null)
            {
                damageable.TakeDamage(damage);

                // If the shot hits a Rigidbody, apply a force
                if(hitInfo.rigidbody != null)
                {
                    hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
                }
            }
            else
            {
                StartCoroutine(HandleCoolDown());
            }
        }
    }

    private IEnumerator HandleCoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotCooldown);
        canShoot = true;
    }
}
