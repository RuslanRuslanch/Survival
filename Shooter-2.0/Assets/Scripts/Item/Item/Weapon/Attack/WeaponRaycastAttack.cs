using UnityEngine;

public class WeaponRaycastAttack : WeaponAttack
{
    private readonly Transform _cameraTransform;

    private readonly bool _useSpread;
    private readonly float _spreadFactor;
    private readonly byte _attackCount;
    private readonly LayerMask _searchLayers;

    private Vector3 Spread => _useSpread ? GetSpread() : Vector3.zero;

    public WeaponRaycastAttack(float damage, float rate, float maxDistance, byte power, LayerMask searchLayers, byte attackCount, bool useSpread, float spreadFactor) : base(damage, rate, maxDistance, power)
    {
        _cameraTransform = Camera.main.transform;

        _attackCount = attackCount;
        _useSpread = useSpread;
        _spreadFactor = spreadFactor;
        _searchLayers = searchLayers;
    }

    public override bool TryAttack()
    {
        if (CanAttack == false)
        {
            return false;
        }

        Attack();

        return true;
    }

    protected override void Attack()
    {
        WaitDelay();

        var hits = GetHits();

        if (hits.Length == 0)
        {
            return;
        }

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider == null)
            {
                continue;
            }
            if (hits[i].collider.TryGetComponent(out IWeaponVisitor visitor) == false)
            {
                continue;
            }

            Accept(visitor);
        }
    }

    private RaycastHit[] GetHits()
    {
        var hits = new RaycastHit[_attackCount];

        for (int i = 0; i < _attackCount; i++)
        {
            Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward + Spread);

            Physics.Raycast(ray, out var hit, MaxDistance, _searchLayers);

            hits[i] = hit;
        }

        return hits;
    }

    private Vector3 GetSpread()
    {
        return new Vector3()
        {
            x = Random.Range(-_spreadFactor, _spreadFactor),
            y = Random.Range(-_spreadFactor, _spreadFactor),
            z = Random.Range(-_spreadFactor, _spreadFactor),
        };
    }

    protected virtual void Accept(IWeaponVisitor visitor) => visitor.Visit(this);
}