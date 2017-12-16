namespace AdventOfCode.Day14
{
    public class RegionIdentifier
    {
        public static int[,] IdentifyRegions(byte[][] grid)
        {
            var regions = new int[grid.Length, grid.Length];
            var currentRegion = 1;
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid.Length; x++)
                {
                    if (grid[y][x] == 1 && regions[y, x] == 0)
                    {
                        PlotRegion(x, y, grid, regions, currentRegion);
                        currentRegion++;
                    }
                }
            }
            return regions;
        }

        private static void PlotRegion(int x, int y, byte[][] grid, int[,] regions, int region)
        {
            if (grid[y][x] == 0 || grid[y][x] == 1 && regions[y, x] != 0)
                return;
            regions[y, x] = region;
            if (x < grid.Length - 1 && grid[y][x + 1] == 1) PlotRegion(x + 1, y, grid, regions, region);
            if (y > 0 && grid[y - 1][x] == 1) PlotRegion(x, y - 1, grid, regions, region);
            if (x > 0 && grid[y][x - 1] == 1) PlotRegion(x - 1, y, grid, regions, region);
            if (y < grid.Length - 1 && grid[y + 1][x] == 1) PlotRegion(x, y + 1, grid, regions, region);
        }
    }
}
