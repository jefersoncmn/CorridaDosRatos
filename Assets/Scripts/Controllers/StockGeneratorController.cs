using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class StockGeneratorController : MonoBehaviour
{
    // public float[] values = new float[25];

    // public int width = 256;
    // public int height = 256;

    // public int size = 25;
    // public float scale = 0.1f;
    // public int seed = 0;
    // private Noise noise = new PerlinNoise();
    
    // private void Start() {
    //     values = generateStock(size, seed, scale);
    // }

    // private void Update() {
    //     values = generateStock(size, seed, scale);
    // }
    //TO DO gerar graficos mais agressivos
    public static float[] generateStock(int _sizeArray, int _seed, float _scale) {
        Noise noise = new PerlinNoise();
        noise.seed = _seed;
        float[] _values = new float[_sizeArray]; 
        for (int y = 0; y < _sizeArray; y++)
        {
            _values[y] = noise.GetNoiseMap(1, y, _scale);
        }
        return _values;
    }

    
}
