﻿namespace RealEstateDapperApi.Dtos.ProductDetailDtos
{
    public class ResultProductDetailDto
    {
        public int ProductDetailId { get; set; }
        public int Size { get; set; }
        public int BedroomCount { get; set; }
        public int BathCount { get; set; }
        public int RoomCount { get; set; }
        public int GarageSize { get; set; }
        public int BuildYear { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
    }
}
