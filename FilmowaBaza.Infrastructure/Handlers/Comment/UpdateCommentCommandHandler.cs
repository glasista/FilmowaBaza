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
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, long>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private dbEntity _updateComment;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            this._commentRepository = commentRepository;
            this._mapper = mapper;
        }
        public async Task<long> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            _updateComment = await GetComment(request.Id);
            UpdateComment(request,_updateComment);

            await _commentRepository.UpdateAsync(_updateComment);

            return _updateComment.Id;
        }

        private void UpdateComment(UpdateCommentCommand commentModel, dbEntity dbComment)
        {
            _mapper.Map(commentModel,dbComment);
        }

        private Task<dbEntity> GetComment(long id)
        {
            return _commentRepository.GetAsyncById(id);
        }
    }
}
