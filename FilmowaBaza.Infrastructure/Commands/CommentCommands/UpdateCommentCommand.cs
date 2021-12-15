using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmowaBaza.Infrastructure.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Content { get; set; }
    }
}
