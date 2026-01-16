namespace SameApi.Dto
{
    public class SchoolResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public IEnumerable<ProfessionResponse> Professions { get; set; }
    }
}
