namespace Backlog.Dtos
{
    public class ProductAddOrUpdateResponseDto: ProductDto
    {
        public ProductAddOrUpdateResponseDto(Backlog.Models.Product entity)
            :base(entity)
        {

        }
    }
}
