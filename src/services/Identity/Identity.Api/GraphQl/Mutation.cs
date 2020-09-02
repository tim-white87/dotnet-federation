using System;
using AutoMapper;
using GraphQL;
using GraphQL.Utilities;
using Identity.Api.GraphQl.Identity;
using MediatR;

namespace Identity.Api.GraphQl
{
    public class Mutation
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public Mutation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        [GraphQLMetadata("identityOps")]
        public IdentityOpsType IdentityOps() => new IdentityOpsType(_mapper, _mediator);
    }
}