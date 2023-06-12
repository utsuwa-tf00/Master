using UnityEngine;
using UnityEngine.UI;

public class CircleController : MonoBehaviour
{
    public bool circleToggle = false; // 制御トグル
    public Shader circleShader; // シェーダーマテリアル

    private RawImage rawImage; // RawImageコンポーネントの参照
    private Material circleMaterial; // マテリアルのインスタンス

    private float baseCircle = 0.5f;

    private void Start()
    {
        // マテリアルのインスタンスを作成または既存のマテリアルを取得
        rawImage = GetComponent<RawImage>();
        circleMaterial = new Material(circleShader);

        // マテリアルをオブジェクトに適用
        rawImage.material = circleMaterial;

        // _BaseCircleの初期値を設定
        circleMaterial.SetFloat("_BaseCircle", baseCircle);
    }

    private void Update()
    {
        // circleToggleの値に応じて_BaceCircleの値を設定
        if (circleToggle)
        {
            baseCircle = 0.1f;
        }
        else
        {
            baseCircle = 0.5f;
        }
        rawImage.material.SetFloat("_BaseCircle", baseCircle);
    }
}
