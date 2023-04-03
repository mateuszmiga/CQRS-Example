﻿using MediatR;
using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : Domain.Entities.User, IRequest
    {
    }
}
