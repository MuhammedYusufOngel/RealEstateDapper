namespace RealEstateDapperApi.Dtos.AmenityDtos
{
    public class ResultGetAmenitiesByProductIdDto
    {
        public int ProductAmenityId { get; set; }
        public int ProductId { get; set; }
        public int AmenityId { get; set; }
        public bool Status { get; set; }
        public string AmenityTitle { get; set; }
    }
}
