using UnityEngine;

public class RandomHelper : MonoBehaviour
{
    /// <summary>
    /// Return a random float between min and max, inclusive from both ends.
    /// </summary>
    public static float NextRandom(float min, float max)
    {
        return (float)Random.Range(min, max);
    }

    /// <summary>
    /// Return a random integer between min and max - 1.
    /// </summary>
    public static int NextRandom(int min, int max)
    {
        return (int)Random.Range(min, max);
    }

    /// <summary>
    /// Return a random boolean
    /// </summary>
    public static bool NextBoolRandom()
    {
        return (bool)(Random.Range(0, 2) == 1);
    }
}