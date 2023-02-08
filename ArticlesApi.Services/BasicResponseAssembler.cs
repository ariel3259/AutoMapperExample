using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApi.Contracts.Dto;
using ArticlesApi.Contracts.Interfaces;
using ArticlesApi.Repositories;

namespace ArticlesApi.Services
{
    public class BasicResponseAssembler<Entity, Request, Response, Update> where Entity: class, IBaseEntity where Response : class where Request: class where Update : class
    {
        protected ICrud<Entity> _repository;
        protected IMapper<Entity, Request, Response, Update> _mapper;

        public BasicResponseAssembler(ICrud<Entity> repository, IMapper<Entity, Request, Response, Update> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Response Create(Request req)
        {
            Entity toCreate = _mapper.Map(req);
            Entity created = _repository.Save(toCreate);
            return _mapper.Map(created);
        }

        public Page<Response> GetAll(int offset, int limit)
        {
            Page<Entity> entities = _repository.GetAll(offset, limit);
            return new Page<Response>
            {
                Elements = _mapper.Map(entities.Elements),
                TotalItems = entities.TotalItems,
            };
        }

        public Response? GetById(int ID)
        { 
            Entity? entity = _repository.GetById(ID);
            if (entity == null) return null;
            return _mapper.Map(entity);
        }

        public Response? Modify(Update update, int id)
        {
            Entity? entity = _repository.GetById(id);
            Console.WriteLine(entity == null);
            if (entity == null) return null;
            Entity toUpdate = _mapper.Map(update, entity);
            toUpdate.Id = id;
            Entity updated = _repository.Modify(toUpdate);
            return _mapper.Map(updated);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
