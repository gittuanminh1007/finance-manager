using Abp.Application.Services.Dto;

namespace MoneyKeeper.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

