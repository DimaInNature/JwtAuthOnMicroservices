﻿global using JwtExample.Microservices.AuthService.Application.Interfaces;
global using JwtExample.Microservices.AuthService.Application.Services;
global using JwtExample.Microservices.AuthService.Domain.Commands.Users;
global using JwtExample.Microservices.AuthService.Domain.Core.Models.Configuration;
global using JwtExample.Microservices.AuthService.Domain.Handlers;
global using JwtExample.Microservices.AuthService.Domain.Queries.Users;
global using JwtExample.Microservices.AuthService.Infra.IoC.MediatR.Profiles;
global using JwtExample.Microservices.AuthService.Persistence.Entities;
global using JwtExample.Shared.Persistence.Interfaces;
global using JwtExample.Shared.Persistence.Repositories;
global using MediatR;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;