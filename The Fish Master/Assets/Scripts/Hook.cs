using DG.Tweening;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Rendering;

public class Hook : MonoBehaviour
{
    public Transform hookedTransform;

    private Camera mainCamera;
    private Collider2D coll;

    private int length;
    private int strength;
    private int fishCount;

    private bool canMove;

    private Tweener cameraTween;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        coll = GetComponent<Collider2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && Input.GetMouseButton(0))
        {
            Vector3 vector3 = mainCamera.ScreenToWorldPoint(Input.mousePosition); // Change screen pos to world pos for mosuePos
            Vector3 pos = transform.position;
            pos.x = vector3.x;
            transform.position = pos;
        }
    }

    public void StartFishing ()
    {
        length = -50;
        strength = 3;
        fishCount = 0;
        float time = -(length) * 0.1f;
        cameraTween = mainCamera.transform.DOMoveY(length, 1 + time * 0.25f, false).OnUpdate(delegate
        {
            if (mainCamera.transform.position.y <= -11)
            {
                transform.SetParent(mainCamera.transform);
            }
        }).OnComplete(delegate
        {
            coll.enabled = true;
            cameraTween = mainCamera.transform.DOMoveY(0, time * 5, false).OnUpdate(delegate
            {
                if (mainCamera.transform.position.y >= -25f)
                {
                    StopFishing();
                }
            }
            );

        });

        coll.enabled = false;
        canMove = true;
    }
    void StopFishing()
    {
        canMove = false;
        cameraTween.Kill(false);
        cameraTween = mainCamera.transform.DOMoveY(0, 2, false).OnUpdate(delegate
        {
            if (mainCamera.transform.position.y >= -11)
            {
                transform.SetParent(null);
                transform.position = new Vector2(transform.position.x, -6);
            }
        }).OnComplete(delegate
        {
            transform.position = Vector2.down * 6;
            coll.enabled = true;
            int num = 0;
        });
    }
}
