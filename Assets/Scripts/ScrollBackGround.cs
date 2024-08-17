using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    public enum ProjectMode { moveX = 0, moveY = 1 };
    public ProjectMode projectMode = ProjectMode.moveX;
    public MeshRenderer firstBG;
    public float firstBGSpeed = 0.01f;

    private Vector2 savedFirst;

    void Awake()
    {
        if (firstBG) savedFirst = firstBG.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Move(MeshRenderer mesh, Vector2 savedOffset, float speed)
    {
        Vector2 offset = mesh.sharedMaterial.GetTextureOffset("_MainTex");
        if (projectMode == ProjectMode.moveY)
            offset.y += speed * Time.deltaTime;
        else
            offset.x += speed * Time.deltaTime;

        offset.x = Mathf.Repeat(offset.x, 1);
        offset.y = Mathf.Repeat(offset.y, 1);

        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void Update()
    {
        if (firstBG) Move(firstBG, savedFirst, firstBGSpeed);
    }

    void OnDisable()
    {
        if (firstBG) firstBG.sharedMaterial.SetTextureOffset("_MainTex", savedFirst);
    }
}