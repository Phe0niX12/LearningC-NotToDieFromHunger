using Training.DOTs.CowsDTOs;
using Training.Model;

namespace Training.Mapper
{
    public static class CowMappers
    {
        public static CowDTO toCowDTO(this Cow cow)
        {
            return new CowDTO
            {
                Name = cow.Name,
                Age = cow.Age,
                Color = cow.Color,
                Description = cow.Description,
            };
        }
    }
}
