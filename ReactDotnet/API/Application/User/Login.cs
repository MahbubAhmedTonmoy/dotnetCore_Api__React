using System;
using System.Threading;
using System.Threading.Tasks;
using API.Application.Interfaces;
using API.Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace API.Application.User
{
    public class Login
    {
        public class Query: IRequest<User>
        {
            public string Email {get;set;}
            public string Password {get;set;}
        }

        public class QueryValidatior: AbstractValidator<Query>
        {
            public QueryValidatior()
            {
                RuleFor(x=> x.Email).NotEmpty();
                RuleFor(x=>x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly IJwtGenerator _jwtGenerator;
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;

            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
            {
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
                _signInManager = signInManager;
                
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var findUser = await _userManager.FindByEmailAsync(request.Email);

                if(findUser == null)
                    throw new Exception("not user find of this email");
                
                var result = await _signInManager.CheckPasswordSignInAsync(findUser,  request.Password, false);
                
                if(result.Succeeded)
                {
                    // generate token to do
                    return new User{
                        DisplayName = findUser.DisplayName,
                        Token = _jwtGenerator.CreateToken(findUser),
                        UserName = findUser.UserName,
                        Image = null
                    };
                }
                throw new Exception("bad request");
            }
        }
    }
}