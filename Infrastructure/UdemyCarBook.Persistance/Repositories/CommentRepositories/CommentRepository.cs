using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistance.Context;

namespace UdemyCarBook.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;
        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment item)
        {
            _context.Comments.Add(item);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return _context.Comments.Select(x => new Comment
            {
                Id = x.Id,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Content = x.Content,
                Name = x.Name
            }).ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.Find(id);
        }

        public void Remove(Comment item)
        {
            var value = _context.Comments.Find(item.Id);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }

        public void Update(Comment item)
        {
            _context.Comments.Update(item);
            _context.SaveChanges();
        }
    }
}
