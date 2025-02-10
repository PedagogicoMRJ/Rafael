using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    float bulletAngle;
    float muzzleAngle;
    Vector2 muzzlePosition;
    Animator bulletAnim;
    public GameObject bulletPrefab;

    void Start()
    {
        bulletAnim = GetComponent<Animator>();
    }
    public void fireBullet(Vector2 aim)
    {
        transform.rotation = Quaternion.identity;
        bulletAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        if (bulletAngle < 0)
        {
            bulletAngle += 360;
        }
        for (float i = 22.5f; i < 337.5f; i += 45f)
        {
            if (bulletAngle > i && bulletAngle < i + 45f)
            {
                muzzleAngle = i + 22.5f;
                break;
            }
            else
            {
                muzzleAngle = 0;
            }
        }
        float quadrant = muzzleAngle / 45f;
        if (quadrant == 0)
        {
            muzzlePosition.x = 1f;
            muzzlePosition.y = 0;
        }
        else if (quadrant == 1)
        {
            muzzlePosition.x = 0.7f;
            muzzlePosition.y = 0.7f;
        }
        else if (quadrant == 2)
        {
            muzzlePosition.x = 0;
            muzzlePosition.y = 1f;
        }
        else if (quadrant == 3)
        {
            muzzlePosition.x = -0.7f;
            muzzlePosition.y = 0.7f;
        }
        else if (quadrant == 4)
        {
            muzzlePosition.x = -1f;
            muzzlePosition.y = 0;
        }
        else if (quadrant == 5)
        {
            muzzlePosition.x = -0.7f;
            muzzlePosition.y = -0.7f;
        }
        else if (quadrant == 6)
        {
            muzzlePosition.x = 0;
            muzzlePosition.y = -1f;
        }
        else if (quadrant == 7)
        {
            muzzlePosition.x = 0.7f;
            muzzlePosition.y = -0.7f;
        }
        transform.Rotate(0f, 0f, muzzleAngle);
        transform.localPosition = muzzlePosition;
        bulletAnim.SetTrigger("fire");
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.Rotate(0f, 0f, bulletAngle);
        bullet.GetComponent<Rigidbody2D>().velocity = aim * bulletSpeed;

    }
}
