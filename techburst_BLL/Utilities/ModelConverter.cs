﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;
using Interfaces.BLL;
using techburst_BLL.Models;
using techburst_Data_Access_Layer.DTO;

namespace techburst_BLL.Utilities
{
    public static class ModelConverter
    {
        private static ArticleModel _model;
        private static ArticleDto _dto;
        private static TagDto _tagDto;
        private static UserDto _userDto;
        private static UserModel _userModel;
        private static ContactModel _contactModel;

        private static RoleDto _roleDto;
        private static RoleModel _roleModel;
        private static ContactDTO _contactDTO;

        public static ArticleModel ConvertDtoToModel(ArticleDto dto)
        {
            _model = new ArticleModel()
            {
                Id = dto.ArticleID, AuthorId = dto.AccountID, Title = dto.Title, ArticleText = dto.ArticleText, TagID = dto.TagID, TagName = dto.TagName, DateCreated = dto.DateCreated, Draft = dto.Draft, Images = dto.Images, LastEdited = dto.LastEdited
            };

            return _model;
        }

        public static ArticleDto ConvertModelToDto(IArticleModel model)
        {
            _dto = new ArticleDto()
            {
                ArticleID = model.Id, AccountID = model.AuthorId, Title = model.Title, ArticleText = model.ArticleText, TagID = model.TagID, TagName = model.TagName, DateCreated = model.DateCreated, Draft = model.Draft, Images = model.Images, LastEdited = model.LastEdited
            };
            return _dto;
        }

        public static TagDto ConvertTagModelToDto(ITagModel model)
        {
            _tagDto = new TagDto()
            {
                Id = model.Id,
                Name = model.Name
            };

            return _tagDto;
        }

        public static UserDto ConvertUserModelToDto(UserModel model)
        {
            _userDto = new UserDto()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                UserId = model.UserId,
                Role = model.Role
            };
            return _userDto;
        }

        public static UserModel ConvertUserDtoToModel(UserDto dto)
        {
            _userModel = new UserModel()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                UserId = dto.UserId,
                Role = dto.Role
            };
            return _userModel;
        }

        public static RoleDto ConvertRoleModelToDto(RoleModel model)
        {
            _roleDto = new RoleDto()
            {
                Id = model.RoleId,
                Name = model.RoleName
            };
            return _roleDto;
        }

        public static RoleModel ConvertRoleDtoToModel(RoleDto dto)
        {
            _roleModel = new RoleModel()
            {
                RoleId = dto.Id,
                RoleName = dto.Name
            };
            return _roleModel;
        }
        public static ContactDTO ConvertContactmodelToDTO(ContactModel model)
        {
            _contactDTO = new ContactDTO()
            {
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Question = model.Question
            };
            return _contactDTO;
        }
    }
}
