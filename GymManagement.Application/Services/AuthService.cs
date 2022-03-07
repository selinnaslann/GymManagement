﻿using AutoMapper;
using GymManagement.Application.Interfaces.ServiceInterfaces;
using GymManagement.Application.Jwt;
using GymManagement.Application.ViewModels.MemberViewModel;
using GymManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;

using System.Threading.Tasks;

namespace GymManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Member> _userManager;
        private readonly SignInManager<Member> _signInManager;
        private readonly IMapper _mapper;

        public AuthService(SignInManager<Member> signInManager, UserManager<Member> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        

        public async Task<bool> Register(MemberRegisterViewModel registerViewModel)
        {
            var member = _mapper.Map<Member>(registerViewModel);
            var emailCheckMember = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if (emailCheckMember is not null)
            {
                throw new InvalidOperationException("Email Mevcuttur.");
            }
            var result = await _userManager.CreateAsync(member, registerViewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(member, "Member");
                await _signInManager.SignInAsync(member, false);
                return true;
            }
            throw new InvalidOperationException("Kullanıcı kayıt işlemi başarılı değil");
        }

        public async Task<Token> Login(MemberLoginViewModel loginViewModel)
        {
            var memberFind = await _userManager.FindByEmailAsync(loginViewModel.Email);
            if (memberFind is null)
            {
                throw new InvalidOperationException("Email mevcut değildir.");
            }
            var result = await _userManager.CheckPasswordAsync(memberFind, loginViewModel.Password);
            if (!result)
            {
                throw new InvalidOperationException("Şifre yanlış.");
            }
            var userRoles = await _userManager.GetRolesAsync(memberFind);
            return null;
        }

       
    }
}
