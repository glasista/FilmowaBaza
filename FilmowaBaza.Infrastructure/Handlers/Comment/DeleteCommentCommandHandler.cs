using AutoMapper;
using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Infrastructure.Commands.CommentCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dbEntity = FilmowaBaza.Domain.Entities.Comment;

namespace FilmowaBaza.Infrastructure.Handlers.Comment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        private dbEntity _deletepost;
        public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            this._commentRepository = commentRepository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            _deletepost = await GetComment(request.Id);
            await _commentRepository.DeleteAsync(_deletepost);

            return Unit.Value;
        }
        private Task<dbEntity> GetComment(long id)
        {
            return _commentRepository.GetAsyncById(id);
        }
    }
}
