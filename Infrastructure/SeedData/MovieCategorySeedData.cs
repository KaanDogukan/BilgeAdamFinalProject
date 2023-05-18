using ApplicationCore.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public class MovieCategorySeedData : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.HasData
                (
                    new MovieCategory { CategoryId = 1, MovieId = 1 },
                    new MovieCategory { CategoryId = 2, MovieId = 1 },
                    new MovieCategory { CategoryId = 3, MovieId = 1 },
                    new MovieCategory { CategoryId = 4, MovieId = 2 },
                    new MovieCategory { CategoryId = 5, MovieId = 2 },
                    new MovieCategory { CategoryId = 6, MovieId = 2 },
                    new MovieCategory { CategoryId = 1, MovieId = 3 },
                    new MovieCategory { CategoryId = 2, MovieId = 3 },
                    new MovieCategory { CategoryId = 6, MovieId = 4 },
                    new MovieCategory { CategoryId = 7, MovieId = 4 },
                    new MovieCategory { CategoryId = 1, MovieId = 5 },
                    new MovieCategory { CategoryId = 5, MovieId = 5 },
                    new MovieCategory { CategoryId = 6, MovieId = 6 },
                    new MovieCategory { CategoryId = 2, MovieId = 6 },
                    new MovieCategory { CategoryId = 3, MovieId = 6 },
                    new MovieCategory { CategoryId = 2, MovieId = 7 },
                    new MovieCategory { CategoryId = 6, MovieId = 7 },
                    new MovieCategory { CategoryId = 5, MovieId = 8 },
                    new MovieCategory { CategoryId = 1, MovieId = 8 },
                    new MovieCategory { CategoryId = 4, MovieId = 9 },
                    new MovieCategory { CategoryId = 5, MovieId = 9 },
                    new MovieCategory { CategoryId = 6, MovieId = 9 },
                    new MovieCategory { CategoryId = 1, MovieId = 10 },
                    new MovieCategory { CategoryId = 3, MovieId = 10 }
                );
        }
    }
}
