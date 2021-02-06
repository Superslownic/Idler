namespace Idler
{
    public interface IActorSpawnerData
    {
        Range SpawnTime { get; }
        ushort ActorsLimit { get; }
    }
}
