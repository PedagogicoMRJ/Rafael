using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public enum AttackType
    {
        None,
        mShots, //multiple shots
        rShots, //rotational shots
    }
    public HealthBar healthBar;
    Animator anim;
    Rigidbody2D rig;
    public Text BossFiht;
    public Text START;
    public AttackType currentAttack = AttackType.None;
    public int ramdomNum;
    public GameObject mShotsPrefab;
    public GameObject rShotsPrefab;
    public int maxHp;
    public int hp;
    bool isPlayable;
    int berserk;
    Vector2 targetDir;
    Transform playerPos;
    float bulletAngle;
    public float bulletSpeed;

    void Start()
    {
        berserk = 1;
        isPlayable = false;
        healthBar.SetmaxHealth(maxHp);
        anim = GetComponent<Animator>();
        hp = maxHp;
        rig = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    void Update()
    {
        targetDir = playerPos.position - this.transform.position;
        targetDir.Normalize();
    }
    public void CountDown()
    {
        StartCoroutine(Countdown());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (isPlayable)
            {
                hp -= 1;
                healthBar.SetHealth(hp);
                if (hp == (maxHp * 2) / 5)
                {
                    anim.SetTrigger("Berserk");
                    berserk = 2;
                }
            }
        }
    }
    void Attack()
    {
        ramdomNum = 1; //Random.Range(0, 2);
        if (ramdomNum == 0)
        {
            currentAttack = AttackType.rShots;
            StartCoroutine(RShots());
        }
        if (ramdomNum == 1)
        {
            currentAttack = AttackType.mShots;
            StartCoroutine(MShots());
        }
    }
    public IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        BossFiht.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        START.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        BossFiht.gameObject.SetActive(false);
        START.gameObject.SetActive(false);
        isPlayable = true;
        Attack();
    }
    IEnumerator RShots()
    {
        GameObject rshots = Instantiate(rShotsPrefab, transform.position, Quaternion.identity);
        rshots.transform.Rotate(0f, 0f, Random.Range(0.0f, 45.0f));
        for (int i = 0; i < 100 / berserk; i++)
        {
            rshots.transform.localScale = new Vector3(rshots.transform.localScale.x + 0.3f * berserk, rshots.transform.localScale.y + 0.3f * berserk, 0f);
            rshots.transform.Rotate(0f, 0f, 0.5f * berserk);
            yield return new WaitForSeconds(0.1f);
        }
        Attack();
        for (int i = 0; i < 482 / berserk; i++)
        {
            rshots.transform.localScale = new Vector3(rshots.transform.localScale.x + 0.3f * berserk, rshots.transform.localScale.y + 0.3f * berserk, 0f);
            rshots.transform.Rotate(0f, 0f, 0.5f * berserk);
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(rshots);
    }
    IEnumerator MShots()
    {
        for (int i = 0; i < 50 * berserk; i++)
        {
            bulletAngle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            if (bulletAngle < 0)
                bulletAngle += 360;
            GameObject bullet = Instantiate(mShotsPrefab, transform.position, Quaternion.identity);
            bullet.transform.Rotate(0f, 0f, bulletAngle + Random.Range(-30.0f * berserk, -30.0f * berserk));
            bullet.GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
            yield return new WaitForSeconds(0.1f * berserk);
        }
    }
}
