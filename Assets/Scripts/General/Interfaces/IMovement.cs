using UnityEngine;

public interface IMovement
{
    /// <summary>
    /// Moving character to position with speed
    /// </summary>
    /// <param name="position">Position to move</param>
    /// <param name="speed">Move speed</param>
    public void Move(Vector3 position, float speed);
}
