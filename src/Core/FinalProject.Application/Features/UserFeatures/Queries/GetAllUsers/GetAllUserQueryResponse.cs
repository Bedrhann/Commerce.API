using FinalProject.Application.DTOs.User;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUsers
{
    public class GetAllUserQueryResponse
    {
        public BaseResponse<List<UserDto>> BaseResponse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

