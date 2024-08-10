namespace RealEstateDapperApi.Dtos.ProductDtos
{
    public class ResultProductWithSearchDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string CoverImage { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
    }
}
