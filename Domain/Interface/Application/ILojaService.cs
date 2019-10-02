using Domain.DTO;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Application
{
    public interface ILojaService
    {
        Task <bool> CadastrarLoja(DTOLoja loja);
        Task<bool> CNPJValido(Loja loja);
    }
}
