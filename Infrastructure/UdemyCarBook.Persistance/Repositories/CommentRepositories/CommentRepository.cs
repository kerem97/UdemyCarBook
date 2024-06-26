﻿using System;
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
                CommentId = x.CommentId,
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
        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x => x.BlogId == id).ToList();

        }
        public void Remove(Comment item)
        {
            var value = _context.Comments.Find(item.CommentId);
            _context.Comments.Remove(value);
            _context.SaveChanges();
        }
        public void Update(Comment item)
        {
            _context.Comments.Update(item);
            _context.SaveChanges();
        }
        public int GetCommentCountByBlog(int id)
        {
            return _context.Comments.Where(x => x.BlogId == id).Count();
        }
    }
}
