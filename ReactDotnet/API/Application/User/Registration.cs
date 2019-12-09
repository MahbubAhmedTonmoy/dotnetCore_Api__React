using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Domain;
using API.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Application.User
{
    public class Registration
    {
        public class Command : IRequest<User>
        {
            public string DisplayName {get;set;}

            public string Password {get;set;}

            public string UserName{get;set;}

            public string Email{get;set;}
        }

        public class CommandValidatior: AbstractValidator<Command>
        {
            public CommandValidatior()
            {
                RuleFor(x=> x.Email).NotEmpty().EmailAddress();
                RuleFor(x=>x.Password).NotEmpty();
                RuleFor(x=> x.DisplayName).NotEmpty();
                RuleFor(x=>x.UserName).NotEmpty();

            }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext context, UserManager<AppUser> userManager)
            {
                _context = context;
                _userManager = userManager;
            }
            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                if(await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                    throw new Exception("already use this email");
                 if(await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
                    throw new Exception("already use this user name");
                
                var user = new AppUser
                {
                    DisplayName = request.DisplayName,
                    UserName = request.DisplayName,
                    Email = request.Email
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if(result.Succeeded)
                {
                    return new User {
                        DisplayName = user.DisplayName,
                        UserName = user.UserName
                    };
                }
                throw new Exception("failed");
            }
        }
    }
}