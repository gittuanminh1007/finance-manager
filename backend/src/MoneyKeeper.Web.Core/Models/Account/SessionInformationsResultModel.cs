using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MoneyKeeper.Authorization.Users;

namespace MoneyKeeper.Models.Account
{
    public class SessionInformationsResultModel
    {
        public ApplicationInfoDto Application { get; set; }

        public UserLoginInfoDto User { get; set; }
    }

    public class ApplicationInfoDto
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Dictionary<string, bool> Features { get; set; }
    }

    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
