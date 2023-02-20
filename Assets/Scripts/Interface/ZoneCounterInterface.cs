namespace SedaCinar.AreaFinder.Interface
{
    public interface ZoneCounterInterface
    {
        // Feeds map data into solution class, then get ready for Solve() method.
        void Init(MapInterface map);
        // Counts zones in map provided with Init() method, then return the result.
        int Solve();
    }
}