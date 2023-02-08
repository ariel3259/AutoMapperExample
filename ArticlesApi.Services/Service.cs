using ArticlesApi.Contracts.Dto;
using ArticlesApi.Contracts.Interfaces;
using ArticlesApi.Repositories;

namespace ArticlesApi.Services
{
    public class Service<E, R, S, U> where E: class, IBaseEntity where R: class where S : class where U : class
    {
        private AutoMapper.IMapper _mapper;
        private ICrud<E> _repository;
        private IMapUpdate<E, U> _mapUpdate;

        public Service(AutoMapper.IMapper mapper, ICrud<E> repository, IMapUpdate<E, U> mapUpdate) {
            _mapper = mapper;
            _repository = repository;
            _mapUpdate = mapUpdate;
        }

        public S GetById(int id)
        {
            return _mapper.Map<S>(_repository.GetById(id));
        }

        public Page<S> GetAll(int offset, int limit)
        {
            return _mapper.Map<Page<S>>(_repository.GetAll(offset, limit));
        }

        public S Create(R request)
        {
            E entityToCreate = _mapper.Map<E>(request);
            return _mapper.Map<S>(_repository.Save(entityToCreate));
        }

        public S? Update(U update, int id)
        {
            E? entityToModify = _repository.GetById(id);
            if (entityToModify == null) return null;
            E entityUpdated = _mapUpdate.Map(update, entityToModify);
            entityUpdated.Id = id;
            _repository.Modify(entityUpdated);
            return _mapper.Map<S>(entityUpdated);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
