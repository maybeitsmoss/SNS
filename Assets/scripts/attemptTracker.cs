using UnityEngine;

public static class attemptTracker
{
    public static int attempts;
    public static bool allowSkip = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static void Start()
    {
        attempts = 0;
    }

    public static void onDeath()
    {
        attempts += 1;

        if (attempts >= 3)
        {
            allowSkip = true;
        }
    }

    public static void Reset()
    {
        attempts = 0;
        allowSkip = false;
    }
}
