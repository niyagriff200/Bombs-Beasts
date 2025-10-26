using UnityEngine;

public class ZoomerPawn : Pawn
{
    private float moveSpeed;

    protected override void Start()
    {
        moveSpeed = GameManager.Instance.ZoomerMoveSpeed;
    }
    public override void Move(Vector3 moveVector)
    {
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }
}
