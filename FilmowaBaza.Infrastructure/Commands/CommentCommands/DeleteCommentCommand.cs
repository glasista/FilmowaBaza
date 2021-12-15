using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.Commands.CommentCommands
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
