using IceCream.Domain.Entities;

namespace IceCream.Infrastructure.Persistences.Contexts
{
    public class SeedDb
    {
        private readonly IceCreamContext _context;
        public SeedDb(IceCreamContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
        await CheckCategoriesAsync();

        }
        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _ = _context.Categories.Add(new Category
                {
                    Name = "Plombir",
                    Description = "is considered the richest of ice-creams. They are often considered to be the tastiest, too.",
                    CreateDate = DateTime.Now,
                    CreateUser = 1,  
                    Image = "/assets/images/icecream6.png",
                    State = 1,

                });
                _ = _context.Categories.Add(new Category
                {
                    Name = "Creamy ice-cream",
                    Description = "it is slightly leaner than plombir. It has 8-11% of milk fats. This means that the value of 100g of product is about 180kcal.",
                    CreateDate = DateTime.Now,
                    CreateUser = 1,
                    Image = "/assets/images/icecream1.png",
                    State = 1,

                });
                _ = _context.Categories.Add(new Category
                {
                    Name = "Fruit Ice Lolly",
                    Description = "ices with no fats (of course, unless it is ice-cream with fruit). There should be at least 20% fruits in such desserts, or, if it is made of fruit juice concentrate, it should be no less than 2,5%.",
                    CreateDate = DateTime.Now,
                    CreateUser = 1,
                    Image = "/assets/images/icecream2.png",
                    State = 1,

                });
                _ = _context.Categories.Add(new Category
                {
                    Name = "Sorbet and sherbet. It is not the same!",
                    Description = "Sorbet is a mixed frozen juice which has no fats. In it there must be at least 25% fruits. No milk or its components are used when making sorbet. It is perfect for people with lactose intolerance! ",
                    CreateDate = DateTime.Now,
                    CreateUser = 1,
                    Image = "/assets/images/icecream3.png",
                    State = 1,

                });
                _ = _context.Categories.Add(new Category
                {
                    Name = "Frozen yogurt",
                    Description = "is made with live yogurt cultures inoculated with ferments. When a required acidity levels are reached, yogurt is whipped and frozen – that is how the ice-cream is made. Frozen yogurt can be also made using an already prepared yogurt.",
                    CreateDate = DateTime.Now,
                    CreateUser = 1,
                    Image = "/assets/images/icecream4.png",
                    State = 1,

                });
                _ = _context.Categories.Add(new Category
                {
                    Name = "Dietary",
                    Description = "has a reduced amount of caloric components; they are partly or fully replaced with fat substitutes and artificial sweeteners.",
                    CreateDate = DateTime.Now,
                    CreateUser = 1,
                    Image = "/assets/images/icecream8.png",
                    State = 1,

                });
                _ = _context.Categories.Add(new Category
                {
                    Name = "Spaghettiesis",
                    Description = "dish made to resemble a plate of spaghetti.",
                    CreateDate = DateTime.Now,
                    CreateUser = 1,
                    Image = "/assets/images/icecream7.png",
                    State = 1,

                });

                _ = await _context.SaveChangesAsync();
            }
        }
    }
}
