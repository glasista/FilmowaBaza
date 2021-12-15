using FilmowaBaza.Infrastructure.Commands.CommentCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmowaBaza.Domain.Repositories.Interfaces;
using AutoMapper;
using dbEntity = FilmowaBaza.Domain.Entities.Comment;

namespace FilmowaBaza.Infrastructure.Handlers.Comment
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, long>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        private dbEntity _newComment;
        public AddCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            this._commentRepository = commentRepository;
            this._mapper = mapper;
        }
        public async Task<long> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            _newComment = CreateComment(request);

            await _commentRepository.AddAsync(_newComment);

            return _newComment.Id;
        }

        private dbEntity CreateComment(AddCommentCommand commentModel)
        {
            var newComment = _mapper.Map<dbEntity>(commentModel);

            return newComment;
        }
    }
}
