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
    public class GetMoviesByIdQuery : IRequest<MoviesVm>
    {
        public int Id { get; set; }
    }

    public class GetMoviesByIdQueryHandler : IRequestHandler<GetMoviesByIdQuery, MoviesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MoviesVm> Handle(GetMoviesByIdQuery request, CancellationToken cancellationToken)
        {
            return new MoviesVm
            {
                     Movies = await _context.Movies
                    .Where(t => t.Id == request.Id)
                    .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
