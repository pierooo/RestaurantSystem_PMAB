using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantSystem.Contracts;
using RestaurantSystem.Contracts.Categories.Commands;
using RestaurantSystem.DataAccess;
using RestaurantSystem.Mappers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestaurantSystem.Handlers.Categories
{
    public class DeleteCategoryCommandHandler : HandlerBase, IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
    {
        public DeleteCategoryCommandHandler(RestaurantSystemContext restaurantSystemContext) : base(restaurantSystemContext)
        {
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                RestaurantSystemContext.Categories.Add(CategoriesMapper.MapToDbModel(command));
                await RestaurantSystemContext.SaveChangesAsync();
                return new DeleteCategoryResponse()
                {
                    Data = new CommandResponse(true)
                };
            }
            catch (Exception ex)
            {
                return new DeleteCategoryResponse()
                {
                    Error = new ErrorModel(ex.Message)
                };
            }
        }
    }
}
