using System;
using System.Collections.Generic;
using PerfectChannel.Domain.DTO;
using PerfectChannel.Domain.DTO.Interfaces;

namespace PerfectChannel.Domain.Services
{
    public class StateFactory : IStateFactory
    {
        private IStateDTO CreatePendingStateDTO() => new PendingDTO();
        private Dictionary<string, Func<IStateDTO>> functions;
        public StateFactory(){
            functions = new Dictionary<string, Func<IStateDTO>>();
            functions.Add("Pending",CreatePendingStateDTO);
        }
        public IStateDTO CreateState(string state)
        {
            Func<IStateDTO> func = functions[state];
            
            return func();
        }
    }
}