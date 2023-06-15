using UnityEngine;

public class GroundGenerator2D : MonoBehaviour
{
    public int textureWidth = 100;
    public int textureHeight = 20;
    public float noiseScale = 0.1f;
    public int seed;
    public Texture2D groundTexture;

    private void Start()
    {
        GenerateGroundTexture();
    }

    private void GenerateGroundTexture()
    {
        groundTexture = new Texture2D(textureWidth, textureHeight);
        Color[] pixels = new Color[textureWidth * textureHeight];

        // Use the seed to ensure the same random sequence each run
        Random.InitState(seed);

        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                float noiseValue = Mathf.PerlinNoise((float)x * noiseScale, (float)y * noiseScale);
                pixels[y * textureWidth + x] = new Color(noiseValue, noiseValue, noiseValue);
            }
        }

        groundTexture.SetPixels(pixels);
        groundTexture.Apply();
    }
}
