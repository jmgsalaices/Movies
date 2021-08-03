using AutoMapper;
using AutoMapper.QueryableExtensions;
using Movies.Application.Common.Interfaces;
using Movies.Application.Common.Security;
using Movies.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Movies.Queries.GetMovies
{
    public class GetMoviesQuery : IRequest<MoviesVm>
    {
    }

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, MoviesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MoviesVm> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return new MoviesVm
            {
                Movies = await _context.Movies
                    .AsNoTracking()
                    .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Film)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
