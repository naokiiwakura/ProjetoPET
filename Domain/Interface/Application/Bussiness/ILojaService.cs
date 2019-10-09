using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface.Application.Bussiness
{
    public interface ILojaService 
    {
        void Cadastrar(LojaDto loja);

    }
}
