using Domain;
using Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class BarService : IBarService
    {
        private readonly IBarRepository _barRepository;

        public BarService(IBarRepository barRepository)
        {
            _barRepository = barRepository;
        }

        public Bar get(Guid id)
        {
            return _barRepository.get(id);
        }

        public List<Bar> getAllBar()
        {
            return _barRepository.getAll();
        }

        public void remove(Guid id)
        {
            _barRepository.removeBar(id);
        }

        public void saveBar(Bar bar)
        {
            _barRepository.saveBar(bar);
        }
    }
}
