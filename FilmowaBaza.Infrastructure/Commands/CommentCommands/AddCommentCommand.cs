using FilmowaBaza.Infrastructure.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.Commands.CommentCommands
{
    public class AddCommentCommand : AbstractAuthCommand, IRequest<long>
    {
        public string Content { get; set; }
    }
}
