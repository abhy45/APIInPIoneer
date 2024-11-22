namespace APIInPIoneer
{
    public class SampleDataService
    {
        private readonly List<string> _data;
        public SampleDataService()
        {
            // Sample data
            _data = Enumerable.Range(1, 100).Select(i => $"Item {i}").ToList();
        }

        public PaginatedResponse<string> GetPaginatedData(int pageNumber, int pageSize)
        {
            var totalRecords = _data.Count;
            var items = _data
                .Skip((pageNumber - 1) * pageSize) // Skip items of previous pages
                .Take(pageSize)                   // Take items of the current page
                .ToList();

            return new PaginatedResponse<string>(items, totalRecords, pageNumber, pageSize);
        }
    }
}
