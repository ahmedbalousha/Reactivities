using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Security
{
    public class IsHostRequirement : IAuthorizationRequirement {}

    public class IsHostRequirementHandler : AuthorizationHandler<IsHostRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dbcontext;

        public IsHostRequirementHandler(IHttpContextAccessor httpContextAccessor, DataContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbcontext = context;
        }
        
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsHostRequirement requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Task.CompletedTask;

            var activityId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
            .SingleOrDefault(x => x.Key == "id").Value?.ToString());

            var attendee = _dbcontext.ActivityAttendees
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.AppUserId == userId && x.ActivityId == activityId).Result;

            if (attendee == null) return Task.CompletedTask;
            if (attendee.IsHost) context.Succeed(requirement);

            return Task.CompletedTask;


           /* if (context.Resource is AuthorizationFilterContext authContext)
            {
                var currentUserName = _httpContextAccessor.HttpContext.User?.Claims
                    ?.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var activityId = authContext.RouteData.Values["id"].ToString();

                var activity = _context.Activities.SingleOrDefaultAsync(x => 
                    x.Id.ToString() == activityId).Result;

                var host = activity.Attendees.FirstOrDefault(x => x.IsHost);
                
                if (host?.AppUser?.UserName == currentUserName)
                    context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }*/

        }
    }
}